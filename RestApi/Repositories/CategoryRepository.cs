using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Repositories.Interfaces;
namespace RestApi.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(ToDoContext context) : base(context) { }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<Category> FindByIdAsync(long Id)
        {
            return await _context.FindAsync<Category>(Id);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            List<Category> list = await Task.Run(() => _context.Categories.ToList());
            return list;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            
        }
    }
}
