using System;

namespace WebApplication.Data.Forecast
{
    internal class Period
    {
        public bool IsDaytime { get; set; }     
        public DateTimeOffset StartTime { get; set; }
        public long Temperature { get; set; }
        public Uri Icon { get; set; }
    }
}