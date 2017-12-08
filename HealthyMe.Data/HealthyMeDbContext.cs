using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HealthyMe.Data.Models;

namespace HealthyMe.Data
{
    public class HealthyMeDbContext : IdentityDbContext<User>
    {
        public DbSet<Diet> Diets { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<DietProduct> DietWithProducts { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public HealthyMeDbContext(DbContextOptions<HealthyMeDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DietProduct>()
                .HasKey(dp => new { dp.DietId, dp.ProductId });

            builder.Entity<DietProduct>()
                .HasOne(dp => dp.Product)
                .WithMany(p => p.Diets)
                .HasForeignKey(dp => dp.ProductId);

            builder.Entity<DietProduct>()
                .HasOne(dp => dp.Diet)
                .WithMany(d => d.Products)
                .HasForeignKey(dp => dp.DietId);


            builder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(au => au.Articles)
                .HasForeignKey(a => a.AuthorId);

            builder.Entity<Diet>()
                .HasOne(d => d.Author)
                .WithMany(a => a.Diets)
                .HasForeignKey(d => d.AuthorId);

            
            base.OnModelCreating(builder);
        }
    }
}
