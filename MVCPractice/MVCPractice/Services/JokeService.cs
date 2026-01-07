using Microsoft.AspNetCore.DataProtection.KeyManagement;
using MVCPractice.Interfaces;
using MVCPractice.Models;
using System.Text.Json;

namespace MVCPractice.Services
{
    public class JokeService : IJokeService
    {
        public JokeService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _joke = new RandomJokeModel() { JokeText = "Click the button to get a joke!" };
        }
        public async Task GenerateJokeAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://v2.jokeapi.dev/joke/Any?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&type=single");

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();

                RandomJokeModel joke = JsonSerializer.Deserialize<RandomJokeModel>(result);

                if (joke != null)
                    _joke = joke;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public RandomJokeModel GetJoke() => _joke;

        private RandomJokeModel _joke;
        private readonly HttpClient _httpClient;
    }
}
