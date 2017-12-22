using HealthyMe.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyMe.Data
{
    public class HealthyMeDbContext : IdentityDbContext<User>
    {
        public DbSet<Diet> Diets { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<UserProduct> UsersWithProducts { get; set; }

        public DbSet<DietProduct> DietWithProducts { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<UserTraining> UsersWithTrainings { get; set; }

        public DbSet<Message> Messages { get; set; }

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
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Diet>()
                .HasOne(d => d.Author)
                .WithMany(a => a.Diets)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserProduct>()
                .HasKey(up => new { up.UserId, up.ProductId });

            builder.Entity<UserProduct>()
                .HasOne(up => up.User)
                .WithMany(u => u.Products)
                .HasForeignKey(up => up.UserId);

            builder.Entity<UserProduct>()
                .HasOne(up => up.Product)
                .WithMany(p => p.Users)
                .HasForeignKey(up => up.ProductId);

            builder.Entity<UserTraining>()
                .HasKey(ut => new { ut.UserId, ut.TrainingId });

            builder.Entity<UserTraining>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.Trainings)
                .HasForeignKey(ut => ut.UserId);

            builder.Entity<UserTraining>()
                .HasOne(ut => ut.Training)
                .WithMany(t => t.Users)
                .HasForeignKey(ut => ut.TrainingId);

            builder.Entity<User>()
                .HasMany(u => u.MyProducts)
                .WithOne(mp => mp.User)
                .HasForeignKey(mp => mp.UserId);

            builder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId);

            base.OnModelCreating(builder);
        }
    }
}