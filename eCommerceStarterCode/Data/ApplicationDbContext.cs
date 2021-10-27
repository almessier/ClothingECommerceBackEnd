using eCommerceStarterCode.Configuration;
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
            public override DbSet<User> Users { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Name = "Cool Hoodie", Price = 499, Category = "Hoodies", Description = "Our coolest hoodie, ever." },
                    new Product { Id = 3, Name = "Bad Hoodie", Price = 15, Category = "Hoodies", Description = "Our baddest hoodie, ever." }
                );
            modelBuilder.Entity<ShoppingCart>().HasKey( u => new { u.UserId, u.ProductId });
            
            
            //modelBuilder.Entity<ShoppingCart>()
            //    .HasData(
            //        new ShoppingCart { Id = 1, UserId = "1", ProductId = 1, Quantity = 1}
            //    );
        }

    }
}