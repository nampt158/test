using System;

namespace WebApplication.Data.Forecast
{
    internal class GridQueryResponse
    {
        public Uri Id { get; set; }
        public GridQueryResponseProperties Properties { get; set; }
    }
}