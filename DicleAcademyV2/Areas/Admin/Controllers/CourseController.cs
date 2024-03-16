using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        private readonly IInstructorsService _instructorsService;
        private readonly ICoursesCategoriesService _coursesCategoriesService;
        private readonly ICoursesService _coursesService;
        private readonly ICourseDetailsService _courseDetailsService;
        FileDelete _fileDelete = new FileDelete();
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CourseController(IInstructorsService instructorsService, ICoursesCategoriesService coursesCategoriesService, ICoursesService coursesService, ICourseDetailsService courseDetailsService, IWebHostEnvironment webHostEnvironment)
        {
            _instructorsService = instructorsService;
            _coursesCategoriesService = coursesCategoriesService;
            _coursesService = coursesService;
            _courseDetailsService = courseDetailsService;
            _webHostEnvironment = webHostEnvironment;

        }
        public bool AddCourse()
        {
            return true;
        }
        public async Task<bool> AddCoursePost( CoursesDto courseDto)
        {
            var data = courseDto;
            //if (courseDto.ImageFile != null && courseDto.ImageFile.Length > 0)
            //{
            //    var fileName = Path.GetFileName(courseDto.ImageFile.FileName);
            //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/CourseImages", fileName);

            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await courseDto.ImageFile.CopyToAsync(fileStream);
            //    }
            //    courseDto.Image = fileName;
            //}

            CoursesDto incomingDto = _coursesService.CreateCourses(courseDto);
            if (incomingDto is not null) return true;
            else return false;

        }
        public IActionResult ShowCourse()
        {
            List<CoursesDto> courseList = _coursesService.GetAllCourses().ToList();
            List<InstructorsDto> instructorList = _instructorsService.GetAllInstructors().ToList();
            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();

            return View(Tuple.Create(courseList, instructorList, categoryList));
        }
        public IActionResult DeleteCourse(int courseId)
        {
            List<CourseDetailsDto> courseDetailList = _courseDetailsService.GetAllCourseDetails().ToList();
            int courseDetailId = 0;
            CoursesDto course = _coursesService.GetByIdCourses(courseId);
            
            foreach (var item in courseDetailList)
            {
                if (item.CourseId == course.CourseId) courseDetailId = item.CourseDetailsId;
            }
            string courseImage = course.Image;

            if (courseDetailId != 0) _courseDetailsService.Delete(courseDetailId);

            _coursesService.DeleteCourses(courseId);

            course = _coursesService.GetByIdCourses(courseId);

            if (course is null)
            {
                string path = "CourseImages\\" + courseImage;
                _fileDelete.DeleteFile(_webHostEnvironment, path);

                ViewBag.Message = "Başarılı";
            }
            else ViewBag.Message = "Başarısız";

            List<CoursesDto> courseList = _coursesService.GetAllCourses().ToList();
            List<InstructorsDto> instructorList = _instructorsService.GetAllInstructors().ToList();
            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();

            return View("ShowCourse", Tuple.Create(courseList, instructorList, categoryList));

        }

        public async Task<IActionResult> UpdateCoursePost(CoursesDto courseDto, IFormFile newImage)
        {

            if (newImage != null && newImage.Length > 0)
            {
                var fileName = Path.GetFileName(newImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/CourseImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newImage.CopyToAsync(fileStream);
                }
                courseDto.Image = fileName;
            }
            else
            {
                courseDto.Image = _coursesService.GetByIdCourses(courseDto.CourseId).Image;
            }

            _coursesService.UpdateCourses(courseDto);

            List<CoursesDto> courseList = _coursesService.GetAllCourses().ToList();
            List<InstructorsDto> instructorList = _instructorsService.GetAllInstructors().ToList();
            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();

            return View("ShowCourse", Tuple.Create(courseList, instructorList, categoryList));
        }
        public IActionResult UpdateCourse(int courseId)
        {
            CoursesDto coursesDto = _coursesService.GetByIdCourses(courseId);

            List<InstructorsDto> instructorList = _instructorsService.GetAllInstructors().ToList();
            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();

            return View(Tuple.Create(coursesDto, instructorList, categoryList));
        }
        public List<CoursesCategoriesDto> GetCategoryList()
        {
            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();
            return categoryList;
        }
        public List<InstructorsDto> GetInstructorList()
        {
            List<InstructorsDto> instructorList = _instructorsService.GetAllInstructors().ToList();
            return instructorList;
        }
    }
}
