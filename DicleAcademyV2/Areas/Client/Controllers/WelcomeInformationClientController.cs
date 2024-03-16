using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class WelcomeInformationClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
