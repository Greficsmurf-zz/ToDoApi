using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;

namespace RestApi.Services.Interfaces
{
    public interface ICategoryService
    {
       
        Task<Category> FindCategoryById(int Id);
        Task<IEnumerable<Category>> ListAsync();

        Task<IActionResult> CategoryPost(Category category);

    }
}
