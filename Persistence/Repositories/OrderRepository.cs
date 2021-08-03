using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Persistence.Context;

namespace TalabatApi.Persistence.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetOrdersByUser(int UserId)
        {
            return await _context.Orders.Where(o => o.Userid == UserId).ToListAsync();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public void CancelOrder(Order order)
        {
            _context.Orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
        }
    }
}