﻿using BooksLibraryAPI.Domain.Models.Settings;
using BooksLibraryAPI.Infra.Implementations;
using BooksLibraryAPI.Infra.Interfaces;
using BooksLibraryAPI.Infra.Provider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksLibraryAPI.Infra.Configurations
{
    public static class DependencyInjectionModule
    {
        public static IServiceCollection AddRavenDb(this IServiceCollection services, IConfiguration configuration )
        {
            var bookStoreDatabaseSettings = configuration
                .GetSection(nameof(BookStoreDatabaseSettings)).Get<BookStoreDatabaseSettings>();

            services.AddSingleton<IRavenDbProvider, RavenDbProvider>();
            services.AddSingleton<IGenericRepository, GenericRepository>();
            services.AddSingleton(bookStoreDatabaseSettings);
            return services;
        }
    }
}
