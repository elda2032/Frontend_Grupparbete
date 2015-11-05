using System;

namespace Frontend_Grupparbete.Models.Weather
{
    public class DailyWeather : WeatherModel
    {

        public decimal TempMax { get; set; }
        public DateTime TempMaxTime { get; set; }
        public decimal TempMin { get; set; }
        public DateTime TempMinTime { get; set; }

        public decimal PrecipIntensityMax { get; set; }
        
        public DateTime SunriseTime { get; set; }
        public DateTime SunsetTime { get; set; }
        public string MoonIcon { get; set; }
        
    }
}