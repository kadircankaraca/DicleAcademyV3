using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademy.Controllers
{
    public class ContactController : Controller
    {
        private readonly IGetInTouchService _getInTouchService;

        public ContactController(IGetInTouchService getInTouchService)
        {
            _getInTouchService = getInTouchService;
        }

        public IActionResult Index()
        {
         var getInTouch =  _getInTouchService.GetAllGetInTouch().FirstOrDefault();

            return View("ContactIndex" , getInTouch);
        }
        [HttpPost]
        public IActionResult PostForm(ContactUsDto contactDto)
        {
            return RedirectToAction("Index");
        }
    }
}
