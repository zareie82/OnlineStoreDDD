using OnlineStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Order
{
    public enum ShippingType
    {
        Normal = 0,
        Express
    }
    //    public class ShippingType : Enumeration
    //    {
    //        public static ShippingType Normal = new(1, nameof(Normal));
    //        public static ShippingType Express = new(2, nameof(Express));

    //        public ShippingType(int id, string name)
    //        : base(id, name)
    //        {
    //        }
    //    }
}
