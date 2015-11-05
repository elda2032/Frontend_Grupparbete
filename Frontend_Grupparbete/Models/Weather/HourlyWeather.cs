namespace Frontend_Grupparbete.Models.Weather
{
    public class HourlyWeather : WeatherModel
    {
        public decimal Temperature { get; set; }
        public decimal ApparentTemperature { get; set; }
    }
}