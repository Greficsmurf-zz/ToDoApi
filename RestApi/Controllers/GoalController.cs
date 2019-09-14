using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IGoalRepository _goalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GoalController(ToDoContext context, IGoalRepository goalRepository, IUnitOfWork unitOfWork) {
            _context = context;
            _goalRepository = goalRepository;
            _unitOfWork = unitOfWork;
        }
        // GET: api/Goal
        [HttpGet]
        public async Task<IEnumerable<Goal>> Get()
        {
            return await _goalRepository.ListAsync();
        }

        // GET: api/Goal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goal>> Get(long Id)
        {
            var item = await _goalRepository.FindByIdAsync(Id);
            if (item == null) return NotFound();
            return item;
        }

        // POST: api/Goal
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Goal goal)
        {
            try
            {
                await _goalRepository.AddAsync(goal);
                await _unitOfWork.CompleteAsync();
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
                var oldGoal = await _goalRepository.FindByIdAsync(Id);
                oldGoal.Name = newGoal.Name;
                _goalRepository.Update(oldGoal);
                await _unitOfWork.CompleteAsync();
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
                var goal = await _goalRepository.FindByIdAsync(Id);
                _goalRepository.Delete(goal);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }
    }
}
