using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        public IActionResult AddCourse()
        {
            return View();
        }
        public IActionResult ShowCourse()
        {
            return View();
        }
    }
}
