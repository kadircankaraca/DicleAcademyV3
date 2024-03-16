using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly ICoursesService _coursesService;
        public ContactUsController(IContactUsService contactUsService, ICoursesService coursesService)
        {
            _contactUsService = contactUsService;
            _coursesService = coursesService;

        }
        public List<ContactUsDto> ShowContactUs()
        {
            List<ContactUsDto> contactUsList = new List<ContactUsDto>();
            contactUsList = _contactUsService.GetAllContactUs().ToList();

            return contactUsList;
        }

        public List<ContactUsDto> DeleteContactUs(int contactUsId)
        {
            List<ContactUsDto> contactUsList = new List<ContactUsDto>();     
            _contactUsService.DeleteContactUs(contactUsId);
            contactUsList = _contactUsService.GetAllContactUs().ToList();

            return contactUsList;
        }
        public List<CoursesDto> GetCourseList()
        {
            List<CoursesDto> courseList = _coursesService.GetAllCourses().ToList();
            return courseList;
        }
    }
}
