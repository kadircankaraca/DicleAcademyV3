using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademy.Controllers
{
    public class TeamsController : Controller
    {
        private readonly IInstructorsService _instructorsService;

        public TeamsController(IInstructorsService instructorsService)
        {
            _instructorsService = instructorsService;
        }

        public IActionResult Index()
        {
         var instruc= _instructorsService.GetAllInstructors();
            return View("TeamsIndex" , instruc);
        }
    }
}
