using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using Marketplace.Application.Interfaces;
using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Repositories;

namespace Marketplace.Web.Controllers
{
    /// <summary>
    /// Контроллер для управления учетными записями пользователей.
    /// </summary>
    public class UserController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Инициализирует новый экземпляр класса UserController.
        /// </summary>
        /// <param name="userRepository">Репозиторий пользователей.</param>
        /// <param name="authService">Сервис аутентификации.</param>
        public UserController(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        /// <summary>
        /// Отображает список всех пользователей.
        /// </summary>
        /// <returns>Представление списка пользователей.</returns>
        public ActionResult Index()
        {
            var users = _userRepository.GetAllUsers().ToList();
            return View(users);
        }

        /// <summary>
        /// Отображает форму создания нового пользователя.
        /// </summary>
        /// <returns>Представление формы создания нового пользователя.</returns>
        [HttpGet]
        public ActionResult Create()
        {
            var roles = _userRepository.GetAllRoles().ToList();
            ViewBag.Roles = roles;

            return View();
        }

        /// <summary>
        /// Обрабатывает создание нового пользователя.
        /// </summary>
        /// <param name="model">Модель пользователя для создания.</param>
        /// <returns>Редирект на список пользователей.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User model)
        {
            _authService.RegisterUserAsync(model.Email, model.PasswordHash).Wait();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Обрабатывает редактирование пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="user">Модель редактируемого пользователя.</param>
        /// <returns>Редирект на список пользователей.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, User user)
        {
            try
            {
                _userRepository.UpdateUser(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.UserId)) return HttpNotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает форму подтверждения удаления пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Представление формы подтверждения удаления пользователя.</returns>
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null) return HttpNotFound();

            return View(user);
        }

        /// <summary>
        /// Обрабатывает удаление пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Редирект на список пользователей.</returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            _userRepository.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Проверяет существование пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>True, если пользователь существует, иначе - false.</returns>
        private bool UserExists(string id)
        {
            var user = _userRepository.GetUserById(id);
            return user != null;
        }
    }
}
