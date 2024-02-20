using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore
{
	public class CoursesService : ICoursesService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		public CoursesService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<CoursesDto> GetAllCourses()
		{
			var courses = _repository.Courses.GenericRead(false);
			var coursesDto = _mapper.Map<IEnumerable<CoursesDto>>(courses);
			return coursesDto;
		}

		public CoursesDto GetByIdCourses(int id)
		{
			var course = _repository.Courses.GetCourses(id, false).FirstOrDefault();
			var courseDto = _mapper.Map<CoursesDto>(course);
			return courseDto;
		}

		public List<CoursesDto> GetCoursesByCategoryId(int id) 
		{
            var courses = _repository.Courses.GetCoursesByCategoryId(id);
            var coursesDto = _mapper.Map<List<CoursesDto>>(courses);
            return coursesDto;
        }

		public CoursesDto CreateCourses(CoursesDto coursesDto)
		{
			var course = _mapper.Map<Courses>(coursesDto);
			_repository.Courses.GenericCreate(course);
			_repository.Save();
			var createdCourseDto = _mapper.Map<CoursesDto>(course);
			return createdCourseDto;
		}

		public void UpdateCourses(CoursesDto coursesDto)
		{
			var updateCourse = _repository.Courses
				.GetCourses(coursesDto.CourseId, false).SingleOrDefault();
			if (updateCourse != null)
			{
				var updatedCourse = _mapper.Map<Courses>(coursesDto);
				_repository.Courses.GenericUpdate(updatedCourse);
				_repository.Save();
			}
		}

		public void DeleteCourses(int id)
		{
			var delCourse = _repository.Courses
				.GetCourses(id, false).SingleOrDefault();
			if (delCourse != null)
			{
				_repository.Courses.GenericDelete(delCourse);
				_repository.Save();
			}
		}
	}

}
