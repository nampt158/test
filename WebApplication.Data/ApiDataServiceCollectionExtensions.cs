using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApplication.Data.Forecast;
using WebApplication.Data.Geocoding;
using WebApplication.Domain;

namespace WebApplication.Data
{
    public static class ApiDataServiceCollectionExtensions
    {
        public static IServiceCollection AddApiData(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            var contact = configuration.GetSection("WeatherApi")["Contact"];
            
            services.TryAddScoped<IForecastProvider, ApiForecastProvider>();

            services.TryAddTransient<CityQueryFactory>();
            services.TryAddTransient<NoaaQuery>();
            services.TryAddTransient<NoaaGridQuery>();
            services.TryAddTransient<GeocodeQuery>();
            services.TryAddTransient<AppendApiKeyHandler>();
            
            services.TryAddScoped<Func<IForecastProvider.ICityQuery>>(ctx =>
            {
                var factory = ctx.GetRequiredService<CityQueryFactory>();
                return factory.GetCityQuery;
            });

            services.AddHttpClient(typeof(NoaaQuery).FullName, c =>
            {
                c.DefaultRequestHeaders.Add("User-Agent", $"(Example .NET Api App; {contact})");
            });
            
            services.AddHttpClient(typeof(NoaaGridQuery).FullName, c =>
            {
                c.DefaultRequestHeaders.Add("User-Agent", $"(Example .NET Api App; {contact})");
                c.BaseAddress = new Uri("https://api.weather.gov/points/");
            });
            
            services.AddHttpClient(typeof(GeocodeQuery).FullName, c =>
            {
                c.BaseAddress = new Uri("http://api.positionstack.com/v1/forward");
            }).AddHttpMessageHandler<AppendApiKeyHandler>();
            
            return services;
        }
    }
}