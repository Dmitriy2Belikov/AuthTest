using LibraryTest.NET.Data.Models;
using LibraryTest.NET.Data.Repositories.Interfaces;
using LibraryTest.NET.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTest.NET.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private IUserRoleRepository _userRoleRepository;

        public RoleService(IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
        {
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        public void Add(Role role)
        {
            _roleRepository.Add(role);
        }

        public Role Get(Guid id)
        {
            var role = _roleRepository.Get(id);

            return role;
        }

        public Role Get(string name)
        {
            var role = _roleRepository.Get(name);

            return role;
        }

        public IEnumerable<Role> GetAll()
        {
            var roles = _roleRepository.GetAll();

            return roles;
        }

        public void Update(Role updatedRole)
        {
            _roleRepository.Update(updatedRole);
        }

        public void Remove(Guid id)
        {
            var role = _roleRepository.Get(id);

            var userRoles = _userRoleRepository
                .GetAll()
                .Where(r => r.Role.Id == id);

            _userRoleRepository.RemoveRange(userRoles);

            _roleRepository.Remove(role);
        }

        public void RemoveRange(IEnumerable<Role> roles)
        {
            var userRoles = roles.SelectMany(
                r => _userRoleRepository
                .GetAll()
                .Where(ur => ur.Role.Id == r.Id));

            _userRoleRepository.RemoveRange(userRoles);

            _roleRepository.RemoveRange(roles);
        }
    }
}
