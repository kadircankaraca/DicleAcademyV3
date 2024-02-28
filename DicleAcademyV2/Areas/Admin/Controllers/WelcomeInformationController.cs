using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WelcomeInformationController : Controller
    {
        private readonly IWelcomeInformationsService _welcomeInformationService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        FileDelete _fileDelete = new FileDelete();
        public WelcomeInformationController(IWelcomeInformationsService welcomeInformationService, IWebHostEnvironment webHostEnvironment)
        {
            _welcomeInformationService = welcomeInformationService;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult AddWelcomeInformation()
        {
            return View();
        }
        public async Task<IActionResult> AddWelcomeInformationPost(WelcomeInformationsDto welcomeInformationDto, IFormFile image, string welcomeInformationTitleEn, string welcomeInformationDescriptionEn)
        {
            if (image is not null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/WelcomeInformationImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                welcomeInformationDto.WelcomeInformationImage = fileName;
            }
            WelcomeInformationsDto incomingDto = _welcomeInformationService.CreateWelcomeInformations(welcomeInformationDto);

            if (incomingDto is not null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            return View("AddWelcomeInformation");
        }
        public IActionResult ShowWelcomeInformation()
        {
            List<WelcomeInformationsDto> welcomeInformationList = _welcomeInformationService.GetAllWelcomeInformations().ToList();

            return View(welcomeInformationList);
        }
        public IActionResult UpdateWelcomeInformation(int welcomeInformationId)
        {
            WelcomeInformationsDto welcomeInformation = _welcomeInformationService.GetByIdWelcomeInformations(welcomeInformationId);
            return View(welcomeInformation);
        }
        public async Task<IActionResult> UpdateWelcomeInformationPost(WelcomeInformationsDto welcomeInformation, IFormFile newImage)
        {

            if (newImage != null && newImage.Length > 0)
            {
                var fileName = Path.GetFileName(newImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/WelcomeInformationImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newImage.CopyToAsync(fileStream);
                }
                welcomeInformation.WelcomeInformationImage = fileName;
            }
            else
            {
                welcomeInformation.WelcomeInformationImage = _welcomeInformationService.GetByIdWelcomeInformations(welcomeInformation.WelcomeInformationId).WelcomeInformationImage;
            }

            _welcomeInformationService.UpdateWelcomeInformations(welcomeInformation);

            List<WelcomeInformationsDto> welcomeInformationList = _welcomeInformationService.GetAllWelcomeInformations().ToList();

            return View("ShowWelcomeInformation", welcomeInformationList);
        }
        public IActionResult DeleteWelcomeInformation(int welcomeInformationId)
        {
            WelcomeInformationsDto welcomeInformation = _welcomeInformationService.GetByIdWelcomeInformations(welcomeInformationId);

            string welcomeInformationImage = welcomeInformation.WelcomeInformationImage;

            _welcomeInformationService.DeleteWelcomeInformations(welcomeInformationId);

            welcomeInformation = _welcomeInformationService.GetByIdWelcomeInformations(welcomeInformationId);

            if (welcomeInformation is null)
            {
                string path = "WelcomeInformationImages\\" + welcomeInformationImage;
                _fileDelete.DeleteFile(_webHostEnvironment, path);

                ViewBag.Message = "Başarılı";
            }
            else ViewBag.Message = "Başarısız";

            List<WelcomeInformationsDto> welcomeInformationList = _welcomeInformationService.GetAllWelcomeInformations().ToList();
            return View("ShowWelcomeInformation", welcomeInformationList);
        }
    }
}
