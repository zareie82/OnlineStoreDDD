using MediatR;
using OnlineStore.Application.Common;
using OnlineStore.Domain.Common;
using OnlineStore.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.OrderApplication.Command.Create
{
    public class OrderCreateCommand : IRequest<OperationResult<OrderCreateCommandResult>>
    {
        public string UserId { get; set; }
        public Money Discount { get; set; }
        public DiscountType DiscountType { get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }
}
