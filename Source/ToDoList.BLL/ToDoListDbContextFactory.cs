using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace ToDoList.BLL
{
    public class ToDoListDbContextFactory : IDesignTimeDbContextFactory<ToDoListDbContext>
    {
        public ToDoListDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ToDoListDbContext>();
            var connectionString = Environment.GetEnvironmentVariable("ToDoListDbConnection");

            optionsBuilder = optionsBuilder.UseSqlServer(
                connectionString,
                // cloud database can produce failures on cold start
                optionsBuilder => optionsBuilder.EnableRetryOnFailure()
                );

            return new ToDoListDbContext(optionsBuilder.Options);
        }
    }
}
