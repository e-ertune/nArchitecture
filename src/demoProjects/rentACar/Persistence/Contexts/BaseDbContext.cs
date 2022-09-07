using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
       

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(e =>
            {
                e.ToTable("Brands").HasKey(e => e.Id);
                e.Property(e => e.Id).HasColumnName("Id");
                e.Property(e => e.Name).HasColumnName("Name");
                e.HasMany(e => e.Models).WithOne(e => e.Brand);
            });

            modelBuilder.Entity<Model>(e =>
            {
                e.ToTable("Models").HasKey(e => e.Id);
                e.Property(e => e.Id).HasColumnName("Id");
                e.Property(e => e.BrandId).HasColumnName("BrandId");
                e.Property(e => e.Name).HasColumnName("Name");
                e.Property(e => e.ImageUrl).HasColumnName("ImageUrl");
                e.HasOne(e => e.Brand).WithMany(e => e.Models);
            });

            Brand[] brandEntitySeeds = { 
                new(1, "Porsche"), 
                new(2, "Mercedes-Benz"), 
                new(3, "Alfa Romeo"), 
                new(4, "BMW") 
            };
            modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);

            Model[] modelEntitySeeds = {
                new(1, 1, "911", 1899.99M, ""),
                new(2, 1, "Cayman", 1699.99M, ""),
                new(3, 2, "C-Class", 1299.99M, ""),
                new(4, 2, "E-Class", 1499.99M, ""),
                new(5, 3, "Guilia", 1399.99M, ""),
                new(6, 3, "Stelvio", 1499.99M, ""),
                new(7, 4, "Series 5", 1499.99M, ""),
                new(8, 4, "Series 1", 999.99M, "")
            };
            modelBuilder.Entity<Model>().HasData(modelEntitySeeds);
        }
    }
}
