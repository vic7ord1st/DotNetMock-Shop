using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;

namespace supermarket.API.Domain.Repositories
{
 public interface IProductRepository {
     Task<IEnumerable<Product>> ListAsync();
     Task AddAsync(Product product);
     Task<Product> FindByIdAsync(int id);
    //  void Update(Product product);

    //  void Delete(Product product);

 }
}