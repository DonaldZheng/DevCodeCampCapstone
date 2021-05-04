using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalEquipmentCapstone.Models;
using RentalEquipmentCapstone.Models.Comments;
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
                Id = "314a9413-2da6-4bd5-a57f-ea2c962e01be",
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "06430445-5537-4f60-934f-4866b0c824e3"
            },
            new IdentityRole
            {
                Id = "5eb8a84f-8667-4307-8b76-c8a846d927c2",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "7329f8a1-a4b2-46b0-9f9f-e6e309d6e862"

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
        public DbSet<Post> Posts
        {
            get; set;
        }
        public DbSet<MainComment> MainComments
        {
            get; set;
        }
        public DbSet<SubComment> SubComments
        {
            get; set;
        }

    }
         
}
