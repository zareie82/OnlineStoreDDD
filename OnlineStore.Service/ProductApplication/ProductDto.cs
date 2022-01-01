using OnlineStore.Domain.Common;
using OnlineStore.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.ProductApplication
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Money Price { get; set; }
        public ProductType Type { get; set; }
    }
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Money Price { get; set; }
        public ProductType Type { get; set; }
    }
}
