using AutoMapper;
using MediatR;
using OnlineStore.Domain.Product;
using OnlineStore.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.ProductApplication.Queries.FindById
{
    public class FindProductByIdQueryHandler : IRequestHandler<FindProductByIdQuery, ProductDto>
    {
        private readonly StoreDBContext _context;
        private readonly IMapper _mapper;
        public FindProductByIdQueryHandler(StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(FindProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
