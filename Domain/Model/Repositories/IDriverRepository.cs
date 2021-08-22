using System.Threading.Tasks;

namespace TalabatApi.Domain.Model.Repositories
{
    public interface IDriverRepository
    {
        Task<Driver> GetDriverById(int id);
        Task AssignDriver(Driver driver);
        void DisapproveDriver(Driver driver);
        void UpdateDriverLocation(Driver driver);
    }
}