using System.Threading.Tasks;
using TalabatApi.Domain.Model.Dtos;

namespace TalabatApi.Domain.Model.Repositories
{
    public interface IAuthRepo
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string name);
        Task RegisterUser(User user); 
        Task AddUserInfo(UserData data);
        void DeleteUserInfo(UserData data);
        void UpdateUserInfo(UserData data);
    }
} 