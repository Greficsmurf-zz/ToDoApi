using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using RestApi.Models;
using RestApi.Repositories;
using RestApi.Services.Interfaces;
using RestApi.Services;
using RestApi.Repositories.Interfaces;

namespace RestApi
{
    public class Startup
    {
    
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
               .AddDbContext<ToDoContext>()
               .BuildServiceProvider();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGoalService, GoalService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
