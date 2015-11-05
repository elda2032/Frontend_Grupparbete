using System;

namespace Frontend_Grupparbete.Models.Weather
{
    public abstract class WeatherModel
    {
        public string Summary { get; set; }
        public string Icon { get; set; }
        public DateTime Time { get; set; }

        public decimal CloudCover { get; set; }
        public decimal PrecipIntensity { get; set; }
        public decimal PrecipProbability { get; set; }
        
        public decimal WindSpeed { get; set; }
        public string WindBearingIcon { get; set; } 
    }
}