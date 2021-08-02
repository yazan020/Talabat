using System.Collections.Generic;
using System.Threading.Tasks;

namespace TalabatApi.Domain.Model.Repositories
{
    public interface IRestaurantRepo
    {
        Task<Restuarant> GetRestById(int id);
        Task<IEnumerable<Restuarant>> GetRest();
        Task SaveRest(Restuarant restuarant);
        Task UpdateRest(Restuarant restuarant);
        Task DeleteRest(int id);
    }
}