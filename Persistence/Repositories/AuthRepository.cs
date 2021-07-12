using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Persistence.Context;

namespace TalabatApi.Persistence.Repositories
{
    public class AuthRepository : BaseRepository, IAuthRepo
    {
        public AuthRepository(DataContext context) : base(context)
        {
        }

        public async Task<User> GetUserById(int id)
        {
            var existingUser = await _context.Users.FindAsync(id);
            return existingUser;
        }

        public async Task<User> GetUserByName(string name)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(a => a.Name == name);
            return existingUser;
        }


        public async Task RegisterUser(User user)
        {

            await _context.Users.AddAsync(user);
            
        }
    }
}