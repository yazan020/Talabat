using TalabatApi.Persistence.Context;

namespace TalabatApi.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        public readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            this._context = context;
        }
    }
}