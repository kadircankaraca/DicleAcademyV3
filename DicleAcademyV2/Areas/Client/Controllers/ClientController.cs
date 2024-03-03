using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
