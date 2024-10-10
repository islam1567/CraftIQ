using CraftIQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CraftIQ.Configuration
{
    public class ProductConfigure : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(20);

            builder.Property(e => e.Description)
                .HasMaxLength(200);

            builder.Property(e => new {e.Width, e.Hieght, e.Wieght, e.Length})
                .HasMaxLength(50);

            builder.Property(e => new { e.UnitPrice, e.TaxCost, e.ProfitPerUnit, e.ProductionCost })
                .HasMaxLength(100);
        }
    }
}
