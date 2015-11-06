using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Frontend_Grupparbete.Models.Weather;

namespace Frontend_Grupparbete.Controllers
{
    public class WeatherController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private DateTime ToDateTime(string time)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(Convert.ToDouble(time)).ToLocalTime();
            return dtDateTime;
        }

        private string GetWeatherIcon(string icon)
        {
            string weathericon, weatherimage;
            GetWeatherIconAndImage(icon, out weathericon, out weatherimage);
            return weathericon;
        }
        
        private void GetWeatherIconAndImage(string icon, out string weathericon, out string weatherimage)
        {
            weatherimage = string.Empty;
            switch (icon)
            {
                case "clear-day":
                    weatherimage = "clear-day.jpg";
                    weathericon = "wi-day-sunny";
                    break;
                case "clear-night":
                    weatherimage = "clear-night.jpg";
                    weathericon = "wi-night-clear";
                    break;
                case "rain":
                    weatherimage = "rain.jpg";
                    weathericon = "wi-rain";
                    break;
                case "snow":
                    weatherimage = "snow.jpg";
                    weathericon = "wi-snow";
                    break;
                case "sleet":
                    weatherimage = "sleet.jpg";
                    weathericon = "wi-sleet";
                    break;
                case "wind":
                    weatherimage = "wind.jpg";
                    weathericon = "wi-strong-wind";
                    break;
                case "fog":
                    weatherimage = "fog.jpg";
                    weathericon = "wi-fog";
                    break;
                case "cloudy":
                    weatherimage = "cloudy.jpg";
                    weathericon = "wi-cloudy";
                    break;
                case "partly-cloudy-day":
                    weatherimage = "partly-cloudy-day.jpg";
                    weathericon = "wi-day-sunny-overcast";
                    break;
                case "partly-cloudy-night":
                    weatherimage = "partly-cloudy-night.jpg";
                    weathericon = "wi-night-partly-cloudy";
                    break;
                default:
                    weatherimage = "default.jpg";
                    weathericon = "wi-cloud";
                    break;
            }
        }

        private string GetMoonIcon(decimal moonphase)
        {
            if (moonphase == 0)
            {
                return "wi-moon-new";
            }
            else if (moonphase < 0.25M)
            {
                return "wi-moon-waxing-crescent-" + Math.Ceiling(moonphase * 24M);
            }
            else if (moonphase == 0.25M)
            {
                return "wi-moon-first-quarter";
            }
            else if (moonphase < 0.5M)
            {
                return "wi-moon-waxing-gibbous-" + Math.Ceiling((moonphase - 0.25M) * 24M);
            }
            else if (moonphase == 0.5M)
            {
                return "wi-moon-full";
            }
            else if (moonphase < 0.75M)
            {
                return "wi-moon-waning-gibbous-" + Math.Ceiling((moonphase - 0.5M) * 24M);
            }
            else if (moonphase == 0.75M)
            {
                return "wi-moon-third-quarter";
            }
            else if (moonphase < 1M)
            {
                return "wi-moon-waning-crescent-" + Math.Ceiling((moonphase - 0.75M) * 24M);
            }
            else
            {
                return "wi-moon-new";
            }
        }

        private string GetWindBearingIcon(decimal windBearing)
        {
            return string.Format("wi-wind towards-{0}-deg", Math.Round(windBearing));
        }

        public ActionResult Daily(string time, string summary, string icon,
            decimal temperatureMax, string temperatureMaxTime, decimal temperatureMin, string temperatureMinTime,
            decimal cloudCover, decimal precipIntensity, decimal precipIntensityMax, decimal precipProbability,
            decimal windSpeed, decimal windBearing,
            string sunriseTime, string sunsetTime, decimal moonPhase)
        {
            string weatherIcon, weatherImage;
            GetWeatherIconAndImage(icon, out weatherIcon, out weatherImage);
            var model = new DailyWeather
            {
                Time = ToDateTime(time),
                Summary = summary,
                Icon = weatherIcon,
                WeatherImage = weatherImage,
                TempMax = temperatureMax,
                TempMaxTime = ToDateTime(temperatureMaxTime),
                TempMin = temperatureMin,
                TempMinTime = ToDateTime(temperatureMinTime),
                CloudCover = cloudCover,
                PrecipIntensity = precipIntensity,
                PrecipIntensityMax = precipIntensityMax,
                PrecipProbability = precipProbability,
                WindSpeed = windSpeed,
                WindBearingIcon = GetWindBearingIcon(windBearing),
                SunriseTime = ToDateTime(sunriseTime),
                SunsetTime = ToDateTime(sunsetTime),
                MoonIcon = GetMoonIcon(moonPhase)
            };
            return PartialView("_Daily", model);
        }

        public ActionResult Hourly(string time, string summary, string icon,
            decimal temperature, decimal apparentTemperature,
            decimal cloudCover, decimal precipIntensity, decimal precipProbability,
            decimal windSpeed, decimal windBearing)
        {
            var model = new HourlyWeather
            {
                Time = ToDateTime(time),
                Summary = summary,
                Icon = GetWeatherIcon(icon),
                Temperature = temperature,
                ApparentTemperature = apparentTemperature,
                CloudCover = cloudCover,
                PrecipIntensity = precipIntensity,
                PrecipProbability = precipProbability,
                WindSpeed = windSpeed,
                WindBearingIcon = GetWindBearingIcon(windBearing)
            };
            return PartialView("_Hourly", model);
        }

        public ActionResult Currently(string time, string summary, string icon,
            decimal temperature, decimal apparentTemperature,
            decimal cloudCover, decimal precipIntensity, decimal precipProbability,
            decimal windSpeed, decimal windBearing)
        {
            string weatherIcon, weatherImage;
            GetWeatherIconAndImage(icon, out weatherIcon, out weatherImage);
            var model = new CurrentlyWeather
            {
                Time = ToDateTime(time),
                Summary = summary,
                Icon = weatherIcon,
                WeatherImage = weatherImage,
                Temperature = temperature,
                ApparentTemperature = apparentTemperature,
                CloudCover = cloudCover,
                PrecipIntensity = precipIntensity,
                PrecipProbability = precipProbability,
                WindSpeed = windSpeed,
                WindBearingIcon = GetWindBearingIcon(windBearing)
            };
            return PartialView("_Currently", model);
        }
    }
}