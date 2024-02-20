using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademy.Controllers
{
    public class AbouteController : Controller
    {
        private readonly IAboutUsService _abouteService;

        public AbouteController(IAboutUsService abouteService)
        {
            _abouteService = abouteService;
        }

        public IActionResult Index()
        {
          var aboute=  _abouteService.GetAllAboutUs();
            return View("AbouteIndex" , aboute);
        }
    }
}
