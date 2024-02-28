using Entities.ModelsDto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentsSayController : Controller
    {
        private readonly IStudentsSayService _studentsSayService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        FileDelete _fileDelete = new FileDelete();
        public StudentsSayController(IStudentsSayService studentsSayService, IWebHostEnvironment webHostEnvironment)
        {
            _studentsSayService = studentsSayService;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult AddStudentsSay()
        {
            return View();
        }
        public async Task<IActionResult> AddStudentsSayPost(StudentsSayDto studentsSayDto, IFormFile image, string studentsSayTitleEn, string studentsSayDescriptionEn)
        {
            if (image is not null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/StudentsSayImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                studentsSayDto.StudentsSayImage = fileName;
            }
            StudentsSayDto incomingDto = _studentsSayService.CreateStudentsSay(studentsSayDto);

            if (incomingDto is not null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            return View("AddStudentsSay");
        }
        public IActionResult ShowStudentsSay()
        {
            List<StudentsSayDto> studentsSayList = _studentsSayService.GetAllStudentsSay().ToList();

            return View(studentsSayList);
        }
        public IActionResult UpdateStudentsSay(int studentsSayId)
        {
            StudentsSayDto studentsSay = _studentsSayService.GetByIdStudentsSay(studentsSayId);
            return View(studentsSay);
        }
        public async Task<IActionResult> UpdateStudentsSayPost(StudentsSayDto studentsSay, IFormFile newImage)
        {

            if (newImage != null && newImage.Length > 0)
            {
                var fileName = Path.GetFileName(newImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/StudentsSayImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newImage.CopyToAsync(fileStream);
                }
                studentsSay.StudentsSayImage = fileName;
            }
            else
            {
                studentsSay.StudentsSayImage = _studentsSayService.GetByIdStudentsSay(studentsSay.StudentsSayId).StudentsSayImage;
            }

            _studentsSayService.UpdateStudentsSay(studentsSay);

            List<StudentsSayDto> studentsSayList = _studentsSayService.GetAllStudentsSay().ToList();

            return View("ShowStudentsSay", studentsSayList);
        }
        public IActionResult DeleteStudentsSay(int studentsSayId)
        {
            StudentsSayDto studentsSay = _studentsSayService.GetByIdStudentsSay(studentsSayId);

            string studentsSayImage = studentsSay.StudentsSayImage;

            _studentsSayService.DeleteStudentsSay(studentsSayId);

            studentsSay = _studentsSayService.GetByIdStudentsSay(studentsSayId);

            if (studentsSay is null)
            {
                string path = "StudentsSayImages\\" + studentsSayImage;
                _fileDelete.DeleteFile(_webHostEnvironment, path);

                ViewBag.Message = "Başarılı";
            }
            else ViewBag.Message = "Başarısız";

            List<StudentsSayDto> studentsSayList = _studentsSayService.GetAllStudentsSay().ToList();
            return View("ShowStudentsSay", studentsSayList);
        }
    }
}
