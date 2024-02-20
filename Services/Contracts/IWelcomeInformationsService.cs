using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface IWelcomeInformationsService
	{
		IEnumerable<WelcomeInformationsDto> GetAllWelcomeInformations();
		WelcomeInformationsDto GetByIdWelcomeInformations(int id);
		WelcomeInformationsDto CreateWelcomeInformations(WelcomeInformationsDto welcomeInformationsDto);
		void UpdateWelcomeInformations(WelcomeInformationsDto welcomeInformationsDto);
		void DeleteWelcomeInformations(int id);
	}
}
