using OnlineStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Order
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Money Profit { get; set; }
        public int Count { get; set; }
        public Money UnitPrice { get;  set; }
        public Money TotalPrice { get; set; }
    }
}
