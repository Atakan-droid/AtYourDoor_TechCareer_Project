using AuthManager.Entities;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("addrole")]
        public IActionResult AddRoles(Roles role)
        {
            var result = _roleService.AddRole(role);
            if (result.Success)
            {
                return Created(nameof(RoleController.AddRoles), result);
            }
            return BadRequest(result);
        }

        [HttpPatch("deleterole/{id:int}")]
        public IActionResult DeleteRoles(int id)
        {
            var result = _roleService.DeleteRole(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("harddeleterole/{id:int}")]
        public IActionResult HardDeleteRoles(int id)
        {
            var result = _roleService.HardDeleteRole(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("updaterole/{id:int}")]
        public IActionResult UpdateRoles(int id, [FromBody] Roles role)
        {
            var result = _roleService.UpdateRole(id, role);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getrole/{id:int}")]
        public IActionResult GetRole(int id)
        {
            var result = _roleService.GetRoleById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getroles")]
        public IActionResult GetRoles()
        {
            var result = _roleService.GetRoles();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    
}
}
