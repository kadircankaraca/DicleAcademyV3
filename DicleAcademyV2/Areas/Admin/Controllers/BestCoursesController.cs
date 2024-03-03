using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;
using System.Drawing.Drawing2D;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BestCoursesController : Controller
    {
        private readonly IBestCoursesService _bestCoursesService;
        private readonly ICoursesService _coursesService;
        public BestCoursesController(IBestCoursesService bestCoursesService, ICoursesService coursesService)
        {
            _bestCoursesService = bestCoursesService;
            _coursesService = coursesService;

        }
        public List<CoursesDto> AddBestCourses()
        {
            List<CoursesDto> courseList = new List<CoursesDto>();
            courseList = _coursesService.GetAllCourses().ToList();

            return (courseList);
        }
        public bool AddBestCoursesPost([FromBody] BestCoursesDto incomingBestCoursesDto)
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
            
            if(isCourseAlreadyAvailable is true) return false;
            else
            {
                incomingDto = _bestCoursesService.CreateBestCourses(incomingBestCoursesDto);
                if (incomingDto is not null) return true;
                else return false;
            }
        }
        public List<CoursesDto> GetCourseList()
        {
            List<CoursesDto> courseList = _coursesService.GetAllCourses().ToList();
            return courseList;
        }
        public List<BestCoursesDto> ShowBestCourses()
        {
            List<BestCoursesDto> bestCoursesList = new List<BestCoursesDto>();

            bestCoursesList = _bestCoursesService.GetAllBestCourses().ToList();

            return bestCoursesList;
        }
        public List<BestCoursesDto> DeleteBestCourses(int bestCoursesId)
        {
            BestCoursesDto bestCoursesDto = new BestCoursesDto();
            _bestCoursesService.DeleteBestCourses(bestCoursesId);

            List<BestCoursesDto> bestCourseList = _bestCoursesService.GetAllBestCourses().ToList();
            return bestCourseList;

        }   
        public List<BestCoursesDto> UpdateBestCoursesPost([FromBody] BestCoursesDto bestCoursesDto)
        {
            List<BestCoursesDto> bestCourseList = new List<BestCoursesDto>();
            bool isCourseAlreadyAvailable = false;

            bestCourseList = _bestCoursesService.GetAllBestCourses().ToList();

            if (bestCourseList.Count > 0)
            {
                foreach (var course in bestCourseList)
                {
                    if (course.CourseId == bestCoursesDto.CourseId) isCourseAlreadyAvailable = true;
                }
            }

            if (isCourseAlreadyAvailable is false) _bestCoursesService.UpdateBestCourses(bestCoursesDto);
            bestCourseList = _bestCoursesService.GetAllBestCourses().ToList();

            return bestCourseList;
        }
        public BestCoursesDto UpdateBestCourses(int bestCoursesId)
        {
            BestCoursesDto bestCoursesDto = new BestCoursesDto();
            bestCoursesDto = _bestCoursesService.GetByIdBestCourses(bestCoursesId);

            return bestCoursesDto;
        }
        
    }
}
