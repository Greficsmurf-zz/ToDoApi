using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class MyOptions
    {
        public MyOptions()
        {

        }
        public String DefaultConnection { get; set; } = "Server=localhost;Port=9090;Database=ToDoDataBase;User Id=postgres; Password=password;";
     }
}
