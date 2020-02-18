using ASP.Core.GraphQL.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASP.Core.GraphQL.Database
{
    public class ShopContext : DbContext
    {
        public ShopContext() { }
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);


            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
