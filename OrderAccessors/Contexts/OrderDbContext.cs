using Microsoft.EntityFrameworkCore;
using OrderCore.Entities;

namespace OrderAccessors.Contexts
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext()
        {

        }
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<CustomerEntity> Customers { get; set; }

        public DbSet<LineItemEntity> LineItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("order_api");
            
            modelBuilder.Entity<LineItemEntity>()
                .HasKey(o => new { o.OrderId, o.ProductId});
            modelBuilder.Entity<LineItemEntity>()
                .HasOne<OrderEntity>()
                .WithMany(x => x.LineItems)
                .HasForeignKey(x => x.OrderId);
            

        }
    }
}
