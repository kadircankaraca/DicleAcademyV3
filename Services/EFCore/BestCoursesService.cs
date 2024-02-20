using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore
{
	public class BestCoursesService : IBestCoursesService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		public BestCoursesService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<BestCoursesDto> GetAllBestCourses()
		{
			var bestCoursesList = _repository.BestCourses.GenericRead(false);
			var bestCoursesDtoList = _mapper.Map<IEnumerable<BestCoursesDto>>(bestCoursesList);
			return bestCoursesDtoList;
		}

		public BestCoursesDto GetByIdBestCourses(int id)
		{
			var course = _repository.BestCourses.GetBestCourses(id, false);
			var bestCoursesDto = _mapper.Map<BestCoursesDto>(course);
			return bestCoursesDto;
		}

		public BestCoursesDto CreateBestCourses(BestCoursesDto bestCoursesDto)
		{
			var createBestCourses = _mapper.Map<BestCourses>(bestCoursesDto);
			_repository.BestCourses.GenericCreate(createBestCourses);
			_repository.Save();
			var createBest= _mapper.Map<BestCoursesDto>(createBestCourses);
			return createBest;
		}

		public void UpdateBestCourses(BestCoursesDto bestCoursesDto)
		{
			var updateBestCourses = _repository.BestCourses.GetBestCourses(bestCoursesDto.BestCourseId, false).SingleOrDefault();

			if (updateBestCourses != null)
			{
				var mapping = _mapper.Map(bestCoursesDto, updateBestCourses);
				_repository.BestCourses.GenericUpdate(updateBestCourses);
				_repository.Save();
			}
		}

		public void DeleteBestCourses(int id)
		{
			var delBestCourses = _repository.BestCourses.GetBestCourses(id, false).SingleOrDefault();

			if (delBestCourses != null)
			{
				_repository.BestCourses.GenericDelete(delBestCourses);
				_repository.Save();
			}
		}
	}

}
