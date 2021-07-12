using System.Threading.Tasks;

namespace TalabatApi.Domain.Model.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}