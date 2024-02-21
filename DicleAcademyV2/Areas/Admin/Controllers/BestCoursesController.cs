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
            List<CoursesDto> courseList = new List<CoursesDto>();
            courseList = _coursesService.GetAllCourses().ToList();

            BestCoursesDto incomingDto = _bestCoursesService.CreateBestCourses(incomingBestCoursesDto);

            if (incomingDto is not null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            return View("AddBestCoursesPost", Tuple.Create(incomingDto, courseList));
        }
        public IActionResult ShowBestCourses()
        {
            List<BestCoursesDto> bestCoursesList = new List<BestCoursesDto>();
            bestCoursesList = _bestCoursesService.GetAllBestCourses().ToList();

            return View(bestCoursesList);
        }
        public IActionResult DeleteBestCourses(int bestCoursesId)
        {
            BestCoursesDto bestCoursesDto = new BestCoursesDto();
            List<BestCoursesDto> bestCoursesDtoList = new List<BestCoursesDto>();

            _bestCoursesService.DeleteBestCourses(bestCoursesId);

            bestCoursesDto = _bestCoursesService.GetByIdBestCourses(bestCoursesId);

            if (bestCoursesDto is null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            bestCoursesDtoList = _bestCoursesService.GetAllBestCourses().ToList();

            return View("ShowBestCourses",bestCoursesDtoList);
        }
    }
}
