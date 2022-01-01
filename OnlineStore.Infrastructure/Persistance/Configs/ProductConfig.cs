using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.Persistance.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(f => f.Name).IsUnique();
            builder.Property(f => f.Name).HasMaxLength(25).IsRequired();
            builder.OwnsOne(f => f.Price);

            builder.Property(f => f.Type)
                .HasColumnName("Type")
                .HasConversion(f => f.Id,
                productTypeId => ProductType.GetAll<ProductType>().Single(s => s.Id == productTypeId));
        }
    }
}
