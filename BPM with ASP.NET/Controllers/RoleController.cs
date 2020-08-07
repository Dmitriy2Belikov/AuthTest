using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPM_with_ASP.NET.Data.Models;
using BPM_with_ASP.NET.Models.Role;
using BPM_with_ASP.NET.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPM_with_ASP.NET.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
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
