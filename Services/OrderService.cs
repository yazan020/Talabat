using System.Collections.Generic;
using System.Threading.Tasks;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Domain.Model.Services;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IUnitOfWork _workUnit;
        public OrderService(IOrderRepository repository, IUnitOfWork workUnit)
        {
            this._workUnit = workUnit;
            this._repository = repository;

        }

        public async Task<Response<Order>> GetOrderById(int id)
        {
            var order = await _repository.GetOrderById(id);

            if (order is null)
                return new Response<Order>("Order Not Found 404");

            return new Response<Order>(order, "Your Order");

        }

        public async Task<Response<List<Order>>> GetOrdersByUser(int UserId)
        {
            var orders = await _repository.GetOrdersByUser(UserId);

            if (orders is null)
                return new Response<List<Order>>("You didn't order anything yet");

            return new Response<List<Order>>
                (orders, $"Orders are listed successfully, You've ordered {orders.Count}");
        }

        public async Task<Response<List<Order>>> GetOrders()
        {
            var order = await _repository.GetOrders();

            if (order is null)
                return new Response<List<Order>>("There is no Orders yet");

            return new Response<List<Order>>(order, "Orders are listed successfully");
        }

        public async Task<Response<Order>> AddOrder(Order order)
        {
            if (order is null)
                return new Response<Order>("Enter your order");

            try
            {
                await _repository.AddOrder(order);
                await _workUnit.SaveAsync();

                return new Response<Order>(order, $"You've ordered from {order.RestName} successfully");
            }
            catch (System.Exception ex)
            {
                return new Response<Order>(ex.Message);
            }
        }

        public Task<Response<Order>> UpdateOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<List<Order>>> CancelOrder(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}