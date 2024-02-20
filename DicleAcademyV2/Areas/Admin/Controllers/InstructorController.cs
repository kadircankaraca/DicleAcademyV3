using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController : Controller
    {
        public IActionResult AddInstructor()
        {
            return View();
        }
        public IActionResult ShowInstructor()
        {
            return View();
        }
    }
}
