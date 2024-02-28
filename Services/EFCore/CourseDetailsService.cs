using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore
{
	public class CourseDetailsService : ICourseDetailsService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		public CourseDetailsService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
    
		public IEnumerable<CourseDetailsDto> GetAllCourseDetails()
		{
			var courseDetails = _repository.CourseDetails.GenericRead(false);
			var courseDetailsDtos = _mapper.Map<IEnumerable<CourseDetailsDto>>(courseDetails);
			return courseDetailsDtos;
		}

		public CourseDetailsDto GetByIdCourseDetails(int id)
		{
			var courseDetails = _repository.CourseDetails.GetCourseDetails(id, false).FirstOrDefault();
			var courseDetailsDto = _mapper.Map<CourseDetailsDto>(courseDetails);
			return courseDetailsDto;
		}

		public CourseDetailsDto CreateCourseDetails(CourseDetailsDto courseDetailsDto)
		{
			var courseDetails = _mapper.Map<CourseDetails>(courseDetailsDto);
			_repository.CourseDetails.GenericCreate(courseDetails);
			_repository.Save();
			return _mapper.Map<CourseDetailsDto>(courseDetails);
		}

		public void UpdateCourseDetails(CourseDetailsDto courseDetailsDto)
		{
			var updateCourseDetails = _repository.CourseDetails
				.GetCourseDetails(courseDetailsDto.CourseDetailsId, false).SingleOrDefault();
			if (updateCourseDetails != null)
			{
				var upCourseDetails = _mapper.Map<CourseDetails>(courseDetailsDto);
				_repository.CourseDetails.GenericUpdate(upCourseDetails);
				_repository.Save();
			}
		}

		public void Delete(int id)
		{
			var delCourseDetails = _repository.CourseDetails.GetCourseDetails(id, false).SingleOrDefault();
    
			if (delCourseDetails != null)
			{
				_repository.CourseDetails.GenericDelete(delCourseDetails);
				_repository.Save();
			}
		}
	}

}
