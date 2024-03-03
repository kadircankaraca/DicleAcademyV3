using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class AboutUsClientController : Controller
    {
        public IActionResult AddAboutUsClient()
        {
            string url = GenerateClient.Client.BaseAddress + "AboutUs/AddAboutUs";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;

            if (response.IsSuccessStatusCode) return View("AddAboutUsClient");
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> AddAboutUsClientPost(string aboutUsTitle, string aboutUsDescription, IFormFile aboutUsImage)
        {
            string url = GenerateClient.Client.BaseAddress + "AboutUs/AddAboutUsPost";

            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(aboutUsTitle), "aboutUsTitle");
            content.Add(new StringContent(aboutUsDescription), "aboutUsDescription");
            content.Add(new StreamContent(aboutUsImage.OpenReadStream()), "aboutUsImage", aboutUsImage.FileName);

            HttpResponseMessage response = await GenerateClient.Client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                bool api = await response.Content.ReadFromJsonAsync<bool>();
                if (api) ViewBag.Message = "Başarılı";
                else ViewBag.Message = "Başarısız";
                return View("AddAboutUsClient");
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> ShowAboutUsClient()
        {
            string url = GenerateClient.Client.BaseAddress + "AboutUs/ShowAboutUs";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
            if(response.IsSuccessStatusCode)
            {
                List<AboutUsDto> api = await response.Content.ReadFromJsonAsync<List<AboutUsDto>>();
                return View("ShowAboutUsClient", api);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> DeleteClient(int aboutUsId)
        {
            string url = GenerateClient.Client.BaseAddress + "AboutUs/DeleteAboutUs";

            HttpResponseMessage response = await GenerateClient.Client.DeleteAsync($"{url}?aboutUsId={aboutUsId}");
            if (response.IsSuccessStatusCode)
            {
                List<AboutUsDto> api = await response.Content.ReadFromJsonAsync<List<AboutUsDto>>();
                if (api.Count > 0)
                {
                    if (api.FirstOrDefault().AboutUsId != aboutUsId) ViewBag.Message = "Başarılı";
                    else ViewBag.Message = "Başarısız";
                }
                else ViewBag.Message = "Başarılı";
                return View("ShowAboutUsClient", api);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateAboutUsClient(int aboutUsId)
        {
            AboutUsDto aboutUsDto = new AboutUsDto();
            string url = GenerateClient.Client.BaseAddress + "AboutUs/UpdateAboutUs";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}?aboutUsId={aboutUsId}").Result;
            if (response.IsSuccessStatusCode)
            {
                AboutUsDto api = await response.Content.ReadFromJsonAsync<AboutUsDto>();
                return View("UpdateAboutUsClient", api);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateAboutUsClientPost(int aboutUsId, string aboutUsTitle, string aboutUsDescription, IFormFile newAboutUsImage)
        {
            string url = GenerateClient.Client.BaseAddress + "AboutUs/UpdateAboutUsPost";

            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(aboutUsId.ToString()), "aboutUsId");
            content.Add(new StringContent(aboutUsTitle), "aboutUsTitle");
            content.Add(new StringContent(aboutUsDescription), "aboutUsDescription");
            content.Add(new StreamContent(newAboutUsImage.OpenReadStream()), "newAboutUsImage", newAboutUsImage.FileName);

            HttpResponseMessage response = await GenerateClient.Client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                List<AboutUsDto> api = await response.Content.ReadFromJsonAsync<List<AboutUsDto>>();
                if (api.FirstOrDefault().AboutUsId != 0) ViewBag.Message = "Başarılı";
                else ViewBag.Message = "Başarısız";
                return View("ShowAboutUsClient", api);
            }
            else
                return RedirectToAction("Login", "User");
        }
    }
}
