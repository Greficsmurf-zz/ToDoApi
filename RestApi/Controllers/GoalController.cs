using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Repositories.Interfaces;
using RestApi.Services.Interfaces;

namespace RestApi.Controllers
{
    [Route("api/goals")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly ToDoContext _context;
        private readonly IGoalService _goalService;
        private readonly IUnitOfWork _unitOfWork;

        public GoalController(ToDoContext context, IGoalService goalService, IUnitOfWork unitOfWork) {
            _context = context;
            _goalService = goalService;
            _unitOfWork = unitOfWork;

        }
        // GET: api/Goal
        [HttpGet]
        public async Task<IEnumerable<Goal>> Get()
        {
            return await _goalService.ListAsync();
        }

        // GET: api/Goal/5
        [HttpGet("id/{Id}")]
        public async Task<ActionResult<Goal>> Get(long Id)
        {
            var item = await _goalService.FindByIdAsync(Id);
            if (item == null) return NotFound();
            return item;
        }
        [HttpGet("name/{Name}")]
        public async Task<ActionResult<Goal>> Get(string Name)
        {
            var item = await _goalService.FindByNameAsync(Name);
            if (item == null) return NotFound();
            return item;
        }

        // POST: api/Goal
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Goal goal)
        {
            try
            {
                await _goalService.AddAsync(goal);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }

        // PUT: api/Goal/5
        [HttpPut("id/{Id}")]
        public async Task<IActionResult> Put(long Id, [FromBody] Goal newGoal)
        {
            try
            {
                await _goalService.UpdateAsync(Id, newGoal);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }
        [HttpPut("name/{Name}")]
        public async Task<IActionResult> Put(String Name, [FromBody] Goal newGoal)
        {
            try
            {
                await _goalService.UpdateAsync(Name, newGoal);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("id/{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            try
            {
                await _goalService.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }
        [HttpDelete("name/{Name}")]
        public async Task<IActionResult> Delete(string Name)
        {
            try
            {
                await _goalService.DeleteAsync(Name);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost("upload/id/{Id}")]
        public async Task<IActionResult> UploadAsync(long Id, IFormFile file)
        {
            try
            {
                await _goalService.UploadFile(Id, file);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }
        [HttpPost("upload/name/{Name}")]
        public async Task<IActionResult> UploadAsync(string Name, IFormFile file)
        {
            try
            {
                await _goalService.UploadFile(Name, file);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
