using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Repositories;
using supermarket.API.Persistence.Contexts;

namespace supermarket.API.Persistence.Repositories {
   public class CategoryRepository : BaseRepository, ICategoryRepository {
       public CategoryRepository (AppDbContext context): base(context){}

       public async Task<IEnumerable<Category>> ListAsync (){
           return await _context.categories.ToListAsync();
       }
    }
}

