using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FAQController : Controller
    {
        public IActionResult AddFAQ()
        {
            return View();
        }
        public IActionResult ShowFAQ()
        {
            return View();
        }

    }
}
