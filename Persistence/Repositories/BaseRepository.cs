using supermarket.API.Persistence.Contexts;

namespace supermarket.API.Persistence.Repositories{

    public abstract class BaseRepository{

        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context){
            _context = context;
        }
    }
}