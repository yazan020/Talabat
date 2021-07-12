using System.Threading.Tasks;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Domain.Model.Services
{
    public interface IAuthService
    {
        Task<Response<User>> RegisterUser(User user, string Password);
        Task<Response<User>> LoginUser(User user);
    }
}