using System.Text.Json.Serialization;

namespace MVCPractice.Models
{
    public class RandomJokeModel
    {
        [JsonPropertyName("joke")]
        public string? JokeText { get; set; }
    }
}
