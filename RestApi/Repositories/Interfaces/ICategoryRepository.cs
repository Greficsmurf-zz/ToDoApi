using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestApi.Models;
namespace RestApi.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<Category> FindByIdAsync(long Id);
        Task AddAsync(Category category);
        void Update(Category category);
        void Delete(Category category);
        
    }
}
