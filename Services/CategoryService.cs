using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Services;
using supermarket.API.Domain.Repositories;

namespace supermarket.API.Services
{
 public class CategoryService: IListService<Category>  {

     private readonly IListRepository <Category> _categoryRepository;
     public CategoryService (IListRepository <Category> categoryRepository){
         _categoryRepository = categoryRepository;
     }
     public async Task<IEnumerable<Category>> ListAsync() {
         return await _categoryRepository.ListAsync();
     }
 }
}