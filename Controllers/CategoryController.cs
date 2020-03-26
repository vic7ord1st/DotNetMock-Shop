using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Services;

namespace supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoryController : Controller {

       private readonly IListService<Category>  _categoryService;

       public CategoryController (IListService<Category> categoryService){
           _categoryService = categoryService;
       }

       [HttpGet]
       public async Task<IEnumerable<Category>> GetAllAsync ()
       {
           var categories = await _categoryService.ListAsync();
           return categories;
       }
 }
}