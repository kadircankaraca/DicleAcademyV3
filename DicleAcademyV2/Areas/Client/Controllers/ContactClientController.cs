using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class ContactClientController : Controller
    {
        public IActionResult AddContactClient()
        {
            string url = GenerateClient.Client.BaseAddress + "Contact/AddContact";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
            if (response.IsSuccessStatusCode)
            {
                ContactDto contactDto = new ContactDto();
                return View("AddContactClient", contactDto);

            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> AddContactClientPost(ContactDto incomingContactDto)
        {
            string url = GenerateClient.Client.BaseAddress + "Contact/AddContactPost";

            ContactDto newContactDto = new ContactDto();
            var jsonContent = new StringContent(JsonSerializer.Serialize(incomingContactDto), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await GenerateClient.Client.PostAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var success = await response.Content.ReadFromJsonAsync<bool>();
                if (success) ViewBag.Message = "Başarılı";
                else ViewBag.Message = "Başarısız";
                return View("AddContactClient", newContactDto);
            }
            else
                return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> ShowContactClient()
        {
            string url = GenerateClient.Client.BaseAddress + "Contact/ShowContact";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;

            if (response.IsSuccessStatusCode)
            {
                List<ContactDto> contactList = await response.Content.ReadFromJsonAsync<List<ContactDto>>();
                return View("ShowContactClient", contactList);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> DeleteContactClient(int contactId)
        {
            string url = GenerateClient.Client.BaseAddress + "Contact/DeleteContact";

            HttpResponseMessage response = await GenerateClient.Client.DeleteAsync($"{url}?contactId={contactId}");
            if (response.IsSuccessStatusCode)
            {
                List<ContactDto> contactList = await response.Content.ReadFromJsonAsync<List<ContactDto>>();
                if (contactList.Count > 0)
                {
                    if (contactList.FirstOrDefault().ContactId != contactId) ViewBag.Message = "Başarılı";
                    else ViewBag.Message = "Başarısız";
                }
                else ViewBag.Message = "Başarılı";

                return View("ShowContactClient", contactList);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateContactClient(int contactId)
        {
            string url = GenerateClient.Client.BaseAddress + "Contact/UpdateContact";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}?contactId={contactId}").Result;

            if (response.IsSuccessStatusCode)
            {
                ContactDto contactDto = await response.Content.ReadFromJsonAsync<ContactDto>();
                return View("UpdateContactClient", contactDto);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateContactClientPost(ContactDto contactDto)
        {
            string url = GenerateClient.Client.BaseAddress + "Contact/UpdateContactPost";

            var jsonContent = new StringContent(JsonSerializer.Serialize(contactDto), Encoding.UTF8, "application/json");


            HttpResponseMessage response = await GenerateClient.Client.PutAsync(url, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                List<ContactDto> contactList = await response.Content.ReadFromJsonAsync<List<ContactDto>>();
                return View("ShowContactClient", contactList);
            }
            else return RedirectToAction("Login", "User");
        }
    }
}
