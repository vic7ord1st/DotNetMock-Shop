using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using mockshop.API.Domain.Models;
using mockshop.API.Domain.Services;
using mockshop.API.Resources;
using mockshop.API.Extensions;

namespace mockshop.API.Controllers
{
    [Route("/api/[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
        {
            var products = await _productService.ListAsync();
            var result = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = await _productService.GetAsync(id);
            if (!product._success)
                return BadRequest(product._message);

            var productResponse = _mapper.Map<Product, ProductResource>(product.Product);
            return Ok(productResponse);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.SaveAsync(product);

            if(!result._success)
                return BadRequest(ModelState.GetErrorMessages());
            
            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }
    }
}