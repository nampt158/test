using System.Threading.Tasks;

namespace WebApplication.Domain
{
    public interface IForecastRepository
    {
        Task<WeatherForecast[]> GetDailyForecastsByCityAsync(string city);
    }
}