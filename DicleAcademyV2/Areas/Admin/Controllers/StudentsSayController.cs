using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentsSayController : Controller
    {
        public IActionResult AddStudentsSay()
        {
            return View();
        }
        public IActionResult ShowStudentsSay()
        {
            return View();
        }
    }
}
