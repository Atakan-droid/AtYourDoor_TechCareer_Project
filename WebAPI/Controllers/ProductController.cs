using Business.Abstract;
using Business.Utilities.Result;
using Entities.Concrete;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("productadd")]
        [Authorize(Roles = "Admin")]
        public IActionResult ProductAdd([FromBody]Product product)
        {
            var result = _productService.AddProduct(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "Admin,Tedarik Noktası Görevlisi")]
        [HttpPatch("deleteproduct/{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var result=_productService.DeleteProduct(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("harddeleteproduct/{id:int}")]
        public IActionResult HardDeleteProduct(int id)
        {
            var result = _productService.HardDeleteProduct(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "Admin,Tedarik Noktası Görevlisi")]
        [HttpPut("updateproduct/{id:int}")]
        public IActionResult UpdateProduct(int id,[FromBody]Product product)
        {
            var result = _productService.UpdateProduct(id,product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproduct/{id:int}")]
        public IActionResult GetProduct(int id)
        {
            var result = _productService.GetProductById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproducts")]
        public IActionResult GetProducts()
        {
            var result = _productService.GetProducts();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproductbycategoryid/{id:int}")]
        public IActionResult GetProductByCategoryId(int categoryId)
        {
            var result = _productService.GetProductsByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
