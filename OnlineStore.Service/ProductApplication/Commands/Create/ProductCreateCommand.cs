using MediatR;
using OnlineStore.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.ProductApplication.Commands.Create
{
    public class ProductCreateCommand :IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Profit { get; set; }
        public ProductType Type { get; set; }
    }
}
