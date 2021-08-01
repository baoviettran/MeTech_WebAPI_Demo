using ECommerce.Application.Catalog.Categories;
using ECommerce.ViewModels.Catalog.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _categoryService.InsertOne(request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        //https://localhost:5000/caetegories/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetById(id);
            if (!result.IsSuccessed)
                return NotFound(result);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteOne(id);
            if(!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _categoryService.Update(id, request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }


    }
}
