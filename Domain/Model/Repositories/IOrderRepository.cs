using System.Collections.Generic;
using System.Threading.Tasks;

namespace TalabatApi.Domain.Model.Repositories
{
    public interface IOrderRepository
    {

        Task<Order> GetOrderById(int id);
        Task<List<Order>> GetOrdersByUser(int UserId);
        Task<List<Order>> GetOrders();
        Task AddOrder(Order order);
        void UpdateOrder(Order order);
        void CancelOrder(Order order);
    }
}