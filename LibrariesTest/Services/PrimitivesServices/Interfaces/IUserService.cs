using LibraryTest.NET.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTest.NET.Services.Interfaces
{
    public interface IUserService
    {
        void Add(User user, IEnumerable<Role> roles);
        User Get(Guid id);
        User Get(string email);
        IEnumerable<User> GetAll();
        void Update(User updatedUser, IEnumerable<Role> roles);
        void RemoveUserRoles(Guid id);
        void Remove(Guid id);
        void RemoveRange(IEnumerable<User> users);
        IEnumerable<Role> GetUserRoles(Guid id);
    }
}
