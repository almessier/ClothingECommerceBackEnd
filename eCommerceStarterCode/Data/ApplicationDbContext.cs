﻿using eCommerceStarterCode.Configuration;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStarterCode.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
            public DbSet<Product> Products { get; set; }
            public DbSet<Review> Reviews { get; set; }
            public DbSet<ShoppingCart> ShoppingCarts { get; set; }
            public DbSet<User> Users { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Name = "Cool Hoodie", Price = 499, Category = "Hoodies", Description = "Our coolest hoodie, ever." }
                );
        }

    }
}