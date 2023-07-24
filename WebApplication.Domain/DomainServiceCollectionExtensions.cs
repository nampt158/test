using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WebApplication.Domain
{
    public static class DomainServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.TryAddScoped<IForecastRepository, ForecastRepository>();

            return services;
        }
    }
}