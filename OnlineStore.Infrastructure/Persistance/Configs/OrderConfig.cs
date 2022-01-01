using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Common;
using OnlineStore.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.Persistance.Configs
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(f => f.Discount);
            builder.OwnsOne(f => f.TotalPrice);
            builder.OwnsOne(f => f.PayableAmount);

            builder.Property(f => f.DiscountType)
                .HasColumnName("Type")
                .HasConversion(f => f.Id,
                discountTypeId => DiscountType.GetAll<DiscountType>().Single(s => s.Id == discountTypeId));
            //builder.Property(f => f.ShippingType)
            //    .HasColumnName("Type")
            //    .HasConversion(f => f.Id,
            //    shippingTypeId => ShippingType.GetAll<ShippingType>().Single(s => s.Id == shippingTypeId));
        }
    }
}
