using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseDetailsController : Controller
    {
        public IActionResult AddCourseDetails()
        {
            return View();
        }
        
        public IActionResult ShowCourseDetails()
        {
            return View();
        }
    }
}
