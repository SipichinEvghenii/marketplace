using System;
using System.Security.Cryptography;
using Marketplace.Application.Interfaces;

namespace Marketplace.Application.Services
{
    // Сервис для хэширования паролей
    public class PasswordHasher : IPasswordHasher
    {
        // Метод для генерации случайной соли
        public byte[] GenerateSalt()
        {
            // Генерируем случайную последовательность байтов для соли
            var salt = new byte[128 / 8];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        // Метод для хэширования пароля с использованием соли
        public string HashPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(256 / 8); // Размер выходного хэша в байтах
                return Convert.ToBase64String(hash);
            }
        }

        // Метод для проверки пароля
        public bool VerifyPassword(string hashedPassword, string password, byte[] salt)
        {
            // Хэшируем введенный пароль и сравниваем его с сохраненным хэшем
            var hashed = HashPassword(password, salt);
            return hashedPassword == hashed;
        }
    }
}