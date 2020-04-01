using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using supermarket.API.Domain.Models;
using supermarket.API.Domain.Repositories;
using supermarket.API.Persistence.Contexts;

namespace supermarket.API.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _context.categories.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
           return await _context.categories.FindAsync(id);
        }

        public void Update(Category category){
            _context.categories.Update(category);
        }

        public void Delete(Category category){
            _context.categories.Remove(category);
        }
    }
}

