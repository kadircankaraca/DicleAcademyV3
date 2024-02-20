using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface ICoursesCategoriesService
	{
		IEnumerable<CoursesCategoriesDto> GetAllCoursesCategories();
		CoursesCategoriesDto GetByIdCoursesCategories(int id);
		CoursesCategoriesDto CreateCoursesCategories(CoursesCategoriesDto coursesCategoriesDto);
		void UpdateCoursesCategories(CoursesCategoriesDto coursesCategoriesDto);
		void DeleteCoursesCategories(int id);
	}
}
