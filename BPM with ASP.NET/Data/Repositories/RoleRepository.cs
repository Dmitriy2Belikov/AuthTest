using BPM_with_ASP.NET.Data.Models;
using BPM_with_ASP.NET.Data.Repositories.Interfaces;
using BPM_with_ASP.NET.Data.Repositories.ModelRepository;
using LibraryTest.NET.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPM_with_ASP.NET.Data.Repositories
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
