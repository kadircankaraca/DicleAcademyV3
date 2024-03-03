using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public List<ContactDto> ShowContact()
        {
            List<ContactDto> contactList = new List<ContactDto>();
            contactList = _contactService.GetAllContact().ToList();

            return contactList;
        }
        public bool AddContact()
        {
            return true;
        }
        public bool AddContactPost([FromBody] ContactDto contactDto)
        {
            ContactDto incomingDto = _contactService.CreateContact(contactDto);

            if (incomingDto is not null) return true;
            else return false;

        }
        public List<ContactDto> UpdateContactPost([FromBody] ContactDto contactDto)
        {
            _contactService.UpdateContact(contactDto);

            ViewBag.Message = "Başarılı";

            List<ContactDto> contactList = new List<ContactDto>();
            contactList = _contactService.GetAllContact().ToList();

            return contactList;
        }
        public ContactDto UpdateContact(int contactId)
        {
            ContactDto contactDto = new ContactDto();

            contactDto = _contactService.GetByIdContact(contactId);

            return contactDto;
        }
        public List<ContactDto> DeleteContact(int contactId)
        {
            List<ContactDto> contactList = new List<ContactDto>();
            _contactService.DeleteContact(contactId);

            contactList = _contactService.GetAllContact().ToList();

            return contactList;
        }
    }
}
