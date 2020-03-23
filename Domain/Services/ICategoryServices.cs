using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;

namespace supermarket.API.Domain.Services
{
 public interface ICategoryService {
     Task<IEnumerable<Category>> ListCategoriesAsync();
 }
}