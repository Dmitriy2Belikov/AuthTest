using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LibraryTest.NET.Services
{
    public static class Helpers
    {
        public static string HashPassword(string password)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(password);

            return hashed;
        }

        public static bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
