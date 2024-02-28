using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly ISkillsService _skillsService;
        public SkillController(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }
        public IActionResult AddSkill()
        {
            return View();
        }
        public IActionResult AddSkillPost(SkillsDto skillsDto, string skillTitleEn, string skillDescriptionEn)
        {
            SkillsDto incomingDto = _skillsService.CreateSkills(skillsDto);

            if (incomingDto is not null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";
            return View("AddSkill");
        }
        public IActionResult ShowSkill()
        {
            List<SkillsDto> skillList = _skillsService.GetAllSkills().ToList();

            return View(skillList);
        }

        public IActionResult DeleteSkill(int skillId)
        {
            List<SkillsDto> skillList = _skillsService.GetAllSkills().ToList();
            SkillsDto skill = _skillsService.GetByIdSkills(skillId);

            if (skill is not null) _skillsService.DeleteSkills(skillId);

            skill = _skillsService.GetByIdSkills(skillId);

            if (skill is null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            return View("ShowSkill", skillList);
        }

        public IActionResult UpdateSkill(int skillId)
        {
            SkillsDto skill = _skillsService.GetByIdSkills(skillId);
            return View(skill);
        }
        public IActionResult UpdateSkillPost(SkillsDto skill, string newSkillImage)
        {
            List<SkillsDto> skillList = _skillsService.GetAllSkills().ToList();
            if (string.IsNullOrEmpty(newSkillImage)) skill.SkillImage = _skillsService.GetByIdSkills(skill.SkillId).SkillImage;
            else skill.SkillImage = newSkillImage;

            _skillsService.UpdateSkills(skill);

            return View("ShowSkill", skillList);
        }
    }
}
