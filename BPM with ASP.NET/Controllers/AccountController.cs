using BPM_with_ASP.NET.Data.Models;
using BPM_with_ASP.NET.Models.Account;
using BPM_with_ASP.NET.Services;
using BPM_with_ASP.NET.Services.AccountServices.Interfaces;
using BPM_with_ASP.NET.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BPM_with_ASP.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IAccountService _accountService;

        public AccountController(IUserService userService, IRoleService roleService, IAccountService accountService)
        {
            _userService = userService;
            _roleService = roleService;
            _accountService = accountService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUserViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var identity = _accountService.GetIdentity(loginViewModel.Email, loginViewModel.Password);

                if (identity != null)
                {
                    var now = DateTime.UtcNow;

                    var jwt = new JwtSecurityToken(
                            issuer: AuthOptions.ISSUER,
                            audience: AuthOptions.AUDIENCE,
                            notBefore: now,
                            claims: identity.Claims,
                            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                    var identityRoles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);

                    var response = new
                    {
                        access_token = encodedJwt,
                        username = identity.Name,
                        roles = identityRoles
                    };

                    return Ok(response);
                }

                return BadRequest("Неправильный логин или пароль");
            }
            else
            {
                return BadRequest("Заполните форму правильно");
            }
        }

        [HttpGet("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                var newUser = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Email = registerViewModel.Email,
                    Password = Helpers.HashPassword(registerViewModel.Password)
                };

                var roles = registerViewModel.Roles.Select(r => _roleService.Get(r));

                var user = _accountService.Register(newUser, roles);

                var url = HttpContext.Request.Path;

                return Created(url, user);
            }
            else
            {
                return BadRequest("Заполните форму правильно");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult EditProfile(Guid id, EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Get(id);

                var roles = editUserViewModel.Roles.Select(r => _roleService.Get(r));

                user.FirstName = editUserViewModel.FirstName;
                user.LastName = editUserViewModel.LastName;
                user.Email = editUserViewModel.Email;
                user.Password = editUserViewModel.Password;

                _userService.Update(user, roles);

                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("verify/{id}")]
        public IActionResult VerifyUser(Guid id, string password)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Get(id);

                var isVerified = _accountService.Verify(user.Email, password);

                if (isVerified)
                {
                    return Ok(user);
                }
                else
                {
                    return Conflict("Неправильный пароль");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteProfile(Guid id)
        {
            _userService.Remove(id);

            return Ok();
        }
    }
}
