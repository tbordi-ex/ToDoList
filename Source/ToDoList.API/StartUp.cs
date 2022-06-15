using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using ToDoList.BLL;

[assembly:FunctionsStartup(typeof(ToDoList.API.StartUp))]
namespace ToDoList.API
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connectionString = Environment.GetEnvironmentVariable("ToDoListDbConnection");
            builder.Services.AddDbContext<ToDoListDbContext>(
                options => options.UseSqlServer(
                    connectionString,
                    options => options.EnableRetryOnFailure()
                    )
                );
        }
    }
}
