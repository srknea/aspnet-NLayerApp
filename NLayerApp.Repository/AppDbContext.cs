using Microsoft.EntityFrameworkCore;
using NLayerApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //var p = new Product() { ProductFeature = new ProductFeature() { } };  
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API 
            //modelBuilder.Entity<Category>().HasKey(x => x.Id);

            /* ----------------------------------------------------- */

            /* Configuration'ları tek tek eklemek */
            /*
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductFeatureConfiguration());
            */

            /* Configuration'ları tek satırda eklemek */
            // IEntityTypeConfiguration interace'ini implemente eden class'ları bulur ve onları bulur ve onları uygular.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Assembly nedir? : Solution'daki bütün Class Library'leri temsil eder.
            // Assembly içerisindeki tüm class'ları bul ve onları uygula.
            // Neredeki Assembly ? -> Assembly.GetExecutingAssembly() : Bu class'ın bulunduğu assembly

            /* ----------------------------------------------------- */

            /* Seed Data'ları direkt buradan eklemek... (Biz Seeds klasöründen ekledik...)*/
            /*
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Kalemler" },
                new Category { Id = 2, Name = "Defterler" },
                new Category { Id = 3, Name = "Kitaplar" }
            );
            */

            base.OnModelCreating(modelBuilder);
        }
    }
}
