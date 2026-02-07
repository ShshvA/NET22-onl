using EFPractice.DatabaseAccess.Interfaces;
using EFPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookLibraryService _bookLibraryService;

        public HomeController(IBookLibraryService bookLibraryService)
        {
            _bookLibraryService = bookLibraryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            _bookLibraryService.InitData();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
