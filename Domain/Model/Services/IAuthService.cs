using System.Threading.Tasks;
using TalabatApi.Domain.Model.Dtos;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Domain.Model.Services
{
    public interface IAuthService
    {
        Task<Response<User>> RegisterUser(User user, string Password);
        Task<Response<User>> LoginUser(User user, string password);
        Task<Response<User>> SeeUserData(int userId);
        Task<Response<UserData>> AddUserDataInfo(UserData userData);
        Task<Response<UserData>> UpdateUserDataInfo(UserData userData);
        Task<Response<UserData>> DeleteUserDataInfo(UserData userData);
    }
} 