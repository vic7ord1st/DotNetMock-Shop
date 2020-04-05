using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mockshop.API.Domain.Models;
using mockshop.API.Domain.Repositories;
using mockshop.API.Persistence.Contexts;

namespace mockshop.API.Persistence.Repositories {
   public class ProductRepository : BaseRepository, IProductRepository {
       public ProductRepository (AppDbContext context): base(context){}

       public async Task<IEnumerable<Product>> ListAsync (){
           return await _context.products.Include(p => p.category).ToListAsync();
       }

       public async Task AddAsync(Product product){
            await _context.products.AddAsync(product);
       }

       public async Task<Product>  FindByIdAsync(int id){
           return await _context.products.Include(p => p.category).FirstAsync(p => p.id == id);
       }

       public void Update (Product product){
           _context.products.Update(product);
       }
    }
}

