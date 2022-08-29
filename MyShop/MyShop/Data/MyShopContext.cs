using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Data
{
    public class MyShopContext : DbContext
    {
        public MyShopContext (DbContextOptions<MyShopContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            builder.Entity<Category>(entity => {
                entity.HasIndex(e => e.Description).IsUnique();
            });
        }

        public DbSet<MyShop.Models.Category> Category { get; set; } = default!;

        public DbSet<MyShop.Models.SubCategory>? SubCategory { get; set; }

        public DbSet<MyShop.Models.Product>? Product { get; set; }
    }
}
