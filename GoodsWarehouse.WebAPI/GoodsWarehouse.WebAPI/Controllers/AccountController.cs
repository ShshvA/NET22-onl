using GoodsWarehouse.WebAPI.Interfaces;
using GoodsWarehouse.WebAPI.VM;
using Microsoft.AspNetCore.Mvc;

namespace GoodsWarehouse.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Login")]
        public ActionResult Login()
        {
            return Ok();
        }

        [HttpPost("Login1")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Login(model.Username, model.Password);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверное имя пользователя или пароль");
                }
            }
            return Ok(model);
        }

        [HttpGet("Register")]
        public ActionResult Register()
        {
            return Ok();
        }

        [HttpPost("Register1")]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var userExists = _userService.UserExists(model.Username);
                if (userExists)
                {
                    ModelState.AddModelError("Username", "Пользователь с таким именем уже существует");
                    return Ok(model);
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
                    return Ok();
                }
            }
            return Ok(model);
        }

        [HttpPost("Logout")]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            var username = _userService.GetCurrentUsername();
            _userService.Logout();
            return Ok();
        }
    }
}
