using AutoMapper;
using OnlineStore.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.ProductApplication
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
