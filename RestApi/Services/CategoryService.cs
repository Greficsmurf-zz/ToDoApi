using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Repositories.Interfaces;
using RestApi.Services.Interfaces;
namespace RestApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ToDoContext _context;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, ToDoContext context) {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(long Id)
        {
            var category = await _categoryRepository.FindByIdAsync(Id);
            _categoryRepository.Delete(category);
            await _unitOfWork.CompleteAsync();
        }
        public async Task DeleteAsync(string Name)
        {
            var category = await FindByNameAsync(Name);
            _categoryRepository.Delete(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Category> FindByIdAsync(long Id)
        {
            return await _categoryRepository.FindByIdAsync(Id);
        }
        public async Task<Category> FindByNameAsync(string Name)
        {
            var list = await _categoryRepository.ListAsync();
            foreach (var i in list) {
                if (i.Name == Name) return i;
            }
            return null;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task UpdateAsync(long Id, Category category)
        {
            var oldCategory = await _categoryRepository.FindByIdAsync(Id);
            oldCategory.Name = category.Name;
            oldCategory.Description = category.Description;
            oldCategory.Goal = category.Goal;
            _categoryRepository.Update(category);
            await _unitOfWork.CompleteAsync();
        }
        public async Task UpdateAsync(string Name, Category category)
        {
            var oldCategory = await FindByNameAsync(Name);
            oldCategory.Name = category.Name;
            oldCategory.Description = category.Description;
            oldCategory.Goal = category.Goal;

            _categoryRepository.Update(category);
            await _unitOfWork.CompleteAsync();
        }
    }
}
