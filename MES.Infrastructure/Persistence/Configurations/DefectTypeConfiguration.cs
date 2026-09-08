using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MES.Domain.Entities;

namespace MES.Infrastructure.Persistence.Configurations;

public class DefectTypeConfiguration : IEntityTypeConfiguration<DefectType>
{
    public void Configure(EntityTypeBuilder<DefectType> builder)
    {
        builder.Property(t => t.Code).IsRequired().HasMaxLength(20);
        builder.Property(t => t.Description).IsRequired().HasMaxLength(200);
        builder.HasIndex(t => t.Code).IsUnique();

        builder.HasData
            (
            new DefectType { Id = 1, Code = "SCRATCH", Description = "Ogrebotina na povrsini", CreatedAt = new DateTime(2026, 1, 1) },
            new DefectType { Id = 2, Code = "DIM-ERR", Description = "Dimenzija van tolerancije", CreatedAt = new DateTime(2026, 1, 1) },
            new DefectType { Id = 3, Code = "CRACK", Description = "Pukotina", CreatedAt = new DateTime(2026, 1, 1) },
            new DefectType { Id = 4, Code = "MISALIGN", Description = "Loše poravnanje delova", CreatedAt = new DateTime(2026, 1, 1) }
            );
    }
}
