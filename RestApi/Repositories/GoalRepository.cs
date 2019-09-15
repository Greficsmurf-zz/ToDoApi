using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Repositories
{
    public class GoalRepository : BaseRepository, IGoalRepository
    {
        public GoalRepository(ToDoContext context) : base(context) { }
        public async Task AddAsync(Goal goal)
        {
            await _context.Goals.AddAsync(goal);
        }

        public void Delete(Goal goal)
        {
            _context.Goals.Remove(goal);
        }

        public async Task<Goal> FindByIdAsync(long Id)
        {
           return await _context.Goals.FindAsync(Id);
        }

        public async Task<IEnumerable<Goal>> ListAsync()
        {
            return await Task.Run(() =>  _context.Goals.ToList());
        }

        public void Update(Goal goal)
        {
            _context.Goals.Update(goal);
        }
    }
}
