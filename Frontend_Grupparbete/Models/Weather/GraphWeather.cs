using System;

namespace Frontend_Grupparbete.Models.Weather
{
    public class GraphWeather
    {
        public long Time { get; set; }
        public decimal Temperature { get; set; }
        public decimal ApparentTemperature { get; set; }
        public decimal PrecipIntensity { get; set; }
    }
}