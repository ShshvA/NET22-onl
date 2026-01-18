using GoodsWarehouse.Interfaces;
using GoodsWarehouse.VM;
using Microsoft.AspNetCore.Mvc;

namespace GoodsWarehouse.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Login(model.Username, model.Password);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверное имя пользователя или пароль");
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var userExists = _userService.UserExists(model.Username);
                if (userExists)
                {
                    ModelState.AddModelError("Username", "Пользователь с таким именем уже существует");
                    return View(model);
                }

                var user = new Models.User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password
                };

                var result = _userService.Register(user);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            var username = _userService.GetCurrentUsername();
            _userService.Logout();
            return RedirectToAction("Index", "Product");
        }
    }
}
