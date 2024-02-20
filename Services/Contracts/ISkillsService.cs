using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface ISkillsService
	{
		IEnumerable<SkillsDto> GetAllSkills();
		SkillsDto GetByIdSkills(int id);
		SkillsDto CreateSkills(SkillsDto skillsDto);
		void UpdateSkills(SkillsDto skillsDto);
		void DeleteSkills(int id);
	}
}
