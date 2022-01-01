using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Product;
using OnlineStore.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.ProductApplication.Queries.FetchAll
{
    public class FetchAllProductQueryHandler : IRequestHandler<FetchAllProductQuery, IList<ProductDto>>
    {
        private readonly StoreDBContext _context;
        private readonly IMapper _mapper;
        public FetchAllProductQueryHandler( StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<ProductDto>> Handle(FetchAllProductQuery request, CancellationToken cancellationToken)
        {
            var productList = await _context.Products.ToListAsync();
            return productList.Select(_mapper.Map<Product, ProductDto>).ToList();
        }
    }
}
