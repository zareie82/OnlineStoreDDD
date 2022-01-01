using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.ProductApplication.Queries.FindById
{
    public class FindProductByIdQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
