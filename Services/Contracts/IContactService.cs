using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface IContactService
	{
		IEnumerable<ContactDto> GetAllContact();
		ContactDto GetByIdContact(int id);
		ContactDto CreateContact(ContactDto contactDto);
		void UpdateContact(ContactDto contactDto);
		void DeleteContact(int id);
	}
}
