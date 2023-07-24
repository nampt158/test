using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Data.Geocoding
{
    internal class AppendApiKeyHandler : DelegatingHandler
    {
        private readonly string _key;

        public AppendApiKeyHandler(IConfiguration configuration)
        {
            _key = configuration.GetSection("WeatherApi")["Key"];
        }
        
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            
            var query = $"access_key={_key}&country=US&limit=1";
            uriBuilder.Query = uriBuilder.Query == "" ? query : uriBuilder.Query + "&" + query;
            request.RequestUri = uriBuilder.Uri;
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}