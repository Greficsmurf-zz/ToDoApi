using RestApi.Models;
using RestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoContext _context;
        public UnitOfWork(ToDoContext context){
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
