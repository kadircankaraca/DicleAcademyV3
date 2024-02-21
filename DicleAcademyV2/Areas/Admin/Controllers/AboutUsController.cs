using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.IO;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService _aboutUsService;
        FileDelete _fileDelete = new FileDelete();
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AboutUsController(IAboutUsService aboutUsService, IWebHostEnvironment webHostEnvironment)
        {
            _aboutUsService = aboutUsService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult AddAboutUs()
        {
            return View();
        }
        public async Task<IActionResult> AddAboutUsPost(string aboutUsTitle, string aboutUsDescription, IFormFile aboutUsImage)
        {
            AboutUsDto aboutUsDto = new AboutUsDto();

            if (aboutUsImage != null && aboutUsImage.Length > 0)
            {
                var fileName = Path.GetFileName(aboutUsImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/AboutUsImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await aboutUsImage.CopyToAsync(fileStream);
                }
                aboutUsDto.AboutUsImage = fileName;

            }

            aboutUsDto.AboutUsDescription = aboutUsDescription;
            aboutUsDto.AboutUsTitle = aboutUsTitle;

            AboutUsDto incomingDto = _aboutUsService.CreateAboutUs(aboutUsDto);

            if (incomingDto is not null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            return View("AddAboutUs");
        }
        public IActionResult ShowAboutUs()
        {
            List<AboutUsDto> aboutUsList = new List<AboutUsDto>();
            aboutUsList = _aboutUsService.GetAllAboutUs().ToList();

            return View(aboutUsList);
        }
        public IActionResult DeleteAboutUs(int aboutUsId)
        {
            string aboutUsImage = _aboutUsService.GetByIdAboutUs(aboutUsId).AboutUsImage;
            AboutUsDto aboutUsDto = new AboutUsDto();
            List<AboutUsDto> aboutUsDtoList = new List<AboutUsDto>();

            _aboutUsService.DeleteAboutUs(aboutUsId);

            aboutUsDto = _aboutUsService.GetByIdAboutUs(aboutUsId);

            if (aboutUsDto is null)
            {
                string path = "AboutUsImages\\" + aboutUsImage;
                _fileDelete.DeleteFile(_webHostEnvironment, path);

                ViewBag.Message = "Başarılı";
            }
            else ViewBag.Message = "Başarısız";

            aboutUsDtoList = _aboutUsService.GetAllAboutUs().ToList();

            return View("ShowAboutUs", aboutUsDtoList);
        }
        public async Task<IActionResult> UpdateAboutUsPost(int aboutUsId, string aboutUsTitle, string aboutUsDescription, IFormFile newAboutUsImage)
        {
            AboutUsDto aboutUsDto = new AboutUsDto();

            if (newAboutUsImage != null && newAboutUsImage.Length > 0)
            {
                var fileName = Path.GetFileName(newAboutUsImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/AboutUsImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newAboutUsImage.CopyToAsync(fileStream);
                }
                aboutUsDto.AboutUsImage = fileName;
            }
            else
            {
                aboutUsDto.AboutUsImage = _aboutUsService.GetByIdAboutUs(aboutUsId).AboutUsImage;
            }

            aboutUsDto.AboutUsTitle = aboutUsTitle;
            aboutUsDto.AboutUsDescription = aboutUsDescription;
            aboutUsDto.AboutUsId = aboutUsId;

            _aboutUsService.UpdateAboutUs(aboutUsDto);

            return View("UpdateAboutUs", aboutUsDto);
        }
        public IActionResult UpdateAboutUs(int aboutusId)
        {
            AboutUsDto aboutUsDto = new AboutUsDto();

            aboutUsDto = _aboutUsService.GetByIdAboutUs(aboutusId);

            return View(aboutUsDto);
        }
    }
}
