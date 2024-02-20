using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface IGetInTouchService
	{
		IEnumerable<GetInTouchDto> GetAllGetInTouch();
		GetInTouchDto GetByIdGetInTouch(int id);
		GetInTouchDto CreateGetInTouch(GetInTouchDto getInTouchDto);
		void UpdateGetInTouch(GetInTouchDto getInTouchDto);
		void DeleteGetInTouch(int id);
	}
}
