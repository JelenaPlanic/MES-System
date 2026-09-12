using MES.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MES.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>,int>

    {
        public DbSet<Product> Products => Set<Product>(); // expression-bodied prop
        public DbSet<Machine> Machines => Set<Machine>();
        public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
        public DbSet<Downtime> Downtimes => Set<Downtime>();
        public DbSet<DowntimeReason> DowntimeReasons => Set<DowntimeReason>();
        public DbSet<Defect> Defects => Set<Defect>();
        public DbSet<DefectType> DefectTypes => Set<DefectType>();
        public DbSet<Shift> Shifts => Set<Shift>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            // pronalazi sve klase koje implem IEntityTypeConf<> unutar istog assembly
        }
    }
}
