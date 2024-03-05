using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Domain.Entities;

namespace Marketplace.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        List<Role> GetAllRoles();
        User GetUserByEmail(string email);
        User GetUserById(string id);
        void AddUser(User user);
        Role GetRoleByName(string roleName);
        string AddRole(string userRole);
        void UpdateUser(User user);
        void DeleteUser(string id);
    }
}