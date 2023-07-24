using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication.Data.Forecast
{
    internal class NoaaGridQuery : QueryBase
    {
        public NoaaGridQuery(IHttpClientFactory clientFactory) : base(clientFactory) { }

        public async Task<Uri> GetNoaaForecastQueryAsync(double latitude, double longitude)
        {
            var response = await Client.GetAsync($"{latitude},{longitude}");
            var responseString = await response.Content.ReadAsStringAsync();
            var json = Deserialize<GridQueryResponse>(responseString);
            return json?.Properties?.Forecast;
        }
    }
}