using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        
        public IActionResult AddGallery()
        {
            return View();
        }
        public IActionResult ShowGallery()
        {
            return View();
        }
    }
}
