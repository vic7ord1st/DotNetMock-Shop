using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;

namespace supermarket.API.Domain.Repositories
{
 public interface IProductRepository {
     Task<IEnumerable<Product>> ListAsync();
    //  Task AddAsync(Category category);
    //  Task<Category> FindByIdAsync(int id);
    //  void Update(Category category);

    //  void Delete(Category category);

 }
}