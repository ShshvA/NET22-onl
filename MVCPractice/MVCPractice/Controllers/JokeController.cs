using Microsoft.AspNetCore.Mvc;
using MVCPractice.Interfaces;
using MVCPractice.Models;

namespace MVCPractice.Controllers
{
    public class JokeController : Controller
    {
        private readonly IJokeService service;

        public JokeController(IJokeService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var model = service.GetJoke();

            if (TempData.ContainsKey("NewJoke"))
            {
                model.JokeText = TempData["NewJoke"] as string ?? model.JokeText;
                TempData.Keep("NewJoke");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateJoke()
        {
            await service.GenerateJokeAsync();
            var newJoke = service.GetJoke();
            TempData["NewJoke"] = newJoke.JokeText;

            return RedirectToAction("Index");
        }
    }
}
