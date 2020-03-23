using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Services;
using supermarket.API.Domain.Repositories;

namespace supermarket.API.Services
{
 public class CategoryService: ICategoryService  {

     private readonly ICategoryRepository _categoryRepository;
     public CategoryService (ICategoryRepository categoryRepository){
         _categoryRepository = categoryRepository;
     }
     public async Task<IEnumerable<Category>> ListCategoriesAsync() {
         return await _categoryRepository.ListAsync();
     }
 }
}