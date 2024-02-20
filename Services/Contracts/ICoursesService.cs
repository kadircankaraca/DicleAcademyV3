using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface ICoursesService
	{
		IEnumerable<CoursesDto> GetAllCourses();
		CoursesDto GetByIdCourses(int id);
		CoursesDto CreateCourses(CoursesDto coursesDto);
		void UpdateCourses(CoursesDto coursesDto);
		void DeleteCourses(int id);
		List<CoursesDto> GetCoursesByCategoryId(int id);
	}
}
