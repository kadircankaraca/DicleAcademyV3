using Entities.ModelsDto;

namespace Services.Contracts
{
    public interface IContactUsService
    {
        IEnumerable<ContactUsDto> GetAllContactUs();
        ContactUsDto GetByIdContactUs(int id);
        ContactUsDto CreateContactUs(ContactUsDto contactUsDto);
        void UpdateContactUs(ContactUsDto contactUsDto);
        void DeleteContactUs(int id);
    }
}
