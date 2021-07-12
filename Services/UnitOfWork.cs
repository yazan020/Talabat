using System.Threading.Tasks;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Persistence.Context;
using TalabatApi.Persistence.Repositories;

namespace TalabatApi.Services
{
    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
        public UnitOfWork(DataContext context) : base(context)
        {
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}