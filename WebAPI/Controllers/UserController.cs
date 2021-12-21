using AuthManager.Entities;
using AuthManager.Entities.DTOs;
using AutoMapper;
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
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("userlogin")]
        public IActionResult Login([FromBody] UserLoginDTO user)
        {
            var userToLogin = _userService.UserLogin(user);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _userService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("userregister")]
        public IActionResult Register([FromBody] UserRegisterDTO user)
        {
            var result = _userService.UserRegister(user);
            if (result.Success)
            {
                return Created(nameof(UserController), result);
            }
            return BadRequest(result);
        }
    
        [Authorize(Roles = "Admin")]
        [HttpPost("adduser/{roleId:int}")]
        public IActionResult AddUser([FromBody]UserRegisterDTO user,int roleId)
        {
            var result = _userService.AddUser(user,roleId);
            if (result.Success)
            {
                return Created(nameof(UserController.AddUser), result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("deleteuser/{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("harddeleteuser/{id:int}")]
        public IActionResult HardDeleteUser(int id)
        {
            var result = _userService.HardDeleteUser(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin,Uye")]
        [HttpPut("updateuser/{id:int}/{roleId:int}")]
        public IActionResult UpdateUser(int id, [FromBody] UserRegisterDTO user,int roleId)
        {
            var result = _userService.UpdateUser(id, user,roleId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("ChangeUserRole/{userId:int}/{roleId:int}")]
        public IActionResult ChangeUserRole(int userId, int roleId)
        {
            var result = _userService.ChangeUserRole(userId,roleId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuser/{id:int}")]
        [Authorize(Roles = "Admin,Uye,Kargocu")]
        public IActionResult GetUser(int id)
        {
            var result = _userService.GetUserById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getusers")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUsers()
        {
            var result = _userService.GetUsers();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcourierswithcounty/{courierId:int}")]
        [Authorize(Roles = "Tedarik Noktası Görevlisi")]
        public IActionResult GetAvalibleCouriersWithCountyId(int courierId)
        {
            var result = _userService.GetAvalibleCouriersWithCountyId(courierId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
