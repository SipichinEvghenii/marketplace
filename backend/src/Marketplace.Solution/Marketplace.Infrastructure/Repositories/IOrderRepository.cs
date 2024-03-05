using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Domain.Entities;

namespace Marketplace.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(string id);
        Task<Order> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(string id);
        Task<Order> CreateOrderAsync(Order order);
    }
}