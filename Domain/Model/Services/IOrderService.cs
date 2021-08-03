using System.Collections.Generic;
using System.Threading.Tasks;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Domain.Model.Services
{
    public interface IOrderService
    {
        Task<Response<Order>> GetOrderById(int id);
        Task<Response<List<Order>>> GetOrdersByUser(int UserId);
        Task<Response<List<Order>>> GetOrders();
        Task<Response<Order>> AddOrder(Order order);
        Task<Response<Order>> UpdateOrder(Order order);
        Task<Response<List<Order>>> CancelOrder(Order order);
    }
}