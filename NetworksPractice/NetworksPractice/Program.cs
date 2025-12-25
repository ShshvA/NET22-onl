using Microsoft.Extensions.Configuration;

namespace NetworksPractice
{
    internal class Program
    {
        static HttpClient client = new HttpClient();
        static async Task Main()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            string lang = "ru";
            string city = "Minsk";
            string apiKey = configuration["ExtApi:weatherapi:ApiKey"];

            try
            {
                var response = await client.GetAsync($"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&lang={lang}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Код: {response.StatusCode}\n" +
                    $"Результат: {result}");

                WeatherParser parser = new WeatherParser();
                WeatherData data = parser.ParseWeatherData(result);

                Console.WriteLine("\n\nДанные:");
                parser.DisplayWeather(data);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
