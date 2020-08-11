using LibraryTest.NET.Data.Models;
using LibraryTest.NET.Models.Role;
using LibraryTest.NET.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LibraryTest.NET.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("create")]
        public IActionResult CreateRole(RegisterRoleViewModel registerRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = registerRoleViewModel.Name,
                };

                _roleService.Add(role);

                return Ok(role);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRole(Guid id)
        {
            var role = _roleService.Get(id);

            return Ok(role);
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleService.GetAll();

            return Ok(roles);
        }

        [HttpPut("{id}")]
        public IActionResult EditRole(Guid id, EditRoleViewModel editRoleModel)
        {
            if (ModelState.IsValid)
            {
                var role = _roleService.Get(id);

                role.Name = editRoleModel.Name;

                _roleService.Update(role);

                return Ok(role);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(Guid id)
        {
            _roleService.Remove(id);

            return Ok();
        }
    }
}
