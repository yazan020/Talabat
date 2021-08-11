using System.Threading.Tasks;

namespace TalabatApi.Domain.Model.Repositories
{
    public interface IDriverRepository
    {
        Task AssignDriver(Driver driver);
    }
}