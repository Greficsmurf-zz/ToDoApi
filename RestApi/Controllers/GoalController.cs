using System;
using System.Collections.Generic;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Goal>> Get(long Id)
        {
            var item = await _goalService.FindByIdAsync(Id);
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
        [HttpPut("{id}")]
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
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
    }
}
