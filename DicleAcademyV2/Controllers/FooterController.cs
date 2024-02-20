using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Controllers
{
    public class FooterController : Controller
    {
        private readonly IGalleryService _galleryService;
        private readonly IContactService _contactService;   
        public FooterController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        public IActionResult Index()
        { //ContactDto
           var contact =  _contactService.GetAllContact();
            var gallery=  _galleryService.GetAllGallery();
            return View(Tuple.Create(gallery, contact));
        }
    }
}
