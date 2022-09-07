using System;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Services.Area.Business.Managers;
using SC.App.Services.Area.Business.Managers.Interface;
using SC.App.Services.Area.Business.Repositories;
using SC.App.Services.Area.Business.Repositories.Interface;

namespace SC.App.Services.Area.Configurations.Extensions
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddManagers();
            services.AddRepositories();
            services.AddHandlers();
            services.AddClients(configuration);
        }

        private static void AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IRegionManager, RegionManager>();
            services.AddScoped<IAreaManager, AreaManager>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
        }

        private static void AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Business.Startup));
        }

        private static void AddClients(this IServiceCollection services, IConfiguration configuration)
        {
        }

        private static void AddClient<TInterface, IImplementation>(this IServiceCollection services, string baseUrl)
            where TInterface : class
            where IImplementation : class, TInterface
        {
            services.AddHttpClient<TInterface, IImplementation>((client) =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });
        }
    }
}