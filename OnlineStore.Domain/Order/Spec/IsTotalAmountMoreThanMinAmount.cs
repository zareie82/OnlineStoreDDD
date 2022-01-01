using OnlineStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Order.Spec
{
    class IsTotalAmountMoreThanMinAmount : Specification<Order>
    {
        public override Expression<Func<Order, bool>> ToExpression()
        {
            return order => order.TotalPrice.Value >= 50000;
        }
    }
}
