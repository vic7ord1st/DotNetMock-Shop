using System.Threading.Tasks;
using mockshop.API.Domain.Repositories;
using mockshop.API.Persistence.Contexts;

namespace mockshop.API.Persistence.Repositories {
    public class UnitOfWork: IUnitOfWork {
        private readonly AppDbContext _context;

        public UnitOfWork (AppDbContext context){
            _context = context;
        }

        public async Task CompleteAsync(){
            await _context.SaveChangesAsync();
        }
    }
}