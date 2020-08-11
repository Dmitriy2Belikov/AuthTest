using LibraryTest.NET.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTest.NET.Services.Interfaces
{
    public interface IRoleService
    {
        void Add(Role role);
        Role Get(Guid id);
        Role Get(string name);
        IEnumerable<Role> GetAll();
        void Update(Role updatedRole);
        void Remove(Guid id);
        void RemoveRange(IEnumerable<Role> roles);
    }
}
