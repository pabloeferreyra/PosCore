using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PFSoftware.Inventio.Models;

namespace PFSoftware.Inventio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>()
            .Property(b => b.Date)
            .HasDefaultValueSql("getdate()");
            builder.Entity<Product>()
            .Property(b => b.Sales)
            .HasDefaultValueSql("0");
            builder.Entity<Client>()
            .Property(b => b.LastBuy)
            .HasDefaultValueSql("getdate()");
            builder.Entity<Category>()
            .Property(b => b.Date)
            .HasDefaultValueSql("getdate()");
            builder.Entity<Sale>()
            .Property(b => b.Date)
            .HasDefaultValueSql("getdate()");
            builder.Entity<SaleProduct>()
                .HasKey(sp => new { sp.SaleId, sp.ProductId });
            builder.Entity<SaleProduct>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.SaleProducts)
                .HasForeignKey(sp => sp.ProductId);
            builder.Entity<SaleProduct>()
                .HasOne(sp => sp.Sale)
                .WithMany(p => p.SaleProducts)
                .HasForeignKey(sp => sp.SaleId);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
    }
}
