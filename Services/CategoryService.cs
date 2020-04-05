using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mockshop.API.Domain.Models;
using mockshop.API.Domain.Services;
using mockshop.API.Domain.Repositories;
using mockshop.API.Domain.Services.Communication;

namespace mockshop.API.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch (Exception exception)
            {
                return new CategoryResponse($"an error occured: {exception.Message}");
            }

        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var prevCategory = await _categoryRepository.FindByIdAsync(id);

            if (prevCategory == null)
                return new CategoryResponse($"Category with id: {id} not found");
 
            prevCategory.name = category.name;
            try
            {
                _categoryRepository.Update(prevCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(prevCategory);

            }
            catch (Exception exception)
            {
                return new CategoryResponse($"An error occured when updating category: {exception.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id){
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if(existingCategory == null)
                return new CategoryResponse($"Category with id: {id} not found");

            try{
                _categoryRepository.Delete(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse($"{existingCategory.name} deleted from database");
            }
            catch(Exception exception){
                return new CategoryResponse($"An error occured when deleting category: {exception.Message}");
            }
        }
    }
}