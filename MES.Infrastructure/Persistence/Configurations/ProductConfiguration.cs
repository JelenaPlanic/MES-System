using MES.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MES.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product> // Strategy pattern
    {
        public void Configure(EntityTypeBuilder<Product> builder) // metoda koju interfejs zahteva
        {
            builder.Property(p => p.Code)  // lambda izraz
                .IsRequired().HasMaxLength(50);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(p => p.Code) // unique index, 2 products ne mogu imati istu sifru, ubrzava pretragu
                .IsUnique();
        }
    }
}
