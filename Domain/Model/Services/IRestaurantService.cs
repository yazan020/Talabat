using System.Collections.Generic;
using System.Threading.Tasks;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Domain.Model.Services
{
    public interface IRestaurantService
    {
        Task<Response<Restuarant>> GetRestById(int id);
        Task<Response<IEnumerable<Restuarant>>> GetRests();
        Task<Response<IEnumerable<Restuarant>>> SaveRest(Restuarant restuarant);
        Task<Response<Restuarant>> UpdateRest(int Id, Restuarant restuarant);
        Task<Response<IEnumerable<Restuarant>>> DeleteRest(int Id);
    }
}