using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Services.Communication;

namespace supermarket.API.Domain.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ListAsync();
         Task<CategoryResponse> SaveAsync(Category category);

         Task<CategoryResponse> UpdateAsync(int id, Category category);

         Task<CategoryResponse> DeleteAsync(int id);
    }
}