using Marketplace.Domain.Entities;
using System.Threading.Tasks;
using System;

namespace Marketplace.Application.Interfaces
{
    public interface IAuthService
    {
        Task<User> ValidateUserAsync(string email, string password);
        Task<User> RegisterUserAsync(string email, string password);
        Task<User> RegisterUserAsync(string email, string password, string roleId);
    }
}