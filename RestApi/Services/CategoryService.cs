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
        public CategoryService(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        public Task<IActionResult> CategoryPost(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindCategoryById(int Id)
        {

            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
