using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestApi.Models;

namespace RestApi.Repositories.Interfaces
{
    public interface IGoalRepository
    {
        Task<IEnumerable<Goal>> ListAsync();
        Task<Goal> FindByIdAsync(long Id);
        Task AddAsync(Goal goal);
        void Update(Goal goal);
        void Delete(Goal goal);
    }
}
