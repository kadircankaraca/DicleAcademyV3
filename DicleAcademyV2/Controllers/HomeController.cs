using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;
using System.Diagnostics;

namespace DicleAcademy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBestCoursesService _bestcoursesService;
        private readonly ICoursesService _coursesService;
        private readonly IWelcomeInformationsService _welcomeInformationsService;
        private readonly ISkillsService _skillsService;
        private readonly IInstructorsService _instructorsService;
        private readonly IStudentsSayService _studentsSayService;
        private readonly IHeaderService _headerService;

        public HomeController(IHeaderService headerService, IBestCoursesService bestcoursesService, ICoursesService coursesService, IWelcomeInformationsService welcomeInformationsService, ISkillsService skillsService, IInstructorsService instructorsService, IStudentsSayService studentsSayService)
        {
            _bestcoursesService = bestcoursesService;
            _coursesService = coursesService;
            _welcomeInformationsService = welcomeInformationsService;
            _skillsService = skillsService;
            _instructorsService = instructorsService;
            _studentsSayService = studentsSayService;
            _headerService = headerService;
        }

        public IActionResult Index()
        {
            var header = _headerService.GetAllHeader();
            var bestCourses = _bestcoursesService.GetAllBestCourses();
            var courses = new List<CoursesDto>();
            //IQueryable<List<CoursesDto>> courses;
            foreach (var course in bestCourses)
            {
                var courseDto = _coursesService.GetByIdCourses(course.CourseId);
                courses.Add((CoursesDto)courseDto);
            }
            var welcome = _welcomeInformationsService.GetAllWelcomeInformations();
            var skills = _skillsService.GetAllSkills();
            var instruct = _instructorsService.GetAllInstructors();
            var studentSay = _studentsSayService.GetAllStudentsSay();
            //welcome abaout skills courses  InstructorsDto Testimonial
            return View(Tuple.Create((List<CoursesDto>)courses, (List<WelcomeInformationsDto>)welcome, (List<SkillsDto>)skills, (List<InstructorsDto>)instruct, (List<StudentsSayDto>)studentSay, (List<HeaderDto>)header));
        }


    }
}
