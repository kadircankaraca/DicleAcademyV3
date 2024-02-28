using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly ICoursesService _coursesService;
        public ContactUsController(IContactUsService contactUsService, ICoursesService coursesService)
        {
            _contactUsService = contactUsService;
            _coursesService = coursesService;

        }
        public IActionResult ShowContactUs()
        {
            List<CoursesDto> coursesList = new List<CoursesDto>();
            List<ContactUsDto> contactUsList = new List<ContactUsDto>();

            contactUsList = _contactUsService.GetAllContactUs().ToList();
            coursesList = _coursesService.GetAllCourses().ToList();

            return View(Tuple.Create(coursesList, contactUsList));
        }

        public IActionResult DeleteContactUs(int contactUsId)
        {
            ContactUsDto contactUsDto = new ContactUsDto();
            List<CoursesDto> coursesList = new List<CoursesDto>();
            List<ContactUsDto> contactUsList = new List<ContactUsDto>();
             
            _contactUsService.DeleteContactUs(contactUsId);
            contactUsDto = _contactUsService.GetByIdContactUs(contactUsId);

            if (contactUsDto is null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            contactUsList = _contactUsService.GetAllContactUs().ToList();
            coursesList = _coursesService.GetAllCourses().ToList();

            return View("ShowContactUs", Tuple.Create(coursesList, contactUsList));
        }
    }
}
