using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ValuesController(ToDoContext context, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) {
            _context = new ToDoContext();
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;

        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryRepository.ListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(long id)
        {
            var Table = await _context.Categories.FindAsync(id);
            if (Table == null) return NotFound();
            return Table;
        }

        // POST api/values
        [HttpPost]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long Id)
        {
            try
            {
                var category = await _categoryRepository.FindByIdAsync(Id);
                _categoryRepository.Delete(category);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long Id,[FromBody] Category newCategory)
        {
            try
            {
                var category = await _categoryRepository.FindByIdAsync(Id);
                category.Name = newCategory.Name;
                _categoryRepository.Update(category);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }

    }
}
