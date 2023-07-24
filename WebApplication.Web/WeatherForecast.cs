using System;
using WebApplication.Domain;

namespace WebApplication.Web
{
    public class WeatherForecast
    {
        private static readonly string[] Summaries = 
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        public WeatherForecast(DateTime date, Celsius temperature)
        {
            Date = date;
            TemperatureC = temperature;
            var summary = (int) Math.Clamp(temperature.Temperature / 4.44, 0, 8);
            Summary = Summaries[summary];
            TemperatureF = new Fahrenheit(temperature);
        }

        public WeatherForecast(DateTime date, Fahrenheit temperature) : this(date, new Celsius(temperature)) {}
        
        /// <summary>
        /// The date of the forecast.
        /// </summary>
        public DateTime Date { get; }
        
        /// <summary>
        /// High temperature in degrees Celsius.
        /// </summary>
        public Celsius TemperatureC { get; }
        
        /// <summary>
        /// Textual description of the temperature.
        /// </summary>
        public string Summary { get; }
        
        /// <summary>
        /// High temperature in degrees Fahrenheit.
        /// </summary>
        public Fahrenheit TemperatureF { get; }
    }
}