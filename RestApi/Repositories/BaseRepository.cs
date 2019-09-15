using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestApi.Models;
using RestApi.Repositories.Interfaces;
namespace RestApi.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ToDoContext _context;
        public BaseRepository(ToDoContext context) {
            _context = context;
        }

    }
}
