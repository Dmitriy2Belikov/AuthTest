using BPM_with_ASP.NET.Data.Models;
using BPM_with_ASP.NET.Models.Account;
using BPM_with_ASP.NET.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using System.Xml.Schema;

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

        [HttpGet]
        public IActionResult Login()
        {
            var path = @"C:\Users\user\Desktop\BPM with ASP.NET\BPM with ASP.NET\wwwroot\Login.html";

            var html = string.Empty;

            using (var sr = new StreamReader(path))
            {
                html = sr.ReadToEnd();
            }

            return Content(html, "text/html");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok("home/index");
        }
    }
}
