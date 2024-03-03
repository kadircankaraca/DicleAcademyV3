using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CourseDetailsController : Controller
    {
        private readonly ICourseDetailsService _courseDetailsService;
        private readonly ICoursesService _coursesService;
        private readonly ICoursesCategoriesService _coursesCategoriesService;
        public CourseDetailsController(ICourseDetailsService courseDetailsService, ICoursesService coursesService, ICoursesCategoriesService coursesCategoriesService)
        {
            _courseDetailsService = courseDetailsService;
            _coursesService = coursesService;
            _coursesCategoriesService = coursesCategoriesService;
        }
        public bool AddCourseDetails()
        {
            return true;
        }
        public List<CoursesDto> AddCourseDetailsPost(CourseDetailsDto courseDetails, string courseDescriptionEn, string courseLocationEn)
        {
            CoursesDto tempDto = _coursesService.GetByIdCourses(courseDetails.CourseId);
            List<CoursesDto> courseList = _coursesService.GetAllCourses().ToList();
            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();
            bool isAvailable = false;

            foreach (var course in courseList)
            {
                if (course.CourseId == courseDetails.CourseId)
                {
                    ViewBag.Message = "Başarısız";
                    isAvailable = true;
                }
            }

            if (!isAvailable)
            {
                courseDetails.CourseDuration = tempDto.CoursesDuration;
                courseDetails.CategoryId = tempDto.CategoryId;
                courseDetails.CourseName = tempDto.CourseName;
                courseDetails.Image = tempDto.Image;

                CourseDetailsDto incomingDto = _courseDetailsService.CreateCourseDetails(courseDetails);

                if (incomingDto is not null) ViewBag.Message = "Başarılı";
            }
            return courseList;
        }
        public IActionResult ShowCourseDetails()
        {
            List<CoursesDto> courseList = _coursesService.GetAllCourses().ToList();
            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();
            List<CourseDetailsDto> courseDetailList = _courseDetailsService.GetAllCourseDetails().ToList();

            return View(Tuple.Create(courseDetailList, courseList, categoryList));
        }
        public IActionResult DeleteCourseDetails(int courseDetailsId)
        {
            List<CoursesDto> courseList = _coursesService.GetAllCourses().ToList();
            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();

            CourseDetailsDto tempDto = _courseDetailsService.GetByIdCourseDetails(courseDetailsId);
            if (tempDto is not null) _courseDetailsService.Delete(courseDetailsId);

            tempDto = _courseDetailsService.GetByIdCourseDetails(courseDetailsId);

            if (tempDto is null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            List<CourseDetailsDto> courseDetailList = _courseDetailsService.GetAllCourseDetails().ToList();
            return View("ShowCourseDetails", Tuple.Create(courseDetailList, courseList, categoryList));
        }
        public IActionResult UpdateCourseDetails(int courseDetailsId)
        {
            CourseDetailsDto courseDetails = _courseDetailsService.GetByIdCourseDetails(courseDetailsId);
            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();
            List<CoursesDto> courseList = _coursesService.GetAllCourses().ToList();

            return View("UpdateCourseDetails", Tuple.Create(courseDetails, courseList, categoryList));
        }
        public IActionResult UpdateCourseDetailsPost(CourseDetailsDto courseDetails, int newCourseId)
        {

            CourseDetailsDto tempDto = _courseDetailsService.GetByIdCourseDetails(courseDetails.CourseDetailsId);

            courseDetails.CourseId = newCourseId;
            courseDetails.Image = tempDto.Image;
            courseDetails.CategoryId = tempDto.CategoryId;

            _courseDetailsService.UpdateCourseDetails(courseDetails);

            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();
            List<CourseDetailsDto> courseDetailList = _courseDetailsService.GetAllCourseDetails().ToList();
            List<CoursesDto> courseList = _coursesService.GetAllCourses().ToList();

            return View("ShowCourseDetails", Tuple.Create(courseDetailList, courseList, categoryList));
        }

        public List<CoursesDto> GetCourseList()
        {
            List<CoursesDto> courseList = _coursesService.GetAllCourses().ToList();
            return courseList;
        }
        public List<CoursesCategoriesDto> GetCategoryList()
        {
            List<CoursesCategoriesDto> categoryList = _coursesCategoriesService.GetAllCoursesCategories().ToList();
            return categoryList;
        }
    }
}
