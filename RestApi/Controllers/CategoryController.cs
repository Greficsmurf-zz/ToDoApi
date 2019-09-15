using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Repositories.Interfaces;
using RestApi.Services.Interfaces;

namespace RestApi.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ToDoContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _unitOfWork;

        public ValuesController(ToDoContext context, ICategoryService categoryService, IUnitOfWork unitOfWork) {
            _context = new ToDoContext();
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
            
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryService.ListAsync();
        }

        // GET api/values/5
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Category>> Get(long Id)
        {
            var Table = await _categoryService.FindByIdAsync(Id);
            if (Table == null) return NotFound();
            return Table;
        }


        [HttpGet("name/{Name}")]
        public async Task<ActionResult<Category>> Get(string Name)
        {
            var name = await _categoryService.FindByNameAsync(Name);
            if (name == null) return NotFound();
            return name;
        }


        // POST api/values
        [HttpPost]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            try
            {
                await _categoryService.AddAsync(category);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }
        [HttpDelete("id/{Id}")]
        public async Task<IActionResult> DeleteAsync(long Id)
        {
            try
            {
                await _categoryService.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }
        [HttpDelete("name/{Name}")]
        public async Task<IActionResult> DeleteAsync(string Name)
        {
            try
            {
                await _categoryService.DeleteAsync(Name);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("id/{Id}")]
        public async Task<IActionResult> Update(long Id,[FromBody] Category newCategory)
        {
            try
            {
                await _categoryService.UpdateAsync(Id, newCategory);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }
        [HttpPut("name/{Name}")]
        public async Task<IActionResult> Update(string Name, [FromBody] Category newCategory)
        {
            try
            {
                await _categoryService.UpdateAsync(Name, newCategory);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
