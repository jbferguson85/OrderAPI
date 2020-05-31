using System;
using Microsoft.EntityFrameworkCore;
using OrderAccessors.Entities;

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

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<LineItem> LineItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LineItem>().HasKey(o => new { o.OrderId, o.ProductId});
        }
    }
}
