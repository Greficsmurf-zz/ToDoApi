using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    public class ToDoContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public ToDoContext() {
        }
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options){
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Server=localhost;Database=ToDoDataBase;User Id=postgres;Password=password;Port=9090");
           
        }
        protected override void OnModelCreating(ModelBuilder builder) {

            base.OnModelCreating(builder);
            builder.ForNpgsqlUseSequenceHiLo("HiLoSequence");

            builder.Entity<Category>().ToTable("Category");
            builder.Entity<Category>().HasKey(p => p.CategoryId);
            builder.Entity<Category>().Property(p => p.CategoryId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(250);
            builder.Entity<Category>().Property(p => p.Name).HasMaxLength(1000);
            //builder.Entity<Category>().HasMany(p => p.Goal).WithOne(p => p.Category);
            
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Hight priority", Description = "Goal which require fast resolvement" },
                new Category { CategoryId = 2, Name = "Medium priority", Description = "Goal which can be done later" },
                new Category { CategoryId = 3, Name = "Low priority", Description = "Optional Goal" }
            );

            builder.Entity<Goal>().ToTable("Goal");
            builder.Entity<Goal>().HasKey(p => p.TaskId);
            builder.Entity<Goal>().Property(p => p.TaskId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Goal>().Property(p => p.Name).IsRequired().HasMaxLength(250);
            builder.Entity<Goal>().Property(p => p.Description).HasMaxLength(1000);
            //builder.Entity<Goal>().Property(p => p.File);
            //builder.Entity<Goal>().Property(p => p.EndDate);
            //builder.Entity<Goal>().Property(p => p.category).IsRequired();
            builder.Entity<Goal>().Property(p => p.Status).HasMaxLength(250);
           


        }
    }
}
