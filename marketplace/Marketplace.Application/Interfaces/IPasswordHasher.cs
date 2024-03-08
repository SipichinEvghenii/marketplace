using System;

namespace Marketplace.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string password, byte[] salt);
        bool VerifyPassword(string hashedPassword, string password, byte[] salt);
        byte[] GenerateSalt();
    }
}