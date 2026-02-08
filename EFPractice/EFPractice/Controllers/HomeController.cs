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
            //_bookLibraryService.InitData();
            var booksAfterYear = _bookLibraryService.GetBooksAfterYear(2010);
            var authorsNoBio = _bookLibraryService.GetAuthorsNoBio();
            var membersOverdueBooks = _bookLibraryService.GetMembersOverdueBooks();
            var categoryStat = _bookLibraryService.GetCategoriesStat();
            var publishersWithoutBooks = _bookLibraryService.GetPublishersWithoutBooks();
            var booksWithMoreOneCat = _bookLibraryService.GetBooksWithMoreOneCat();
            var authorsPopularBooks = _bookLibraryService.GetAuthorsPopularBooks();
            var membersByCategory = _bookLibraryService.GetMembersByCategory("Бестселлер");
            var booksWithInfo = _bookLibraryService.GetBooksWithInfo();
            var publishersWithBooks = _bookLibraryService.GetPublishersWithBooks();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
