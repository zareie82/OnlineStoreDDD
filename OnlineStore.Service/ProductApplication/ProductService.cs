using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStore.Domain.Common;
using OnlineStore.Domain.Product;
using OnlineStore.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.ProductApplication
{
    public class ProductService : IProductService
    {
        private readonly StoreDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ProductService(StoreDBContext context, IMapper mapper, ILogger<ProductService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task Create(ProductDto product)
        {
            var model = _mapper.Map<ProductDto, Product>(product);
            _context.Products.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<ProductDto>> FetchAll()
        {
            var model = await _context.Products.ToListAsync();
            return model.Select(_mapper.Map<Product, ProductDto>).ToList();
        }

        public async Task<ProductDto> FindById(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task Update(ProductDto productDto)
        {
            var product = new Product(productDto.Name, productDto.Description, productDto.Price, productDto.Type);
            product.Id = productDto.Id;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Product by Id [{product.Id}] Updated.", product);
        }
    }
}
