using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface ICourseDetailsService
	{
		IEnumerable<CourseDetailsDto> GetAllCourseDetails();
		CourseDetailsDto GetByIdCourseDetails(int id);
		CourseDetailsDto CreateCourseDetails(CourseDetailsDto courseDetailsDto);
		void UpdateCourseDetails(CourseDetailsDto courseDetailsDto);
		void Delete(int id);
	}
}
