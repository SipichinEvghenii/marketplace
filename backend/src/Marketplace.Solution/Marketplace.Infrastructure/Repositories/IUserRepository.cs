using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Domain.Entities;

namespace Marketplace.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<List<Role>> GetAllRoles();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(string id);
        Task AddAsync(User user);
        Task<Role> GetRoleByName(string roleName);
        Task<string> AddRole(string userRole);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(string id);
    }
}