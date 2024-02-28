using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController : Controller
    {
        private readonly IInstructorsService _instructorsService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        FileDelete _fileDelete = new FileDelete();
        public InstructorController(IInstructorsService instructorsService, IWebHostEnvironment webHostEnvironment)
        {
            _instructorsService = instructorsService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult AddInstructor()
        {
            return View();
        }
        public async Task<IActionResult> AddInstructorPost(InstructorsDto instructorDto, IFormFile image, string instructorDescriptionEn, string areaOfExpertiseEn)
        {
            if (image is not null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/InstructorImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                instructorDto.InstructorImage = fileName;
            }

            InstructorsDto incomingDto = _instructorsService.CreateInstructors(instructorDto);
            if (incomingDto is not null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";
            return View("AddInstructor");
        }
        public IActionResult ShowInstructor()
        {
            List<InstructorsDto> instructorList = _instructorsService.GetAllInstructors().ToList();

            return View(instructorList);
        }
        public IActionResult DeleteInstructor(int instructorId)
        {
            List<InstructorsDto> instructorList = _instructorsService.GetAllInstructors().ToList();
            InstructorsDto instructor = _instructorsService.GetByIdInstructors(instructorId);

            string instructorImage = instructor.InstructorImage;

            _instructorsService.DeleteInstructors(instructorId);

            instructor = _instructorsService.GetByIdInstructors(instructorId);

            if (instructor is null)
            {
                string path = "InstructorImages\\" + instructorImage;
                _fileDelete.DeleteFile(_webHostEnvironment, path);

                ViewBag.Message = "Başarılı";
            }
            else ViewBag.Message = "Başarısız";

            return View("ShowInstructor", instructorList);
        }
        public IActionResult UpdateInstructor(int instructorId)
        {
            InstructorsDto instructor = _instructorsService.GetByIdInstructors(instructorId);
            return View(instructor);
        }
        public async Task<IActionResult> UpdateInstructorPost(InstructorsDto instructor, IFormFile newImage)
        {
            List<InstructorsDto> instructorList = _instructorsService.GetAllInstructors().ToList();

            if (newImage != null && newImage.Length > 0)
            {
                var fileName = Path.GetFileName(newImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/InstructorImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newImage.CopyToAsync(fileStream);
                }
                instructor.InstructorImage = fileName;
            }
            else
            {
                instructor.InstructorImage = _instructorsService.GetByIdInstructors(instructor.InstructorId).InstructorImage;
            }

            _instructorsService.UpdateInstructors(instructor);

            return View("ShowInstructor", instructorList);
        }
    }
}
