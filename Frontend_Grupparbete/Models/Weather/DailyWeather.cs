using System;

namespace Frontend_Grupparbete.Models.Weather
{
    public class DailyWeather
    {

        public string Summary { get; set; }
        public string Icon { get; set; }
        public DateTime Time { get; set; }
        
        public decimal TempMax { get; set; }
        public DateTime TempMaxTime { get; set; }
        public decimal TempMin { get; set; }
        public DateTime TempMinTime { get; set; }
        public decimal CloudCover { get; set; }
        public decimal PrecipIntensity { get; set; }
        public decimal PrecipIntensityMax { get; set; }
        public decimal PrecipProbability { get; set; }
        public DateTime SunriseTime { get; set; }
        public DateTime SunsetTime { get; set; }
        public string MoonIcon { get; set; }
        public decimal WindSpeed { get; set; }
        public string WindBearingIcon { get; set; }
    }
}