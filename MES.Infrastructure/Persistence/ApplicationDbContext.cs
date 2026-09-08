using MES.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext // unit of work = transakcija, FLUENT API
    {
        public DbSet<Product> Products => Set<Product>(); // expression-bodied prop
        public DbSet<Machine> Machines => Set<Machine>();
        public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
        public DbSet<Downtime> Downtimes => Set<Downtime>();
        public DbSet<DowntimeReason> DowntimeReasons => Set<DowntimeReason>();
        public DbSet<Defect> Defects => Set<Defect>();
        public DbSet<DefectType> DefectTypes => Set<DefectType>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Shift> Shifts => Set<Shift>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            // pronalazi sve klase koje implem IEntityTypeConf<> unutar istog assembly
        }
    }
}
