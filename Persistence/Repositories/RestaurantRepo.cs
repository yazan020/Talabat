using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Persistence.Context;

namespace TalabatApi.Persistence.Repositories
{
    public class RestaurantRepo : BaseRepository, IRestaurantRepo
    {
        public RestaurantRepo(DataContext context) : base(context)
        {
        }

        public async Task<Restuarant> GetRestById(int id)
        {
            return await _context.Restuarants.Include(p => p.Products).FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<IEnumerable<Restuarant>> GetRest()
        {
            return await _context.Restuarants.Include(p => p.Products).ToListAsync();
        }
        public async Task SaveRest(Restuarant restuarant)
        {
            await _context.Restuarants.AddAsync(restuarant);
        }
        public Task UpdateRest(Restuarant restuarant)
        {
            throw new System.NotImplementedException();
        }
        public Task DeleteRest(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}