using OnlineStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Order.Spec
{
    class IsItPossibleToOrderInThisTime : Specification<Order>
    {
        public override Expression<Func<Order, bool>> ToExpression()
        {
            return order=>DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 19;
        }
    }
}
