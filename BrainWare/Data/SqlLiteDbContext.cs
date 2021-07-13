using BrainWare.Data;
using BrainWare.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainWare.Data
{
    public partial class SqlLiteDbContext : DbContext
    {

        public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options) : base(options)
        {
            OnCreated();
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
                .HasOne(e => e.Company)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CompanyId);

            builder.Entity<OrderProduct>()
                .HasOne(e => e.Order)
                .WithMany(e => e.OrderProducts)
                .HasForeignKey(e => e.OrderId);

            builder.Entity<OrderProduct>()
                .HasOne(e => e.Product)
                .WithMany(e => e.OrderProducts)
                .HasForeignKey(e => e.ProductId);

        }

        partial void OnCreated();

    }

}
