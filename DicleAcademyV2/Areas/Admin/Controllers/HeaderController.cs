using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeaderController : Controller
    {
        private readonly IHeaderService _headerService;
        FileDelete _fileDelete = new FileDelete();
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HeaderController(IHeaderService headerService, IWebHostEnvironment webHostEnvironment)
        {
            _headerService = headerService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult AddHeader()
        {
            return View();
        }
        public async Task<IActionResult> AddHeaderPost(HeaderDto headerDto, IFormFile image, string headerTitleEn, string headerDescriptionEn)
        {
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/HeaderImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                headerDto.HeaderImage = fileName;
            }

            HeaderDto incomingDto = _headerService.CreateHeader(headerDto);

            if (incomingDto is not null) ViewBag.Message = "Başarılı";           
            else ViewBag.Message = "Başarısız";

            return View("AddHeader");
        }
        public IActionResult ShowHeader()
        {
            List<HeaderDto> headerDto = _headerService.GetAllHeader().ToList();

            return View(headerDto);
        }
        public IActionResult UpdateHeader(int headerId)
        {
            HeaderDto header = _headerService.GetByIdHeader(headerId);
            return View(header);
        }
        public async Task<IActionResult> UpdateHeaderPost(HeaderDto headerDto, IFormFile image)
        {
            List<HeaderDto> headerList = _headerService.GetAllHeader().ToList();

            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/HeaderImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                headerDto.HeaderImage = fileName;
            }
            else
            {
                headerDto.HeaderImage = _headerService.GetByIdHeader(headerDto.HeaderId).HeaderImage;
            }

            _headerService.UpdateHeader(headerDto);

            return View("ShowHeader", headerList);
        }
        public IActionResult DeleteHeader(int headerId)
        {
            string image = _headerService.GetByIdHeader(headerId).HeaderImage;

            _headerService.DeleteHeader(headerId);

            List<HeaderDto> headerList = _headerService.GetAllHeader().ToList();

            HeaderDto header = _headerService.GetByIdHeader(headerId);

            if (header is null)
            {
                string path = "HeaderImages\\" + image;
                _fileDelete.DeleteFile(_webHostEnvironment, path);

                ViewBag.Message = "Başarılı";
            }
            else ViewBag.Message = "Başarısız";

            return View("ShowHeader", headerList);
        }
    }
}
