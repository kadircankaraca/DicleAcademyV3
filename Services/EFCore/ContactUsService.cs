using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore;
public class ContactUsService : IContactUsService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ContactUsService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<ContactUsDto> GetAllContactUs()
    {
        var contact = _repository.ContactUs.GenericRead(false);
        var contactDto = _mapper.Map<IEnumerable<ContactUsDto>>(contact);
        return contactDto;
    }

    public ContactUsDto GetByIdContactUs(int id)
    {
        var contact = _repository.ContactUs.GetContactUs(id, false).SingleOrDefault();
        var contactDto = _mapper.Map<ContactUsDto>(contact);
        return contactDto;
    }

    public ContactUsDto CreateContactUs(ContactUsDto contactDto)
    {
        var contact = _mapper.Map<ContactUs>(contactDto);
        _repository.ContactUs.GenericCreate(contact);
        _repository.Save();
        return _mapper.Map<ContactUsDto>(contact);
    }

    public void UpdateContactUs(ContactUsDto contactDto)
    {
        var contactUpdate = _repository.ContactUs.GetContactUs(contactDto.ContactUsId, false).SingleOrDefault();
        if (contactUpdate != null)
        {
            var contact = _mapper.Map<ContactUs>(contactDto);
            _repository.ContactUs.GenericUpdate(contact);
            _repository.Save();
        }
    }

    public void DeleteContactUs(int id)
    {
        var delContact = _repository.ContactUs.GetContactUs(id, false).SingleOrDefault();
        if (delContact != null)
        {
            _repository.ContactUs.GenericDelete(delContact);
            _repository.Save();
        }
    }

    
}
