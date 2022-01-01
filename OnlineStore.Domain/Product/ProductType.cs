using OnlineStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Product
{
    
    public class ProductType : Enumeration
    {
        public static ProductType Normal = new(1, nameof(Normal));
        public static ProductType Breakable = new(2, nameof(Breakable));

        public ProductType(int id, string name)
        : base(id, name)
        {
        }
    }
}
