﻿using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Repositories.Interfaces;
using RestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
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
            var oldGoal = await FindByNameAsync(Name);
            oldGoal.Name = goal.Name;
            oldGoal.Description = goal.Description;
            _goalRepository.Update(goal);
            await _unitOfWork.CompleteAsync();
        }
    }
}
