using MVCPractice.Models;

namespace MVCPractice.Interfaces
{
    public interface IJokeService
    {
        public Task GenerateJokeAsync();
        public RandomJokeModel GetJoke();
    }
}
