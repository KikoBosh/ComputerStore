using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using ComputerStore.Data.Entities;

namespace ComputerStore.Data
{
    public class ComputerStoreContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ComputerStoreContext(DbContextOptions<ComputerStoreContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("ComputerStore.Data"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entry =>
            {
                entry.HasKey(e => e.Id);

                entry.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsRequired(true);

                entry.Property(e => e.Description)
                    .HasMaxLength(400)
                    .IsRequired(false);

                entry.Property(e => e.Price)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired(true);

                entry.HasMany(p => p.Categories)
                    .WithMany(c => c.Products)
                    .UsingEntity(j => j.ToTable("ProductCategory"));
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Name)
                    .HasMaxLength(200)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity.Property(a => a.Description)
                    .HasMaxLength(400)
                    .IsUnicode(true)
                    .IsRequired(false);
            });
        }
    }
}
