using CraftIQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CraftIQ.Configuration
{
    public class InventoryConfigure : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.Property(e => e.Quantity)
                .HasMaxLength(10);
        }
    }
}
