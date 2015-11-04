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
            switch (icon)
            {
                case "clear-day":
                    return "wi-day-sunny";
                case "clear-night":
                    return "wi-night-clear";
                case "rain":
                    return "wi-rain";
                case "snow":
                    return "wi-snow";
                case "sleet":
                    return "wi-sleet";
                case "wind":
                    return "wi-strong-wind";
                case "fog":
                    return "wi-fog";
                case "cloudy":
                    return "wi-cloudy";
                case "partly-cloudy-day":
                    return "wi-day-sunny-overcast";
                case "partly-cloudy-night":
                    return "wi-night-partly-cloudy";
                default:
                    return "wi-cloud";
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
            return string.Format("wi-wind.towards-{0}-deg", Math.Round(windBearing));
        }

        public ActionResult Daily(string time, string summary, string icon,
            decimal temperatureMax, string temperatureMaxTime, decimal temperatureMin, string temperatureMinTime,
            decimal cloudCover, decimal precipIntensity, decimal precipIntensityMax, decimal precipProbability,
            decimal windSpeed, decimal windBearing,
            string sunriseTime, string sunsetTime, decimal moonPhase)
        {
            var model = new DailyWeather
            {
                Time = ToDateTime(time),
                Summary = summary,
                Icon = GetWeatherIcon(icon),
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
    }
}