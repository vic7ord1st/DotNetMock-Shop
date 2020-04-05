using System.Collections.Generic;
using System.Threading.Tasks;
using mockshop.API.Domain.Models;

namespace mockshop.API.Domain.Repositories
{
 public interface ICategoryRepository {
     Task<IEnumerable<Category>> ListAsync();
     Task AddAsync(Category category);
     Task<Category> FindByIdAsync(int id);
     void Update(Category category);

     void Delete(Category category);

 }
}