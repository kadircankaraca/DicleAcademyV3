using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GetInTouchController : Controller
    {
        public IActionResult AddGetInTouch()
        {
            return View();
        }
        public IActionResult ShowGetInTouch()
        {
            return View();
        }
    }
}
