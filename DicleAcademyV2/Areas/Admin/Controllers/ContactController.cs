using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult ShowContact()
        {
            List<ContactDto> contactList = new List<ContactDto>();
            contactList = _contactService.GetAllContact().ToList();

            return View(contactList);
        }
        public IActionResult AddContact()
        {
            return View();
        }
        public IActionResult AddContactPost(ContactDto contactDto)
        {
            ContactDto incomingDto = _contactService.CreateContact(contactDto);

            if (incomingDto is not null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            return View("AddContact");
        }
        public IActionResult UpdateContactPost(ContactDto contactDto)
        {
            _contactService.UpdateContact(contactDto);

            ViewBag.Message = "Başarılı";

            List<ContactDto> contactList = new List<ContactDto>();
            contactList = _contactService.GetAllContact().ToList();

            return View("ShowContact", contactList);
        }
        public IActionResult UpdateContact(int contactId)
        {
            ContactDto contactDto = new ContactDto();

            contactDto = _contactService.GetByIdContact(contactId);

            return View(contactDto);
        }
        public IActionResult DeleteContact(int contactId)
        {
            ContactDto contactDto = new ContactDto();
            List<ContactDto> contactList = new List<ContactDto>();

            _contactService.DeleteContact(contactId);
            contactDto = _contactService.GetByIdContact(contactId);

            if (contactDto is null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            contactList = _contactService.GetAllContact().ToList();

            return View("ShowContact", contactList);
        }
    }
}
