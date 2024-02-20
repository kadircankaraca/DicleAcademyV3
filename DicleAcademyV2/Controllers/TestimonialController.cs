using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademy.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IStudentsSayService _studentsSayService;

        public TestimonialController(IStudentsSayService studentsSayService)
        {
            _studentsSayService = studentsSayService;
        }

        public IActionResult Index()
        {
           var studentSay= _studentsSayService.GetAllStudentsSay();
            return View("TestimonialIndex" , studentSay);
        }
    }
}
