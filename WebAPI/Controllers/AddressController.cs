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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpPost("addaddress")]
        public IActionResult AddAddress([FromBody]Address address)
        {
            var result = _addressService.AddAddress(address);
            if (result.Success)
            {
                return Created(nameof(AddressController.AddAddress), result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles="Admin,Uye")]
        [HttpPatch("deleteaddress/{id:int}")]
        public IActionResult DeleteAddress(int id)
        {
            var result = _addressService.DeleteAddress(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("harddeleteaddress/{id:int}")]
        public IActionResult HardDeleteAddress(int id)
        {
            var result = _addressService.HardDeleteAddress(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin,Uye")]
        [HttpPut("updateaddress/{id:int}")]
        public IActionResult UpdateAddress(int id, [FromBody] Address address)
        {
            var result = _addressService.UpdateAddress(id, address);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles="Admin,Uye")]
        [HttpGet("getaddressbyid/{id:int}")]
        public IActionResult GetAddressByID(int id)
        {
            var result = _addressService.GetAddressById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles="Admin,Uye")]
        [HttpGet("getaddressesbyuserId/{userId:int}")]
        public IActionResult GetAddresses(int userId)
        {
            var result = _addressService.GetAddressByUser(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
