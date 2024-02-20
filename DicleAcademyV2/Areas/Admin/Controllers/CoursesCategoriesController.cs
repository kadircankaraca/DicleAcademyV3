using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesCategoriesController : Controller
    {
        public IActionResult AddCoursesCategories()
        {
            return View();
        }
        public IActionResult ShowCoursesCategories()
        {
            return View();
        }
    }
}
