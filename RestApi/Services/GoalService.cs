
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using RestApi.Models;
using RestApi.Repositories.Interfaces;
using RestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GoalService(IGoalRepository goalRepository, IUnitOfWork unitOfWork) {
            _goalRepository = goalRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(Goal goal)
        {
            if (goal.EndDate < DateTime.Now) throw new Exception();
            await _goalRepository.AddAsync(goal);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(long Id)
        {
            var goal = await _goalRepository.FindByIdAsync(Id);
            _goalRepository.Delete(goal);
            await _unitOfWork.CompleteAsync();

        }

        public async Task DeleteAsync(string Name)
        {
            var category = await FindByNameAsync(Name);
            _goalRepository.Delete(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Goal> FindByIdAsync(long Id)
        {
            var item = await _goalRepository.FindByIdAsync(Id);
            return item;
        }

        public async Task<Goal> FindByNameAsync(string Name)
        {
            var list = await _goalRepository.ListAsync();
            foreach (var i in list)
            {
                if (i.Name == Name) return i;
            }
            return null;
        }

        public async Task<IEnumerable<Goal>> ListAsync()
        {
            return await _goalRepository.ListAsync();
        }

        public async Task UpdateAsync(long Id, Goal goal)
        {
            if (goal.EndDate < DateTime.Now) throw new Exception();
            var oldGoal = await _goalRepository.FindByIdAsync(Id);
            oldGoal.Name = goal.Name;
            oldGoal.Description = goal.Description;
            oldGoal.EndDate = goal.EndDate;
            oldGoal.File = goal.File;
            oldGoal.Status = goal.Status;

            _goalRepository.Update(oldGoal);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(string Name, Goal goal)
        {
            if (goal.EndDate < DateTime.Now) throw new Exception();
            var oldGoal = await FindByNameAsync(Name);
            oldGoal.Name = goal.Name;
            oldGoal.Description = goal.Description;
            oldGoal.EndDate = goal.EndDate;
            oldGoal.File = goal.File;
            oldGoal.Status = goal.Status;
            _goalRepository.Update(goal);
            await _unitOfWork.CompleteAsync();
        }
        public async Task UploadFile(long Id, IFormFile file) {
            var goal = await FindByIdAsync(Id);
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            goal.File = stream.ToArray();
            _goalRepository.Update(goal);
            await _unitOfWork.CompleteAsync();
        }
        public async Task UploadFile(string Name, IFormFile file)
        {
            var goal = await FindByNameAsync(Name);
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            goal.File = stream.ToArray();
            _goalRepository.Update(goal);
            await _unitOfWork.CompleteAsync();
        }

    }
}
