using MES.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MES.Infrastructure.Persistence.Configurations
{
    public class DefectConfiguration : IEntityTypeConfiguration<Defect>
    {
        public void Configure(EntityTypeBuilder<Defect> builder)
        {
            builder.HasOne(d => d.WorkOrder)
                .WithMany(w => w.Defects)
                .HasForeignKey(d => d.WorkOrderId)
                .OnDelete(DeleteBehavior.Cascade); // ako se obrise w => obrisi i defect

            builder.HasOne(d => d.DefectType)
                .WithMany(t => t.Defects)
                .HasForeignKey(d => d.DefectTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
