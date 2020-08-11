using LibraryTest.NET.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryTest.NET.Data.Models;
using LibraryTest.NET.Services.Interfaces;
using Microsoft.Extensions.Hosting;

namespace LibraryTest.NET.Services.SeedServices
{
    public static class ContextManager
    {
        public static void AddOrUpdate<T> (DbContext context, IEnumerable<T> data) 
            where T : class
        {
            DbSet<T> entities = context.Set<T>();

            foreach(var entity in data)
            {
                if (!entities.Contains(entity))
                {
                    entities.Add(entity);
                    context.SaveChanges();
                }
                else
                {
                    entities.Update(entity);
                    context.SaveChanges();
                }
            }
        }
    }

    public class SeedService : ISeedService
    {
        private UserDbContext _context;
        private IRoleService _roleService;
        private IUserService _userService;

        public SeedService(UserDbContext context, IRoleService roleService, IUserService userService)
        {
            _context = context;
            _roleService = roleService;
            _userService = userService;
        }


        private Guid _defaultRoleId = Guid.Parse("2f761fff-e4ee-4d79-8e1f-4524d245d9e1");
        private Guid _defaultUserId = Guid.Parse("b1ba959e-c4dd-4f8e-ab8f-036d11d0d104");
        private Guid _defalutUserRoleId = Guid.Parse("a9aee527-4e69-4511-859c-7c9ceea11b60");

        public void Configure()
        {
            ContextManager.AddOrUpdate(_context, GetDefaultRoles());
            ContextManager.AddOrUpdate(_context, GetDefaultUsers());
            ContextManager.AddOrUpdate(_context, GetDefaultUserRole());
        }

        private IEnumerable<Role> GetDefaultRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Id = _defaultRoleId,
                    Name = "SuperAdmin"
                }
            };

            return roles;
        }

        private IEnumerable<User> GetDefaultUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = _defaultUserId,
                    FirstName = "admin",
                    LastName = "admin",
                    Email = "admin@admin.ru",
                    Password = Helpers.HashPassword("admin")
                }
            };

            return users;
        }

        private IEnumerable<UserRole> GetDefaultUserRole() 
        {
            var userRoles = new List<UserRole>()
            {
                new UserRole()
                {
                    Id = _defalutUserRoleId,
                    Role = _roleService.Get(_defaultRoleId),
                    User = _userService.Get(_defaultUserId)
                }
            };

            return userRoles;
        }
    }
}
