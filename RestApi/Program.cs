using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using RestApi.Models;

namespace RestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var build = CreateWebHostBuilder(args).Build();

            using (var scope = build.Services.CreateScope())
            using (var context = new ToDoContext())
            {
                context.Database.EnsureCreated();
            }
            build.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
