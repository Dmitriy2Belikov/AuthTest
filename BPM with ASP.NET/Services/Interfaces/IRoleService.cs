using BPM_with_ASP.NET.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPM_with_ASP.NET.Services.Interfaces
{
    public interface IRoleService
    {
        void Add(Role role);
        Role Get(Guid id);
        Role Get(string name);
        void Update(Role updatedRole);
        void Remove(Guid id);
        void RemoveRange(IEnumerable<Role> roles);
    }
}
