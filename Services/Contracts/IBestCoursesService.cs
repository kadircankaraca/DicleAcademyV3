using System.Collections;
using Entities.Models;
using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface IBestCoursesService
	{
		IEnumerable<BestCoursesDto> GetAllBestCourses();
		BestCoursesDto GetByIdBestCourses(int id);
		BestCoursesDto CreateBestCourses(BestCoursesDto bestCoursesDto);
		void UpdateBestCourses(BestCoursesDto bestCoursesDto);
		void DeleteBestCourses(int id);
	}
}
