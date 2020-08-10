using BPM_with_ASP.NET.Data.Models;
using BPM_with_ASP.NET.Services.AccountServices.Interfaces;
using BPM_with_ASP.NET.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BPM_with_ASP.NET.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public AccountService(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public ClaimsIdentity GetIdentity(string email, string password)
        {
            var user = _userService.Get(email);

            if (user != null)
            {
                if (Verify(email, password))
                {
                    var roles = _userService.GetUserRoles(user.Id);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
                    };

                    var roleClaims = roles.Select(r => new Claim(ClaimsIdentity.DefaultRoleClaimType, r.Name));

                    claims.AddRange(roleClaims);

                    var identity = new ClaimsIdentity(
                        claims, 
                        "Token", 
                        ClaimsIdentity.DefaultNameClaimType, 
                        ClaimsIdentity.DefaultRoleClaimType);

                    return identity;
                }
            }

            return null;
        }

        public Data.Models.User Register(Data.Models.User user, IEnumerable<Role> roles)
        {
            var exists = _userService.Get(user.Email);

            if (exists == null)
            {
                _userService.Add(user, roles);

                return user;
            }

            return null;
        }

        public bool Verify(string email, string password)
        {
            var user = _userService.Get(email);

            if (user != null)
            {
                return Helpers.Verify(password, user.Password);
            }

            return false;
        }
    }
}
