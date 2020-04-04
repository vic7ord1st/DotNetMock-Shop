using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Repositories;
using supermarket.API.Persistence.Contexts;

namespace supermarket.API.Persistence.Repositories {
   public class ProductRepository : BaseRepository, IProductRepository {
       public ProductRepository (AppDbContext context): base(context){}

       public async Task<IEnumerable<Product>> ListAsync (){
           return await _context.products.ToListAsync();
       }
    }
}

