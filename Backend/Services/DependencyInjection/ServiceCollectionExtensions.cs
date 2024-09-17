using Backend.Services.Abstractions;

namespace Backend.Services.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Dependency Injection
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
