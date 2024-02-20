using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        public IActionResult AddSkill()
        {
            return View();
        }
        public IActionResult ShowSkill()
        {
            return View();
        }
    }
}
