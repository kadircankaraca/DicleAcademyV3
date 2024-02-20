using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore;
public class ContactService : IContactService
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public ContactService(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public IEnumerable<ContactDto> GetAllContact()
	{
		var contact = _repository.Contact.GenericRead(false);
		var contactDto = _mapper.Map<IEnumerable<ContactDto>>(contact);
		return contactDto;
	}

	public ContactDto GetByIdContact(int id)
	{
		var contact = _repository.Contact.GetContact(id,false);
		var contactDto = _mapper.Map<ContactDto>(contact);
		return contactDto;
	}

	public ContactDto CreateContact(ContactDto contactDto)
	{
		var contact = _mapper.Map<Contact>(contactDto);
		_repository.Contact.GenericCreate(contact);
		_repository.Save();
		return _mapper.Map<ContactDto>(contact);
	}

	public void UpdateContact(ContactDto contactDto)
	{
		var contactUpdate = _repository.Contact.GetContact(contactDto.ContactId, false).SingleOrDefault();
		if (contactUpdate!=null)
		{
			var contact = _mapper.Map<Contact>(contactDto);
			_repository.Contact.GenericUpdate(contact);
			_repository.Save();
		}
	}

	public void DeleteContact(int id)
	{
		var delContact = _repository.Contact.GetContact(id, false).SingleOrDefault();
		if (delContact!=null)
		{
			_repository.Contact.GenericDelete(delContact);
			_repository.Save();
		}
	}
}
