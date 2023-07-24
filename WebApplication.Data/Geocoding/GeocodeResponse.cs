namespace WebApplication.Data.Geocoding
{
    internal class GeocodeResponse
    {
        public string Region { get; set; }
        public string Locality { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}