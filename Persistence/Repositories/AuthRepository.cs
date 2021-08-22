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
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task RegisterUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task AddUserInfo(UserData data)
        {
            await _context.UsersData.AddAsync(data);
        }

        public void UpdateUserInfo(UserData data)
        {
            _context.UsersData.Update(data);
        }

        public void DeleteUserInfo(UserData data)
        {
            _context.UsersData.Remove(data);
        }
    }
}