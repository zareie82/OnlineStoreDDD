using OnlineStore.Domain.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Service.OrderService
{
    public interface IOrderSetvice
    {
        Task Create(OrderDto order);
        Task<OrderDto> FindById(Guid id);
        Task<IList<OrderDto>> FetchAll();
        Task Update(OrderDto order);
    }
}
