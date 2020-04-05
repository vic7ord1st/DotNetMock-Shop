using System.Collections.Generic;
using System.Threading.Tasks;
using mockshop.API.Domain.Models;
using mockshop.API.Domain.Services.Communication;

namespace mockshop.API.Domain.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ListAsync();
         Task<CategoryResponse> SaveAsync(Category category);

         Task<CategoryResponse> UpdateAsync(int id, Category category);

         Task<CategoryResponse> DeleteAsync(int id);
    }
}