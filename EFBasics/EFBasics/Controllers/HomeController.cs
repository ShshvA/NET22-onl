using DatabaseAccessCodeFirst;
using DatabaseAccessCodeFirst.Models;
using DatabaseAccessDBFirst;
using EFBasics.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFBasics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var contextCodeFirst = new PlayerTeamCodeFirstDBContext();

            contextCodeFirst.Players.Add(new PlayerEntity() { 
                    FirstName = "Artem",
                    LastName = "Artem"
                });

            contextCodeFirst.SaveChanges();

            var playersCodeFirst = contextCodeFirst.Players.ToList();

            var contextDBFirst = new PlayerTeamDBFirstDBContext();
            var playersDBFirst = contextDBFirst.Players.ToList();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
