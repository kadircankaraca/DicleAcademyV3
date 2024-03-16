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
        public bool AddSkill()  
        {
            return true;
        }
        public bool AddSkillPost([FromBody] SkillsDto skillsDto)
        {
            SkillsDto incomingDto = _skillsService.CreateSkills(skillsDto);

            if (incomingDto is not null) return true;
            else return false;
        }
        public List<SkillsDto> ShowSkill()
        {
            List<SkillsDto> skillList = _skillsService.GetAllSkills().ToList();

            return skillList;
        }
        public List<SkillsDto> DeleteSkill(int skillId)
        {
            SkillsDto skill = _skillsService.GetByIdSkills(skillId);

            if (skill is not null) _skillsService.DeleteSkills(skillId);

            skill = _skillsService.GetByIdSkills(skillId);
            List<SkillsDto> skillList = _skillsService.GetAllSkills().ToList();

            return skillList;
        }
        public SkillsDto UpdateSkill(int skillId)
        {
            SkillsDto skill = _skillsService.GetByIdSkills(skillId);
            return skill;
        }
        public List<SkillsDto> UpdateSkillPost([FromBody] SkillsDto skill, [FromBody] string newSkillImage)
        {
            if (string.IsNullOrEmpty(newSkillImage)) skill.SkillImage = _skillsService.GetByIdSkills(skill.SkillId).SkillImage;
            else skill.SkillImage = newSkillImage;

            _skillsService.UpdateSkills(skill);
            List<SkillsDto> skillList = _skillsService.GetAllSkills().ToList();

            return skillList;
        }
    }
}
