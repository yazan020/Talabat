using System.Collections.Generic;
using System.Threading.Tasks;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Domain.Model.Services
{
    public interface IDriverService
    {
        Task<Response<Driver>> AssignDriver(Driver driver);
        Task<Response<Driver>> DisapproveDriver(Driver driver);
        Task<Response<Driver>> UpdateDriverLocation(Driver driver);
    }
}