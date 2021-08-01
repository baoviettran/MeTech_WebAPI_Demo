using ECommerce.Application.Catalog.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public  IActionResult GetAll()
        {
            return Ok();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response =await _productService.GetById(id);
            if (response.IsSuccessed)
                return Ok(response);
            return BadRequest(response);
        }

        // POST api/products/create
        [HttpPost("create")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _productService.Delete(id);
            if (response.IsSuccessed)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
