using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Services;
using supermarket.API.Resources;
using supermarket.API.Extensions;

namespace supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class ProductController : Controller {

       private readonly IProductService  _productService;
       private readonly IMapper _mapper;

       public ProductController (IProductService productService, IMapper mapper){
           _productService = productService;
           _mapper = mapper;
       }

       [HttpGet]
       public async Task<IEnumerable<ProductResource>> GetAllAsync ()
       {
           var products = await _productService.ListAsync();
           var result =  _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
           return result;
       }

       [HttpGet("{id}")]
       public async Task<IActionResult> GetProductAsync (int id){
           if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
            
           var product = await _productService.GetAsync(id);
           var productResponse = _mapper.Map<Product, ProductResource>(product.Product);

           return Ok(productResponse);

       }
 }
}