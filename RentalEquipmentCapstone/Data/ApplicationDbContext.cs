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
        }
        public DbSet<Customer> Customers
        {
            get; set;
        }
        public DbSet<Product> Products
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
        public DbSet<Article> Articles
        {
            get; set;
        }
        public DbSet<ArticleComment> ArticlesComments
        {
            get; set;
        }
        public DbSet<Upcoming> Upcomings
        {
            get; set;
        }


    }

}
