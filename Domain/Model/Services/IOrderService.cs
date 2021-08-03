using System.Collections.Generic;
using System.Threading.Tasks;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Domain.Model.Services
{
    public interface IOrderService
    {
        Task<Response<Orders>> GetOrderById(int id);
        Task<Response<List<Orders>>> GetOrdersByUser(int UserId);
        Task<Response<List<Orders>>> GetOrders();
    }
}