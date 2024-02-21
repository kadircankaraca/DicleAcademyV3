using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Controllers
{
    public class FooterController : Controller
    {
        private readonly IGalleryService _galleryService;
        private readonly IContactService _contactService;   
        public FooterController(IGalleryService galleryService, IContactService contactService)
        {
            _galleryService = galleryService;
            _contactService = contactService;
        }
        public IActionResult Index()
        { //ContactDto
           var contact =  _contactService.GetAllContact();
            var gallery=  _galleryService.GetAllGallery();
            return PartialView(Tuple.Create((List<GalleryDto>)gallery, (List<ContactDto>)contact));
        }
    }
}
