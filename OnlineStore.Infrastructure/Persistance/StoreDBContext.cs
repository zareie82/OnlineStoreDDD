using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Identity;
using OnlineStore.Domain.Order;
using OnlineStore.Domain.Product;
using OnlineStore.Infrastructure.Persistance.Configs;

namespace OnlineStore.Infrastructure.Persistance
{
    public class StoreDBContext : IdentityDbContext<ApplicationUser>
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new OrderConfig());
            builder.ApplyConfiguration(new OrderItemConfig());

            

            base.OnModelCreating(builder);
        }
    }
}
