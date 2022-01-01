using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.OrderService
{
    public class OrderService : IOrderSetvice
    {
        public Task Create(OrderDto order)
        {
            throw new NotImplementedException();
        }

        public Task<IList<OrderDto>> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(OrderDto order)
        {
            throw new NotImplementedException();
        }
    }
}
