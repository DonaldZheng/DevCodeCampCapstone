using CapstoneOne.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalEquipmentCapstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalEquipmentCapstone.Data
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
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                },
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
            );
            builder.Entity<Product>()
          .HasData(
                  new Product { ProductId = 1, Name = "Bench Rental", Description = "Let Us Do All The Planning For Your Date!", Price = 100 },
                  new Product { ProductId = 2, Name = "Dumbbell Rental", Description = "Dumbbell Ranging from 2.5lbs to 150lbs", Price = 100 },
                  new Product { ProductId = 3, Name = "Plate Rental", Description = "Plate Ranging from 2.5lbs to 45lbs", Price = 100 },
                  new Product { ProductId = 4, Name = "Barbell Rental", Description = "Barbell For Benching, Deadlifting, and Squating", Price = 100 },
                  new Product { ProductId = 5, Name = "Rack Rental", Description = "Racks To Place Your Dumbbells and Plates", Price = 100 }
          );

            builder.Entity<CustomerProduct>()
                .HasKey(cp => new { cp.CustomerId, cp.ProductId });
            builder.Entity<CustomerProduct>()
                .HasOne(cp => cp.Customer)
                .WithMany(c => c.ShoppingCart)
                .HasForeignKey(cp => cp.CustomerId);
            builder.Entity<CustomerProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.ShoppingCart)
                .HasForeignKey(cp => cp.ProductId);
        }
        public DbSet<Customer> Customers
        {
            get; set;
        }
        public DbSet<Product> Products
        {
            get; set;
        }
        public DbSet<CustomerProduct> CustomerProducts
        {
            get; set;
        }
        public DbSet<Admin> Admins
        {
            get; set;
        }
    }
         
}
