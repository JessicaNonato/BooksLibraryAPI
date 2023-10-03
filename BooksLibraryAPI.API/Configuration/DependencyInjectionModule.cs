using BooksLibraryAPI.Infra.Configurations;
using BooksLibraryAPI.Service.Implementations;
using BooksLibraryAPI.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksLibraryAPI.API.Configuration
{
    public static class DependencyInjectionModule
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRavenDb(configuration);
            services.AddSingleton<IBooksService, BooksService>();
            services.AddSingleton<IOrderService, OrderService>();

            return services;
        }
    }
}
