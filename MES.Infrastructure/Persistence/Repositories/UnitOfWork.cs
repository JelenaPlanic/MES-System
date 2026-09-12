using MES.Application.Interfaces;
using MES.Domain.Entities;


namespace MES.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork  // transakcija sve promene prodju ili sve padaju
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new GenericRepository<Product>(_context); // vrednost se postavi 1, zauvek, pri kreiranju objekta
            Machines = new GenericRepository<Machine>(_context);
            WorkOrders = new GenericRepository<WorkOrder>(_context);
            Downtimes = new GenericRepository<Downtime>(_context);
            DowntimeReasons = new GenericRepository<DowntimeReason>(_context);
            Defects = new GenericRepository<Defect>(_context);
            DefectTypes = new GenericRepository<DefectType>(_context);
            Shifts = new GenericRepository<Shift>(_context);
        }

        public IGenericRepository<Product> Products { get; } // get-only auto prop, nema set, jedino mesto gde moze da dob vr, jeste ctor.

        public IGenericRepository<Machine> Machines {  get; }

        public IGenericRepository<WorkOrder> WorkOrders { get; }

        public IGenericRepository<Downtime> Downtimes { get; }

        public IGenericRepository<DowntimeReason> DowntimeReasons { get; }

        public IGenericRepository<Defect> Defects  {  get; }

        public IGenericRepository<DefectType> DefectTypes  {  get; }

        public IGenericRepository<Shift> Shifts { get; }

        public void Dispose() => _context.Dispose();
       
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        
    }
}
