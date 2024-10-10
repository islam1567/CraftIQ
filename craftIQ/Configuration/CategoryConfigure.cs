using CraftIQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CraftIQ.Confugration
{
    public class CategoryConfigure : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(20);               

            builder.Property(e => e.Description)
                .HasMaxLength(200);               
        }
    }
}
