using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Services;
using supermarket.API.Domain.Repositories;

namespace supermarket.API.Services
{
 public class ProductService: IProductService  {

     private readonly IProductRepository _productRepository;
     public ProductService (IProductRepository productRepository){
         _productRepository = productRepository;
     }
     public async Task<IEnumerable<Product>> ListAsync() {
         return await _productRepository.ListAsync();
     }
 }
}