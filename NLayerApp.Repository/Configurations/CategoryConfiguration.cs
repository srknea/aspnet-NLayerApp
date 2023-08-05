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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Fluent API
            builder.HasKey(x => x.Id); //public int Id { get; set; } KEY olarak ayarlandı. (Default)
            builder.Property(x => x.Id).UseIdentityColumn(); //Id alanı IdentityColumn olarak ayarlandı. Id birer birer artacak. (Default)
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); //Name alanı zorunlu ve max 50 karakter olacak.
            builder.ToTable("Categories"); // public DbSet<Category> Categories { get; set; } Tablo adı Categories olarak ayarlandı. (Default)
        }
    }
}
