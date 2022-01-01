using OnlineStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Product
{
    public class Product
    {
        private Product() { }
        public Product(string name, string description, Money price, ProductType type)
        {
            Name = name;
            Description = description;
            Price = price;
            Type = type;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        
        public ProductType Type { get; set; }
    }
}
