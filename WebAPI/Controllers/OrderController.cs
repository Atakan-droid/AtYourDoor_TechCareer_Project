using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
    public class OrderController : ControllerBase
    {
        public IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Authorize(Roles =("Admin,Uye"))]
        [HttpPost("addorder")]
        public IActionResult AddOrder(OrderAddDTO order)
        {
            var result = _orderService.AddOrder(order);
            if (result.Success)
            {
                return Created(nameof(OrderController.AddOrder), result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "Admin,Uye")]
        [HttpPatch("deleteorder/{id:int}")]
        public IActionResult DeleteOrder(int id)
        {
            var result = _orderService.DeleteOrder(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("harddeleteorder/{id:int}")]
        public IActionResult HardDeleteOrder(int id)
        {
            var result = _orderService.HardDeleteOrder(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin,Tedarik Noktası Görevlisi")]
        [HttpPut("updateorder/{id:int}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order order)
        {
            var result = _orderService.UpdateOrder(id, order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
  
        [Authorize(Roles = "Tedarik Noktası Görevlisi")]
        [HttpPatch("readyorder/{orderId:int}/{courierId:int}")]
        public IActionResult IsOrderReadyUpdate(int orderId,int courierId)
        {
            var result = _orderService.IsOrderReadyUpdate(orderId,courierId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "Kargocu")]
        [HttpPatch("deliverorder")]
        public IActionResult DeliverOrder(OrderDeliveryDTO order)
        {
            var result = _orderService.CourierDelivery(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getorder/{id:int}")]
        public IActionResult GetOrder(int id)
        {
            var result = _orderService.GetOrderById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getuserordersbyid/{orderId:int}")]
        public IActionResult GetOrders(int orderId)
        {
            var result = _orderService.GetUserOrders(orderId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
