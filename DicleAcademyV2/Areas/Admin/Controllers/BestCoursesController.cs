using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BestCoursesController : Controller
    {
        public IActionResult AddBestCourses()
        {
            return View();
        }
        public IActionResult ShowBestCourses()
        {
            return View();
        }
    }
}
