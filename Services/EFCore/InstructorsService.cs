using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore
{
	public class InstructorsService : IInstructorsService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		public InstructorsService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<InstructorsDto> GetAllInstructors()
		{
			var instructors = _repository.Instructors.GenericRead(false);
			var instructorsDto = _mapper.Map<IEnumerable<InstructorsDto>>(instructors);
			return instructorsDto;
		}

		public InstructorsDto GetByIdInstructors(int id)
		{
			var instructor = _repository.Instructors.GetInstructors(id, false);
			var instructorDto = _mapper.Map<InstructorsDto>(instructor);
			return instructorDto;
		}

		public InstructorsDto CreateInstructors(InstructorsDto instructorsDto)
		{
			var instructorEntity = _mapper.Map<Instructors>(instructorsDto);
			_repository.Instructors.GenericCreate(instructorEntity);
			_repository.Save();
			var createdInstructorDto = _mapper.Map<InstructorsDto>(instructorEntity);
			return createdInstructorDto;
		}

		public void UpdateInstructors(InstructorsDto instructorsDto)
		{
			var updateInstructor = _repository.Instructors
				.GetInstructors(instructorsDto.InstructorId, false).SingleOrDefault();
			if (updateInstructor != null)
			{
				var updatedInstructor = _mapper.Map<Instructors>(updateInstructor);
				_repository.Instructors.GenericUpdate(updatedInstructor);
				_repository.Save();
			}
		}

		public void DeleteInstructors(int id)
		{
			var delInstructor = _repository.Instructors
				.GetInstructors(id, false).SingleOrDefault();
			if (delInstructor != null)
			{
				_repository.Instructors.GenericDelete(delInstructor);
				_repository.Save();
			}
		}
	}
}
