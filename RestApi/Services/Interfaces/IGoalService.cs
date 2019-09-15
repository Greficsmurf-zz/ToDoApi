
using Microsoft.AspNetCore.Http;
using RestApi.Models;
using RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services.Interfaces
{
    public interface IGoalService
    {
        Task<IEnumerable<Goal>> ListAsync();
        Task<Goal> FindByIdAsync(long Id);
        Task<Goal> FindByNameAsync(string Name);

        Task AddAsync(Goal goal);
        Task UpdateAsync(long Id, Goal goal);
        Task UpdateAsync(string Name, Goal goal);

        Task DeleteAsync(long Id);
        Task DeleteAsync(string Name);
        Task UploadFile(long Id,IFormFile file);
        Task UploadFile(string Name, IFormFile file);


    }
}
