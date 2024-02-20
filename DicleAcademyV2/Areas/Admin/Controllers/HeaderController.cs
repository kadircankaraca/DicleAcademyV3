using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeaderController : Controller
    {
        public IActionResult AddHeader()
        {
            return View();
        }
        public IActionResult ShowHeader()
        {
            return View();
        }
    }
}
