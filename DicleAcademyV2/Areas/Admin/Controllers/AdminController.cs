using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public AdminController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Authorize(Roles ="Admin")]
        public bool Index()
        {
            return true;
        }
        public IActionResult SignIn()
        {
            return RedirectToAction("Login", "User");
        }

        public IActionResult AuthForgotPassword()
        {
            return View();
        }

        public IActionResult AuthLockScreen()
        {
            return View();
        }

        public IActionResult AuthLogin()
        {
            return View();
        }

        public IActionResult AuthLogout()
        {
            return View();
        }

        public IActionResult AuthRegister()
        {
            return View();
        }

    }
}
