using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Controllers
{
    public class HeaderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
