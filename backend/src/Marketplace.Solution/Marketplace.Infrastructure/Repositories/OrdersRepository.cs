using System.Collections.Generic;
using System.Data;
using System.Data.Entity; // Импорт EntityFramework
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Repositories;

// Репозиторий для работы с заказами
public class OrdersRepository : IOrderRepository
{
    private readonly MarketplaceContext _context;

    // Конструктор, принимающий контекст базы данных
    public OrdersRepository(MarketplaceContext context)
    {
        _context = context;
    }

    // Получить список всех заказов с информацией о пользователях
    public List<Order> GetAllOrders()
    {
        // Используем синхронный метод ToList вместо асинхронного ToListAsync
        return _context.Orders
            .Include(o => o.User)
            .ToList();
    }

    // Получить заказ по его идентификатору с информацией о пользователе
    public Order GetOrderById(string id)
    {
        // Используем синхронный метод FirstOrDefault вместо асинхронного FirstOrDefaultAsync
        return _context.Orders
            .Include(o => o.User)
            .FirstOrDefault(o => o.OrderId == id);
    }

    // Обновить информацию о заказе
    public Order UpdateOrder(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        // Используем синхронный метод SaveChanges вместо асинхронного SaveChangesAsync
        _context.SaveChanges();
        return order;
    }

    // Удалить заказ
    public void DeleteOrder(string id)
    {
        var order = _context.Orders.Find(id); // Используем синхронный метод Find
        if (order != null)
        {
            _context.Orders.Remove(order);
            // Используем синхронный метод SaveChanges вместо асинхронного SaveChangesAsync
            _context.SaveChanges();
        }
    }

    // Создать новый заказ
    public Order CreateOrder(Order order)
    {
        _context.Orders.Add(order); // Используем синхронный метод Add
        // Используем синхронный метод SaveChanges вместо асинхронного SaveChangesAsync
        _context.SaveChanges();

        return order;
    }
}
