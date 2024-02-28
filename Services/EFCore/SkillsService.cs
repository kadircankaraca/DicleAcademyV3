using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore
{
	public class SkillsService : ISkillsService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		public SkillsService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<SkillsDto> GetAllSkills()
		{
			var skills = _repository.Skills.GenericRead(false);
			var skillsDto = _mapper.Map<IEnumerable<SkillsDto>>(skills);
			return skillsDto;
		}

		public SkillsDto GetByIdSkills(int id)
		{
			var skill = _repository.Skills.GetSkills(id, false).SingleOrDefault();
			var skillDto = _mapper.Map<SkillsDto>(skill);
			return skillDto;
		}

		public SkillsDto CreateSkills(SkillsDto skillsDto)
		{
			var skillEntity = _mapper.Map<Skills>(skillsDto);
			_repository.Skills.GenericCreate(skillEntity);
			_repository.Save();
			var createdSkillDto = _mapper.Map<SkillsDto>(skillEntity);
			return createdSkillDto;
		}

		public void UpdateSkills(SkillsDto skillsDto)
		{
			var updateSkill = _repository.Skills.GetSkills(skillsDto.SkillId, false).SingleOrDefault();
			if (updateSkill != null)
			{
				updateSkill = _mapper.Map<Skills>(skillsDto);
				_repository.Skills.GenericUpdate(updateSkill);
				_repository.Save();
			}
		}

		public void DeleteSkills(int id)
		{
			var delSkill = _repository.Skills.GetSkills(id, false).SingleOrDefault();
			if (delSkill != null)
			{
				_repository.Skills.GenericDelete(delSkill);
				_repository.Save();
			}
		}
	}
}
