using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryTest.NET.Services.AccountServices.Interfaces;
using LibraryTest.NET.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryTest.NET.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IAccountService _accountService;

        public UsersController(IUserService userService, IRoleService roleService, IAccountService accountService)
        {
            _userService = userService;
            _roleService = roleService;
            _accountService = accountService;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            var user = _userService.Get(id);

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }
    }
}
