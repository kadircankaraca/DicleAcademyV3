using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUsController : Controller
    {     
        public IActionResult AddAboutUs()
        {
            return View();
        }
        public IActionResult AddAboutUsPost(AboutUsDto aboutUs)
        {
            return View();
        }
        public IActionResult ShowAboutUs()
        {
            return View();
        }
    }
}
