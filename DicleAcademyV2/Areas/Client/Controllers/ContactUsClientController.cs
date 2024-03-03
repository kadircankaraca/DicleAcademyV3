using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class ContactUsClientController : Controller
    {
        public async Task<IActionResult> ShowContactUsClient()
        {
            string url = GenerateClient.Client.BaseAddress + "ContactUs/ShowContactUs";
            string url2 = GenerateClient.Client.BaseAddress + "ContactUs/GetCourseList";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
            HttpResponseMessage response2 = await GenerateClient.Client.GetAsync(url2);

            if (response.IsSuccessStatusCode)
            {
                List<ContactUsDto> contactUsList = await response.Content.ReadFromJsonAsync<List<ContactUsDto>>();
                List<CoursesDto> courseList = await response2.Content.ReadFromJsonAsync<List<CoursesDto>>();
                return View("ShowContactUsClient", Tuple.Create(courseList, contactUsList));
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> DeleteContactUsClient(int contactUsId)
        {
            string url = GenerateClient.Client.BaseAddress + "ContactUs/DeleteContactUs";
            string url2 = GenerateClient.Client.BaseAddress + "ContactUs/GetCourseList";

            HttpResponseMessage response = await GenerateClient.Client.DeleteAsync($"{url}?contactUsId={contactUsId}");
            HttpResponseMessage response2 = await GenerateClient.Client.GetAsync(url2);
            if (response.IsSuccessStatusCode)
            {
                List<ContactUsDto> contactUsList = await response.Content.ReadFromJsonAsync<List<ContactUsDto>>();
                List<CoursesDto> courseList = await response2.Content.ReadFromJsonAsync<List<CoursesDto>>();
                if (contactUsList.Count > 0)
                {
                    if (contactUsList.FirstOrDefault().ContactUsId != contactUsId) ViewBag.Message = "Başarılı";
                    else ViewBag.Message = "Başarısız";
                }
                else ViewBag.Message = "Başarılı";

                return View("ShowContactUsClient", Tuple.Create(courseList, contactUsList));
            }
            else return RedirectToAction("Login", "User");
        }


    }
}
