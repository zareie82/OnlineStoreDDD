using MediatR;
using OnlineStore.Application.Common;
using OnlineStore.Domain.Common;
using OnlineStore.Domain.Order;
using OnlineStore.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.OrderApplication.Command.Create
{
    public class OrderCreateCommandHandler :
        IRequestHandler<OrderCreateCommand, OperationResult<OrderCreateCommandResult>>
    {
        private readonly StoreDBContext _context;
        private readonly IMediator _mediator;

        public OrderCreateCommandHandler(StoreDBContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<OperationResult<OrderCreateCommandResult>> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            OperationResult<OrderCreateCommandResult> result;
            var order = new Order(request.UserId, request.Discount, request.DiscountType);

            if (!order.IsOrderTime())
            {
                result = OperationResult<OrderCreateCommandResult>
                    .BuildFailure(new Exception("Please Try again in 8am to 7pm"));
            }
            else
            {


                order.Items = new List<OrderItem>();
                _context.Orders.Add(order);
                var products = _context.Products.ToList();

                foreach (var item in request.Items)
                {
                    var product = products.Single(f => f.Id == item.ProductId);
                    if(product.Type.Id == 2)
                    {
                        order.ShippingType = ShippingType.Express;
                    }
                    order.Items.Add(new OrderItem
                    {
                        ProductId = item.ProductId,
                        Count = item.Count,
                        OrderId = order.Id,
                        Profit = item.Profit,
                        UnitPrice = product.Price + item.Profit,
                        TotalPrice = new Money((product.Price + item.Profit).Value * item.Count)
                    });
                }

            }
            

            order.TotalPrice = new Money(_context.OrderItems.Where(w => w.OrderId == order.Id).Sum(s => s.TotalPrice.Value));
            if (order.IsPosible)
            {
                _context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                await _context.SaveChangesAsync();

                result = OperationResult<OrderCreateCommandResult>
                   .BuildSuccessResult(new OrderCreateCommandResult
                   {
                       OrderId = order.Id
                   });
                await Task.CompletedTask;
            }
            else
            {
                result = OperationResult<OrderCreateCommandResult>
                    .BuildFailure(new Exception("Order Amount sould be more than 50000"));
            }
            return result;

        }
    }
}
