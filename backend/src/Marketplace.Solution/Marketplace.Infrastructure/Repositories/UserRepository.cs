using System.Collections.Generic;
using System.Data;
using System.Data.Entity; // Импорт EntityFramework
using System.Linq;
using System;
using System.Threading.Tasks;
using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Repositories;

namespace Marketplace.Infrastructure.Repositories
{
     // Репозиторий для работы с пользователями и ролями
    public class UserRepository : IUserRepository
    {
        private readonly MarketplaceContext _context;

        public UserRepository(MarketplaceContext context)
        {
            _context = context;
        }

        // Получить список всех ролей
        public List<Role> GetAllRoles()
        {
            // Use synchronous ToList instead of ToListAsync
            return _context.Roles.ToList();
        }

        // Получить список всех пользователей с их ролями
        public List<User> GetAllUsers()
        {
            return _context.Users.Include(u => u.Role).ToList();
        }


        // Получить пользователя по email
        public User GetUserByEmail(string email)
        {
            // Use synchronous FirstOrDefault instead of FirstOrDefaultAsync
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email);
        }

        // Получить пользователя по идентификатору
        public User GetUserById(string id)
        {
            // Use synchronous FirstOrDefault instead of FirstOrDefaultAsync
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.UserId == id);
        }

        // Добавить нового пользователя
        public void AddUser(User user)
        {
            user.UserId = Guid.NewGuid().ToString(); // Generate a new identifier
            _context.Users.Add(user);
            _context.SaveChanges(); // Use SaveChanges synchronously
        }

        // Добавить новую роль
        public string AddRole(string roleName)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name == roleName);
            if (role == null)
            {
                role = new Role
                {
                    RoleId = Guid.NewGuid().ToString(),
                    Name = roleName
                };
                _context.Roles.Add(role);
                _context.SaveChanges(); // Save changes synchronously
            }
            return role.RoleId;
        }

        // Обновить информацию о пользователе
        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges(); // Use SaveChanges synchronously
        }

        // Удалить пользователя
        public void DeleteUser(string id)
        {
            var user = _context.Users.Find(id); // Use Find to locate the user synchronously
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges(); // Save changes synchronously
            }
        }

        // Получить роль по имени
        public Role GetRoleByName(string roleName)
        {
            // Use synchronous FirstOrDefault instead of FirstOrDefaultAsync
            return _context.Roles.FirstOrDefault(r => r.Name == roleName);
        }
    }
}