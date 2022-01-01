using OnlineStore.Domain.Common;
using OnlineStore.Domain.Order.Spec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Order
{
    public class Order
    {
        private Order() { }
        public Order(string user, Money discount,  DiscountType type)
        {
            UserId = user;
            TimeCreated = DateTime.Now;
            Discount = discount;
            DiscountType = type;
            IsPosible = UpdateIsPosible();
            PayableAmount = CountPayableAmount(this.TotalPrice,discount,type);
        }

        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime TimeCreated { get; private set; }
        public Money Discount { get; set; }
        public Money TotalPrice { get; set; }
        public DiscountType DiscountType { get; set; }
        public Money PayableAmount { get; set; }
        public ShippingType ShippingType { get; set; }
        public bool IsPosible { get; private set; } //Should be change with time and totaPrice
        public ICollection<OrderItem> Items { get; set; }

        public bool UpdateIsPosible()
        {
            var s1 = new IsItPossibleToOrderInThisTime();
            var s2 = new IsTotalAmountMoreThanMinAmount();
            return s1.And(s2).IsSatisfiedBy(this);
        }

        public bool IsOrderTime()
        {
            return new IsItPossibleToOrderInThisTime().IsSatisfiedBy(this);
        }
        public Money CountPayableAmount(Money totalPrice,Money discount, DiscountType type)
        {
            if(type.Id == 1)
            {
                return totalPrice - discount;
            }
            else
            {
                if(discount.Value > 100)
                {
                    throw new Exception("Discount percentage can not be more than 100");
                }
                else
                {
                    return new Money(totalPrice.Value * (1 - discount.Value / 100));
                }
            }
        }



    }
}
