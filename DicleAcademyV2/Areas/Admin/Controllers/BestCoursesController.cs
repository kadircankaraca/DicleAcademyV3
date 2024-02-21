using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;
using System.Drawing.Drawing2D;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BestCoursesController : Controller
    {
        private readonly IBestCoursesService _bestCoursesService;
        private readonly ICoursesService _coursesService;
        public BestCoursesController(IBestCoursesService bestCoursesService, ICoursesService coursesService)
        {
            _bestCoursesService = bestCoursesService;
            _coursesService = coursesService;

        }
        public IActionResult AddBestCourses()
        {
            List<CoursesDto> courseList = new List<CoursesDto>();
            courseList = _coursesService.GetAllCourses().ToList();
            
            BestCoursesDto bestCoursesDto = new BestCoursesDto();

            return View(Tuple.Create(bestCoursesDto, courseList));
        }
        public IActionResult AddBestCoursesPost(BestCoursesDto incomingBestCoursesDto)
        {
            List<BestCoursesDto> bestCourseList = new List<BestCoursesDto>();
            List<CoursesDto> courseList = new List<CoursesDto>();
            BestCoursesDto incomingDto = new BestCoursesDto();
            bool isCourseAlreadyAvailable = false;

            courseList = _coursesService.GetAllCourses().ToList();
            bestCourseList = _bestCoursesService.GetAllBestCourses().ToList();

            if (bestCourseList.Count > 0)
            {
                foreach (var course in bestCourseList)
                {
                    if (course.CourseId == incomingBestCoursesDto.CourseId) isCourseAlreadyAvailable = true;
                }
            }
            
            if(isCourseAlreadyAvailable is true)  ViewBag.Message = "Başarısız";
            else
            {
                incomingDto = _bestCoursesService.CreateBestCourses(incomingBestCoursesDto);
                if (incomingDto is not null) ViewBag.Message = "Başarılı";
                else ViewBag.Message = "Başarısız";
            }

            return View("AddBestCourses", Tuple.Create(incomingDto, courseList));
        }
        public IActionResult ShowBestCourses()
        {
            List<CoursesDto> coursesList = new List<CoursesDto>();
            List<BestCoursesDto> bestCoursesList = new List<BestCoursesDto>();

            bestCoursesList = _bestCoursesService.GetAllBestCourses().ToList();
            coursesList = _coursesService.GetAllCourses().ToList();

            return View(Tuple.Create(coursesList, bestCoursesList));
        }
        public IActionResult DeleteBestCourses(int bestCoursesId)
        {
            List<CoursesDto> coursesList = new List<CoursesDto>();
            coursesList = _coursesService.GetAllCourses().ToList();

            BestCoursesDto bestCoursesDto = new BestCoursesDto();
            List<BestCoursesDto> bestCoursesDtoList = new List<BestCoursesDto>();

            _bestCoursesService.DeleteBestCourses(bestCoursesId);

            bestCoursesDto = _bestCoursesService.GetByIdBestCourses(bestCoursesId);

            if (bestCoursesDto is null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            bestCoursesDtoList = _bestCoursesService.GetAllBestCourses().ToList();

            return View("ShowBestCourses",Tuple.Create(coursesList, bestCoursesDtoList));
        }

        public IActionResult UpdateBestCoursesPost(BestCoursesDto bestCoursesDto)
        {
            BestCoursesDto newBestCoursesDto = new BestCoursesDto();
            List<BestCoursesDto> bestCourseList = new List<BestCoursesDto>();
            List<CoursesDto> coursesList = new List<CoursesDto>();
            bool isCourseAlreadyAvailable = false;

            bestCourseList = _bestCoursesService.GetAllBestCourses().ToList();

            if (bestCourseList.Count > 0)
            {
                foreach (var course in bestCourseList)
                {
                    if (course.CourseId == bestCoursesDto.CourseId) isCourseAlreadyAvailable = true;
                }
            }

            if (isCourseAlreadyAvailable is true) ViewBag.Message = "Başarısız";
            else
            {
                _bestCoursesService.UpdateBestCourses(bestCoursesDto);
                ViewBag.Message = "Başarılı";
            }

            coursesList = _coursesService.GetAllCourses().ToList();


            return View("UpdateBestCourses", Tuple.Create(bestCoursesDto, coursesList));
        }
        public IActionResult UpdateBestCourses(int bestCoursesId)
        {
            List<CoursesDto> coursesList = new List<CoursesDto>();
            BestCoursesDto bestCoursesDto = new BestCoursesDto();

            coursesList = _coursesService.GetAllCourses().ToList();

            bestCoursesDto = _bestCoursesService.GetByIdBestCourses(bestCoursesId);

            return View(Tuple.Create(bestCoursesDto, coursesList));
        }
    }
}
