using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesCategoriesController : Controller
    {
        private readonly ICoursesCategoriesService _coursesCategoriesService;
        FileDelete _fileDelete = new FileDelete();
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CoursesCategoriesController(ICoursesCategoriesService coursesCategoriesService, IWebHostEnvironment webHostEnvironment)
        {
            _coursesCategoriesService = coursesCategoriesService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult AddCoursesCategories()
        {
            return View();
        }
        public async Task<IActionResult> AddCoursesCategoriesPost(CoursesCategoriesDto categoryDto, IFormFile categoryImage)
        {
            categoryDto.TotalCourseNumber = 0;

            if (categoryImage != null && categoryImage.Length > 0)
            {
                var fileName = Path.GetFileName(categoryImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/CoursesCategoriesImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await categoryImage.CopyToAsync(fileStream);
                }
                categoryDto.CategoryImage = fileName;
            }

            CoursesCategoriesDto incomingDto = _coursesCategoriesService.CreateCoursesCategories(categoryDto);

            if (incomingDto is not null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            return View("AddCoursesCategories");
        }
        public IActionResult ShowCoursesCategories()
        {
            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();
            return View(categoryList);
        }

        public IActionResult DeleteCoursesCategories(int categoryId)
        {
            List<CoursesCategoriesDto> coursesCategoriesList = new List<CoursesCategoriesDto>();

            string coursesCategoriesImage = _coursesCategoriesService.GetByIdCoursesCategories(categoryId).CategoryImage;

            _coursesCategoriesService.DeleteCoursesCategories(categoryId);

            CoursesCategoriesDto coursesCategoriesDto = _coursesCategoriesService.GetByIdCoursesCategories(categoryId);

            if (coursesCategoriesDto is null)
            {
                string path = "CoursesCategoriesImages\\" + coursesCategoriesImage;
                _fileDelete.DeleteFile(_webHostEnvironment, path);

                ViewBag.Message = "Başarılı";
            }
            else ViewBag.Message = "Başarısız";

            coursesCategoriesList = _coursesCategoriesService.GetAllCoursesCategories().ToList();

            return View("ShowCoursesCategories", coursesCategoriesList);
        }

        public async Task<IActionResult> UpdateCoursesCategoriesPost(CoursesCategoriesDto coursesCategoriesDto, IFormFile newCategoryImage)
        {

            if (newCategoryImage != null && newCategoryImage.Length > 0)
            {
                var fileName = Path.GetFileName(newCategoryImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/CoursesCategoriesImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newCategoryImage.CopyToAsync(fileStream);
                }
                coursesCategoriesDto.CategoryImage = fileName;
            }
            else
            {
                coursesCategoriesDto.CategoryImage = _coursesCategoriesService.GetByIdCoursesCategories(coursesCategoriesDto.CategoryId).CategoryImage;
            }

            _coursesCategoriesService.UpdateCoursesCategories(coursesCategoriesDto);

            return View("UpdateCoursesCategories", coursesCategoriesDto);
        }

        public IActionResult UpdateCoursesCategories(int categoryId)
        {
            CoursesCategoriesDto coursesCategoriesDto = _coursesCategoriesService.GetByIdCoursesCategories(categoryId);

            return View(coursesCategoriesDto);
        }
    }
}
