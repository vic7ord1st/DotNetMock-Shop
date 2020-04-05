using System.Collections.Generic;
using System.Threading.Tasks;
using mockshop.API.Domain.Models;
using mockshop.API.Domain.Services.Communication;

namespace mockshop.API.Domain.Services
{
    public interface IProductService
    {
         Task<IEnumerable<Product>> ListAsync();
         Task<ProductResponse> GetAsync(int id);
         Task<ProductResponse> SaveAsync(Product product);

        //  Task<ProductResponse> UpdateAsync(int id, Product product);

        //  Task<ProductResponse> DeleteAsync(int id);
    }
}