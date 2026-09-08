using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MES.Domain.Entities;

namespace MES.Infrastructure.Persistence.Configurations;

public class DowntimeConfiguration : IEntityTypeConfiguration<Downtime>
{
    public void Configure(EntityTypeBuilder<Downtime> builder)
    {
        builder.HasOne(d => d.WorkOrder)
            .WithMany(w => w.DownTimes)
            .HasForeignKey(d => d.WorkOrderId)
            .OnDelete(DeleteBehavior.Cascade); // Downtime nema smisla bez svog naloga, nalog se obrise, brisi i njegove zastoje

        builder.HasOne(d => d.DowntimeReason)
            .WithMany(r => r.Downtimes)
            .HasForeignKey(d => d.DowntimeReasonId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
