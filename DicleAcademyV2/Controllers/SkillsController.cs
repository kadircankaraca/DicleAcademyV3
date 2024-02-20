using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademy.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillsService _skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }

        public IActionResult Index()
        { 
          var skills=  _skillsService.GetAllSkills();
            return View("SkillsIndex" , skills);
        }
    }
}
