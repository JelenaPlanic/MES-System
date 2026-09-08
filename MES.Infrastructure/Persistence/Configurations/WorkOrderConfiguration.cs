using MES.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MES.Infrastructure.Persistence.Configurations
{
    public class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
    {
        public void Configure(EntityTypeBuilder<WorkOrder> builder)
        {
            builder.Property(w => w.OrderNumber)
           .IsRequired()
           .HasMaxLength(50);

            builder.HasIndex(w => w.OrderNumber)
                .IsUnique();

            builder.HasOne(w => w.Product)
                .WithMany(p => p.WorkOrders)
                .HasForeignKey(w => w.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // ako pokusas da obrises Product, baza nece dozvoliti.

            builder.HasOne(w => w.Machine)
                .WithMany(m => m.WorkOrders)
                .HasForeignKey(w => w.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(w => w.AssignedUser)
                .WithMany(u => u.WorkOrders)
                .HasForeignKey(w => w.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
