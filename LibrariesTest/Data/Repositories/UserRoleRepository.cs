using LibraryTest.NET.Data.Models;
using LibraryTest.NET.Data.Repositories.Interfaces;
using LibraryTest.NET.Data.Repositories.ModelRepository;
using LibraryTest.NET.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTest.NET.Data.Repositories
{
    public class UserRoleRepository : ModelRepository<UserRole>, IUserRoleRepository
    {
        private UserDbContext _context;

        public UserRoleRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
