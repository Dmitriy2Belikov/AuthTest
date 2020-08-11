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
    public class RoleRepository : ModelRepository<Role>, IRoleRepository
    {
        private UserDbContext _context;

        public RoleRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public Role Get(string name)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name == name);

            return role;
        }
    }
}
