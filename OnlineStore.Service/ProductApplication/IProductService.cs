using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.ProductApplication
{
    public interface IProductService
    {
        Task Create(ProductDto product);
        Task<ProductDto> FindById(Guid id);
        Task<IList<ProductDto>> FetchAll();
        Task Update(ProductDto product);
    }
}
