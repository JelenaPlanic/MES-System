

using MES.Domain.Entities;

namespace MES.Application.Interfaces
{
    // spaja sve repo i saveChangesAsync na jednom mestu
    public interface IUnitOfWork : IDisposable // konekcija ka bazi, resurs koji mora da se oslobodi
    {

        Task<int> SaveChangesAsync();
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Machine> Machines { get; }
        IGenericRepository<WorkOrder> WorkOrders { get; }
        IGenericRepository<Downtime> Downtimes { get; }
        IGenericRepository<DowntimeReason> DowntimeReasons { get; }
        IGenericRepository<Defect> Defects { get; }
        IGenericRepository<DefectType> DefectTypes { get; }
        IGenericRepository<Shift> Shifts { get; }
    } 
    // Jedan objekat tipa IUnitOfWork ti daje pristup svim repos plus metoda za snimanje
}
