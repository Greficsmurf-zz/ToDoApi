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

        Task<IEnumerable<Category>> ListAsync();
        Task<Category> FindByIdAsync(long Id);
        Task<Category> FindByNameAsync(string Name);

        Task AddAsync(Category category);
        Task UpdateAsync(long Id, Category category);
        Task UpdateAsync(string Name, Category category);

        Task DeleteAsync(long Id);
        Task DeleteAsync(string Name);
    }
}
