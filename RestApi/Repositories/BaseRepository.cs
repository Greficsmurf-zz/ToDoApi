using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestApi.Models;
namespace RestApi.Repositories
{
    public class BaseRepository
    {
        protected readonly ToDoContext _context;
        public BaseRepository(ToDoContext context) {
            _context = context;
        }
    }
}
