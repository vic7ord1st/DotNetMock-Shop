using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Services.Communication;

namespace supermarket.API.Domain.Services
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