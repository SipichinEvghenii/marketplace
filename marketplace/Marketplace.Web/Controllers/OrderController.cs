using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Repositories;

namespace Marketplace.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public OrderController(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        // Отображает список всех заказов
        public ActionResult Index()
        {
            // Получаем все заказы синхронно
            var orders = _orderRepository.GetAllOrders();
            return View(orders);
        }

        // Отображает форму для создания нового заказа
        [HttpGet]
        public ActionResult Create()
        {
            // Получаем всех пользователей синхронно
            var users = _userRepository.GetAllUsers();
            ViewBag.Users = users;

            return View();
        }

        // Обрабатывает отправку формы для создания нового заказа
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            // Устанавливаем ID и дату заказа
            order.OrderId = Guid.NewGuid().ToString();
            order.OrderDate = DateTime.UtcNow;

            // Создаем заказ синхронно
            _orderRepository.CreateOrder(order);
            return RedirectToAction(nameof(Index));
        }

        // Отображает форму для редактирования существующего заказа
        [HttpGet]
        public ActionResult Edit(string id)
        {
            // Получаем заказ синхронно
            var order = _orderRepository.GetOrderById(id);

            // Если заказ не найден, возвращаем ошибку 404
            if (order == null) return HttpNotFound();

            return View(order);
        }

        // Обрабатывает отправку формы для редактирования заказа
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Order order)
        {
            try
            {
                // Устанавливаем дату заказа и обновляем заказ
                order.OrderDate = DateTime.UtcNow;
                _orderRepository.UpdateOrder(order);
            }
            catch (Exception)
            {
                // В случае ошибки конфликта параллелизма, возвращаем ошибку 404
                if (!OrderExists(order.OrderId)) return HttpNotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // Отображает форму для подтверждения удаления заказа
        [HttpGet]
        public ActionResult Delete(string id)
        {
            // Получаем заказ синхронно
            var order = _orderRepository.GetOrderById(id);

            // Если заказ не найден, возвращаем ошибку 404
            if (order == null) return HttpNotFound();

            return View(order);
        }

        // Обрабатывает подтверждение удаления заказа
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            // Удаляем заказ
            _orderRepository.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }

        // Проверяет существование заказа по его ID
        private bool OrderExists(string id)
        {
            var order = _orderRepository.GetOrderById(id);
            return order != null;
        }
    }
}
