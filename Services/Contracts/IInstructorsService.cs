using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface IInstructorsService
	{
		IEnumerable<InstructorsDto> GetAllInstructors();
		InstructorsDto GetByIdInstructors(int id);
		InstructorsDto CreateInstructors(InstructorsDto instructorsDto);
		void UpdateInstructors(InstructorsDto instructorsDto);
		void DeleteInstructors(int id);
	}
}
