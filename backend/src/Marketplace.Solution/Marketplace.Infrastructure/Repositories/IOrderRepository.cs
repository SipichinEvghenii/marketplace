using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Domain.Entities;

namespace Marketplace.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(string id);
        Order UpdateOrder(Order order);
        void DeleteOrder(string id);
        Order CreateOrder(Order order);
    }
}