using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /* Burada yapılan ayarlamalar Product Class'ında yapılan ayarlamaları ezer. */
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Fluent API
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); //Name alanı zorunlu ve max 50 karakter olacak.
            builder.Property(x => x.Stock).IsRequired(); //Stock alanı zorunlu olacak.
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)"); //Price alanı zorunlu olacak ve decimal(18,2) olarak ayarlandı.
            // ################.## Toplam 18 karakter olacak ve virgülden sonra 2 karakter olacak.

            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId); //Bir Product'ın bir kategorisi olacak. Bir kategorinin birden fazla ürünü olacak. (Product class'ında zaten ayarladık default olarak EF Core bu satırdaki işi zaten yapacak...)            
            //CategoryId alanı ForeignKey olarak ayarlandı.
        }
    }
}

