using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace WebApplication.Data
{
    internal abstract class QueryBase
    {
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        protected readonly HttpClient Client;
        protected readonly UrlEncoder Encoder;

        protected T Deserialize<T>(string payload)
        {
            return JsonSerializer.Deserialize<T>(payload, _jsonOptions);
        }
        protected QueryBase(IHttpClientFactory clientFactory)
        {
            var name = GetType().FullName;
            Client = clientFactory.CreateClient(name);
            Encoder = UrlEncoder.Default;
        }
    }
}