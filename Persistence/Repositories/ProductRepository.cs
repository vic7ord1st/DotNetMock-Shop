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
           return await _context.products.Include(p => p.category).ToListAsync();
       }

       public async Task AddAsync(Product product){
           await _context.products.AddAsync(product);
       }

       public async Task<Product>  FindByIdAsync(int id){
           return await _context.products.FindAsync(id);
       }
    }
}

