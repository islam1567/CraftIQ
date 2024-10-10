using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CraftIQ.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Transactions> Transactions { get; set; }


    }
}
