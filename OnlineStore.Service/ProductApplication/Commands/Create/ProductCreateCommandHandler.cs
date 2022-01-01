using MediatR;
using OnlineStore.Domain.Common;
using OnlineStore.Domain.Product;
using OnlineStore.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.ProductApplication.Commands.Create
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Guid>
    {
        private readonly StoreDBContext _context;
        public ProductCreateCommandHandler(StoreDBContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var validator = new ProductCreateCommandValidator();
            var check =  validator.Validate(request);
            if(check.IsValid)
            {
                var product = new Product(request.Name, request.Description, new Money(request.Price), request.Type);
                
                var result = _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return result.Entity.Id;
            }
            else
            {
                throw new Exception("Product is not valid");
            }

          
            
        }
    }
}
