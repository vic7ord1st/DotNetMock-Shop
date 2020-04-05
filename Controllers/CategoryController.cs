using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using mockshop.API.Domain.Models;
using Microsoft.Extensions.Logging;
using mockshop.API.Domain.Services;
using mockshop.API.Resources;
using mockshop.API.Extensions;

namespace mockshop.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public CategoryController(ICategoryService categoryService, IMapper mapper, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);
            _logger.LogInformation($"This is the result for post {result}");

            if (!result._success)
                return BadRequest(result._message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync (int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var category = _mapper.Map<SaveCategoryResource, Category> (resource);
            var result = await _categoryService.UpdateAsync(id, category);
            _logger.LogInformation($"This is the result for put {result}");
            if(!result._success)
                return BadRequest(result._message);

            var categoryResource = _mapper.Map<Category, CategoryResource> (result.Category);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync (int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if(!result._success)
                return BadRequest(result._message);
            
            var categoryResource = _mapper.Map<Category, CategoryResource> (result.Category);
            return Ok(categoryResource);

        }
    }
}