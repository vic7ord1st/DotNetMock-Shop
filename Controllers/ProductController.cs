using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Services;

namespace supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class ProductController : Controller {

       private readonly IListService<Product>  _productService;

       public ProductController (IListService<Product> productService){
           _productService = productService;
       }

       [HttpGet]
       public async Task<IEnumerable<Product>> GetAllAsync ()
       {
           var products = await _productService.ListAsync();
           return products;
       }
 }
}