using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;
        FileDelete _fileDelete = new FileDelete();
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GalleryController(IGalleryService galleryService, IWebHostEnvironment webHostEnvironment)
        {
            _galleryService = galleryService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult AddGallery()
        {
            return View();
        }
        public async Task<IActionResult> AddGalleryPost(IFormFile galleryImage)
        {
            GalleryDto galleryDto = new GalleryDto();

            if (galleryImage != null && galleryImage.Length > 0)
            {
                var fileName = Path.GetFileName(galleryImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/GalleryImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await galleryImage.CopyToAsync(fileStream);
                }
                galleryDto.GalleryImage = fileName;
            }

            GalleryDto incomingDto = _galleryService.CreateGallery(galleryDto);

            if (incomingDto is not null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            return View("AddGallery");
        }
        public IActionResult ShowGallery()
        {
            List<GalleryDto> galleryList = _galleryService.GetAllGallery().ToList();

            return View(galleryList);
        }
        public IActionResult DeleteGallery(int galleryId)
        {
            string galleryImage = _galleryService.GetByIdGallery(galleryId).GalleryImage;
            GalleryDto galleryDto = new GalleryDto();
            List<GalleryDto> galleryDtoList = new List<GalleryDto>();

            _galleryService.DeleteGallery(galleryId);

            galleryDto = _galleryService.GetByIdGallery(galleryId);

            if (galleryDto is null)
            {
                string path = "GalleryImages\\" + galleryImage;
                _fileDelete.DeleteFile(_webHostEnvironment, path);

                ViewBag.Message = "Başarılı";
            }
            else ViewBag.Message = "Başarısız";

            galleryDtoList = _galleryService.GetAllGallery().ToList();

            return View("ShowGallery", galleryDtoList);
        }
        public async Task<IActionResult> UpdateGalleryPost(int galleryId, IFormFile newGalleryImage)
        {
            List<GalleryDto> galleryList = _galleryService.GetAllGallery().ToList();
            GalleryDto galleryDto = new GalleryDto();

            if (newGalleryImage != null && newGalleryImage.Length > 0)
            {
                var fileName = Path.GetFileName(newGalleryImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/GalleryImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newGalleryImage.CopyToAsync(fileStream);
                }
                galleryDto.GalleryImage = fileName;
            }
            else
            {
                galleryDto.GalleryImage = _galleryService.GetByIdGallery(galleryId).GalleryImage;
            }


            _galleryService.UpdateGallery(galleryDto);

            return View("ShowGallery", galleryList);
        }
        public IActionResult UpdateGallery(int galleryId)
        {
            GalleryDto galleryDto = _galleryService.GetByIdGallery(galleryId);

            return View(galleryDto);
        }
    }
}
