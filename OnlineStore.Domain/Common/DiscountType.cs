using OnlineStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Common
{
    public class DiscountType : Enumeration
    {

        public static DiscountType Const = new(1, nameof(Const));
        public static DiscountType Percent = new(2, nameof(Percent));

        public DiscountType(int id, string name)
        : base(id, name)
        {
        }

    }
}
