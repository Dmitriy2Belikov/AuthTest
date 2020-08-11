using LibraryTest.NET.Data.Models;
using LibraryTest.NET.Data.Repositories.Interfaces;
using LibraryTest.NET.Data.Repositories.ModelRepository;
using LibraryTest.NET.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTest.NET.Data.Repositories
{
    public class UserRepository : ModelRepository<User>, IUserRepository
    {
        private UserDbContext _context;

        public UserRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public User Get(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            return user;
        }

        public IEnumerable<Role> GetUserRoles(Guid id)
        {
            var roles = _context.UserRoles
                .Include(u => u.User)
                .Include(r => r.Role)
                .Where(u => u.User.Id == id)
                .Select(r => r.Role);

            return roles;
        }
    }
}
