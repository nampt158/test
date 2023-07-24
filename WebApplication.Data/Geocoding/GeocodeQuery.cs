using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication.Data.Geocoding
{
    internal class GeocodeQuery : QueryBase
    {
        public GeocodeQuery(IHttpClientFactory clientFactory) : base(clientFactory) { }

        public async Task<(double Latitude, double Longitude)?> QueryCityAsync(string name)
        {
            var response = await Client.GetAsync($"?query={Encoder.Encode(name)}");
            var responseString = await response.Content.ReadAsStringAsync();
            var json = Deserialize<GeocodeResponses>(responseString);
            if (json.Data.Count == 0) {return null;}
            return (json.Data[0].Latitude, json.Data[0].Longitude);
        }
    }
}