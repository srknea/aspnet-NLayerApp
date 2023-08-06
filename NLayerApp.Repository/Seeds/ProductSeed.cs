using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { Id = 1, CategoryId = 1, Name = "Pilot Kalem", Price = 10, Stock = 100,  CreatedDate = DateTime.Now },
                new Product() { Id = 2, CategoryId = 1, Name = "Kurşun Kalem", Price = 8, Stock = 200,  CreatedDate = DateTime.Now },
                new Product() { Id = 3, CategoryId = 3, Name = "Açlık Oyunları: Ateşi Yakalamak ", Price = 15, Stock = 300,  CreatedDate = DateTime.Now },
                new Product() { Id = 4, CategoryId = 3, Name = "Simyacı", Price = 12, Stock = 400,  CreatedDate = DateTime.Now }
                );
        }
    }
}
