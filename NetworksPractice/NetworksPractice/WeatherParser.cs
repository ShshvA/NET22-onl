using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetworksPractice
{
    public class Location
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("tz_id")]
        public string TimeZoneId { get; set; }

        [JsonPropertyName("localtime_epoch")]
        public long LocalTimeEpoch { get; set; }

        [JsonPropertyName("localtime")]
        public string LocalTime { get; set; }
    }

    public class WeatherCondition
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class CurrentWeather
    {
        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("temp_c")]
        public double TemperatureC { get; set; }

        [JsonPropertyName("condition")]
        public WeatherCondition Condition { get; set; }

        [JsonPropertyName("wind_mph")]
        public double WindMph { get; set; }

        [JsonPropertyName("wind_kph")]
        public double WindKph { get; set; }

        [JsonPropertyName("wind_degree")]
        public int WindDegree { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDirection { get; set; }

        [JsonPropertyName("pressure_mb")]
        public double PressureMb { get; set; }

        [JsonPropertyName("pressure_in")]
        public double PressureIn { get; set; }

        [JsonPropertyName("precip_mm")]
        public double PrecipitationMm { get; set; }

        [JsonPropertyName("precip_in")]
        public double PrecipitationIn { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("cloud")]
        public int Cloud { get; set; }

        [JsonPropertyName("feelslike_c")]
        public double FeelsLikeC { get; set; }

        [JsonPropertyName("feelslike_f")]
        public double FeelsLikeF { get; set; }

        [JsonPropertyName("windchill_c")]
        public double WindChillC { get; set; }

        [JsonPropertyName("windchill_f")]
        public double WindChillF { get; set; }

        [JsonPropertyName("heatindex_c")]
        public double HeatIndexC { get; set; }

        [JsonPropertyName("heatindex_f")]
        public double HeatIndexF { get; set; }

        [JsonPropertyName("dewpoint_c")]
        public double DewPointC { get; set; }

        [JsonPropertyName("dewpoint_f")]
        public double DewPointF { get; set; }

        [JsonPropertyName("vis_km")]
        public double VisibilityKm { get; set; }

        [JsonPropertyName("vis_miles")]
        public double VisibilityMiles { get; set; }

        [JsonPropertyName("uv")]
        public double UV { get; set; }

        [JsonPropertyName("gust_mph")]
        public double GustMph { get; set; }

        [JsonPropertyName("gust_kph")]
        public double GustKph { get; set; }

        [JsonPropertyName("short_rad")]
        public double ShortRadiation { get; set; }

        [JsonPropertyName("diff_rad")]
        public double DiffuseRadiation { get; set; }
    }

    public class WeatherData
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeather Current { get; set; }
    }
    public class WeatherParser
    {
        public WeatherData ParseWeatherData(string json)
        {
            return JsonSerializer.Deserialize<WeatherData>(json);
        }

        public void DisplayWeather(WeatherData data)
        {
            Console.WriteLine($"\tГород: {data.Location.Name}");
            Console.WriteLine($"\tТемпература: {data.Current.TemperatureC}°C");
            Console.WriteLine($"\tОщущается как: {data.Current.FeelsLikeC}°C");
            Console.WriteLine($"\tПогодные условия: {data.Current.Condition.Text}");
            Console.WriteLine($"\tВлажность: {data.Current.Humidity}%");
            Console.WriteLine($"\tВетер: {data.Current.WindKph} км/ч");
        }
    }
}
