using CraftIQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CraftIQ.Configuration
{
    public class OrderDetailsConfigure : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.Property(e => e.Quantity)
                .HasMaxLength(5);

            builder.Property(e => e.TotalPrice)
                .HasMaxLength(10000);
        }
    }
}
