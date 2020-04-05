using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mockshop.API.Domain.Models;
using mockshop.API.Domain.Services;
using mockshop.API.Domain.Repositories;
using mockshop.API.Domain.Services.Communication;

namespace mockshop.API.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<ProductResponse> GetAsync(int id)
        {
            var product = await _productRepository.FindByIdAsync(id);

            if (product == null)
                return new ProductResponse($"Can't find product with id : {id}");

            try
            {
                return new ProductResponse(product);
            }
            catch (Exception exception)
            {
                return new ProductResponse($"an error occured: {exception}");
            }
        }
        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception exception)
            {
                return new ProductResponse($"An error occured with the request: {exception}");
            }
        }
    }
}