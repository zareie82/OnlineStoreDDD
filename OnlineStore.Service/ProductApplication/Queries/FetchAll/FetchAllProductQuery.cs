using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.ProductApplication.Queries.FetchAll
{
    public class FetchAllProductQuery :IRequest<IList<ProductDto>>
    {
    }
}
