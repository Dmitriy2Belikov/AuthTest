using LibraryTest.NET.Data.Models;
using LibraryTest.NET.Data.Repositories.ModelRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTest.NET.Data.Repositories.Interfaces
{
    public interface IUserRepository : IModelRepository<User>
    {
        User Get(string email);
        IEnumerable<Role> GetUserRoles(Guid id);
    }
}
