using Microsoft.EntityFrameworkCore;
using Backend.Data.Abstractions;
using Backend.Data.Repositories;
using Backend.Data.Repositories.Abstractions;
using Backend.Services.Abstractions;
using System;

namespace Backend.Data.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            //DB connection
            services.AddDbContext<TaskDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
            ));

            //Dependency Injection
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
