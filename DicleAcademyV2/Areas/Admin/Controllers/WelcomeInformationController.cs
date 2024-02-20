using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WelcomeInformationController : Controller
    {
        public IActionResult AddWelcomeInformation()
        {
            return View();
        }
        public IActionResult ShowWelcomeInformation()
        {
            return View();
        }
    }
}
