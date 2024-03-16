using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    public class CoursesCategoriesClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
