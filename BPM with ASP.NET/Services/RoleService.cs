﻿using BPM_with_ASP.NET.Data.Models;
using BPM_with_ASP.NET.Data.Repositories.Interfaces;
using BPM_with_ASP.NET.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPM_with_ASP.NET.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
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

        public void Update(Role updatedRole)
        {
            _roleRepository.Update(updatedRole);
        }

        public void Remove(Guid id)
        {
            var role = _roleRepository.Get(id);

            _roleRepository.Remove(role);
        }

        public void RemoveRange(IEnumerable<Role> roles)
        {
            _roleRepository.RemoveRange(roles);
        }
    }
}
