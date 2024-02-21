using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademy.Controllers
{
    public class ContactController : Controller
    {
        private readonly IGetInTouchService _getInTouchService;
        private readonly IContactService _contactService;
        private readonly ICoursesService _coursesService;
        public ContactController(IGetInTouchService getInTouchService, IContactService contactService, ICoursesService coursesService)
        {
            _getInTouchService = getInTouchService;
            _contactService = contactService;
            _coursesService = coursesService;
        }

        public IActionResult Index()
        {
            var getInTouch = _getInTouchService.GetAllGetInTouch().FirstOrDefault();
            var courses = _coursesService.GetAllCourses();
            return View("ContactIndex", Tuple.Create(getInTouch, (List<CoursesDto>)courses));
        }
        [HttpPost]
        public IActionResult PostForm(ContactUsDto contactDto)
        {

            return RedirectToAction("Index");
        }
    }
}
