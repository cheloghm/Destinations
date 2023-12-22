using Microsoft.Extensions.DependencyInjection;
using DestinationDiscoveryService.Interfaces;
using DestinationDiscoveryService.Services;
using DestinationDiscoveryService.Repositories;

namespace DestinationDiscoveryService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDestinationServices(this IServiceCollection services)
        {
            // Add all the services and repositories to the dependency injection container
            services.AddScoped<IDestinationService, DestinationService>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();
            //services.AddScoped<WebScrapingService>();

            return services;
        }

        // Additional extension methods can be added here
    }
}
