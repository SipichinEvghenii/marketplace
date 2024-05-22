using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Marketplace.Application.Interfaces;
using Marketplace.Application.Services;
using Marketplace.Domain.Entities;
using Marketplace.Domain.ViewModels;
using Marketplace.Infrastructure.Repositories;

namespace Marketplace.Web.Controllers
{
    /// <summary>
    /// Контроллер для управления учетными записями пользователей.
    /// </summary>
    public class AccountController : Controller
    {
        private static readonly MarketplaceContext _context = new MarketplaceContext();
        private static readonly IPasswordHasher _passwordHasher = new PasswordHasher();
        private static readonly IUserRepository _userRepository = new UserRepository(_context);
        private readonly IAuthService _authService = new AuthService(_userRepository, _passwordHasher);

        /// <summary>
        /// Возвращает представление для регистрации нового пользователя.
        /// </summary>
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Регистрирует нового пользователя.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            // Регистрация нового пользователя
            var user = await _authService.RegisterUserAsync(model.Email, model.Password);
            if (user != null)
            {
                // Автоматически входит пользователя после успешной регистрации
                SignInUser(user);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Ошибка при регистрации пользователя");
            return View(model);
        }

        /// <summary>
        /// Возвращает представление для входа пользователя.
        /// </summary>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Входит пользователя в систему.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            // Проверка подлинности пользователя
            var user = await _authService.ValidateUserAsync(model.Email, model.Password);
            if (user != null)
            {
                // Автоматически входит пользователя после успешной аутентификации
                SignInUser(user);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Неверная попытка входа");
            return View(model);
        }

        /// <summary>
        /// Входит пользователя в систему с использованием аутентификации cookie.
        /// </summary>
        private void SignInUser(User user)
        {
            var roles = string.IsNullOrEmpty(user.Role.Name) ? new string[] { } : new[] { user.Role.Name };

            var ticket = new FormsAuthenticationTicket(
                1,
                user.Email,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                false,
                string.Join(",", roles),
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Выходит пользователя из системы.
        /// </summary>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
