using System;

namespace WebApplication.Domain
{
    public class WeatherForecast
    {
        public WeatherForecast(DateTime date, Celsius temperature, string city)
        {
            Date = date;
            Temperature = temperature;
            City = city;
        }
        
        public DateTime Date { get; }
        public Celsius Temperature { get; }
        public string City { get; }
    }
}