using System.Threading.Tasks;
using Marketplace.Application.Interfaces;
using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Repositories; // Добавляем директиву для работы с асинхронностью

namespace Marketplace.Application.Services
{
    /// <summary>
    ///     Сервис для аутентификации пользователей и регистрации новых пользователей.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> ValidateUserAsync(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null) return null;

            var commandResult = _passwordHasher.VerifyPassword(user.PasswordHash, password, user.PasswordSalt);

            if (commandResult) return user;

            return null;
        }

        public async Task<User> RegisterUserAsync(string email, string password)
        {
            var existingUser = _userRepository.GetUserByEmail(email);
            if (existingUser != null) return null;

            var role = _userRepository.GetRoleByName(Constants.UserRole);
            if (role == null)
            {
                var roleId = _userRepository.AddRole(Constants.UserRole);
                role = new Role { RoleId = roleId, Name = Constants.UserRole };
            }

            var salt = _passwordHasher.GenerateSalt();
            var hash = _passwordHasher.HashPassword(password, salt);

            var user = new User
            {
                Email = email,
                Username = email.Split('@')[0],
                PasswordSalt = salt,
                PasswordHash = hash,
                RoleId = role.RoleId
            };

            _userRepository.AddUser(user);

            return user;
        }

        public async Task<User> RegisterUserAsync(string email, string password, string roleId)
        {
            var existingUser = _userRepository.GetUserByEmail(email);
            if (existingUser != null) return null;

            var salt = _passwordHasher.GenerateSalt();
            var hash = _passwordHasher.HashPassword(password, salt);

            var user = new User
            {
                Email = email,
                Username = email.Split('@')[0],
                PasswordSalt = salt,
                PasswordHash = hash,
                RoleId = roleId
            };

            _userRepository.AddUser(user);

            return user;
        }
    }
}
