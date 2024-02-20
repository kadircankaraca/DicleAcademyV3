
using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface IAboutUsService
	{
		IEnumerable<AboutUsDto> GetAllAboutUs();
		AboutUsDto GetByIdAboutUs(int id);
		AboutUsDto CreateAboutUs(AboutUsDto aboutUsDto);
		void UpdateAboutUs(AboutUsDto aboutUsDto);
		void DeleteAboutUs(int id);
	}

}
