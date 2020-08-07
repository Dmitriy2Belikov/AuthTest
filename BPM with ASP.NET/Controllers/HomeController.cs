using BPM_with_ASP.NET.Data.Models;
using BPM_with_ASP.NET.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System;

namespace LibraryTest.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public HomeController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [Authorize]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok(User.Identity.Name);
        }
    }
}
