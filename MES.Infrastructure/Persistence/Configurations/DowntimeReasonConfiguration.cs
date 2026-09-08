using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MES.Domain.Entities;

namespace MES.Infrastructure.Persistence.Configurations;

public class DowntimeReasonConfiguration : IEntityTypeConfiguration<DowntimeReason>
{
    public void Configure(EntityTypeBuilder<DowntimeReason> builder)
    {
        builder.Property(r => r.Code).IsRequired().HasMaxLength(20);
        builder.Property(r => r.Description).IsRequired().HasMaxLength(200);
        builder.HasIndex(r => r.Code).IsUnique();

        builder.HasData // namenjen retko promenljivim podacima
            (
            new DowntimeReason { Id = 1, Code = "MECH-01", Description = "Kvar mehanickog dela", CreatedAt = new DateTime(2026, 1, 1) },
            new DowntimeReason { Id = 2, Code = "ELEC-01", Description = "Kvar elektricnog sistema", CreatedAt = new DateTime(2026, 1, 1) },
            new DowntimeReason { Id = 3, Code = "MAT-SHORT", Description = "Nedostatak materijala", CreatedAt = new DateTime(2026, 1, 1) },
            new DowntimeReason { Id = 4, Code = "MAINT", Description = "Planirano odrzavanje", CreatedAt = new DateTime(2026, 1, 1) },
            new DowntimeReason { Id = 5, Code = "CHANGEOVER", Description = "Promena alata", CreatedAt = new DateTime(2026, 1, 1) }

            );
    }
}
