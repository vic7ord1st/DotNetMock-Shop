using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Services;
using supermarket.API.Domain.Repositories;

namespace supermarket.API.Services
{
 public class ProductService: IListService<Product>  {

     private readonly IListRepository<Product> _productRepository;
     public ProductService (IListRepository<Product> productRepository){
         _productRepository = productRepository;
     }
     public async Task<IEnumerable<Product>> ListAsync() {
         return await _productRepository.ListAsync();
     }
 }
}