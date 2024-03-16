using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class HeaderClientController : Controller
    {
        public IActionResult AddHeaderClient()
        {
            string url = GenerateClient.Client.BaseAddress + "Header/AddHeader";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;

            if (response.IsSuccessStatusCode) return View("AddHeaderClient");
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> AddHeaderClientPost(string headerTitle, string headerDescription, IFormFile headerImage, string headerTitleEn, string headerDescriptionEn)
        {
            string url = GenerateClient.Client.BaseAddress + "Header/AddHeaderPost";

            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(headerTitle), "headerTitle");
            content.Add(new StringContent(headerDescription), "headerDescription");
            content.Add(new StreamContent(headerImage.OpenReadStream()), "image", headerImage.FileName);
            content.Add(new StringContent(headerTitleEn), "headerTitleEn");
            content.Add(new StringContent(headerDescriptionEn), "headerDescriptionEn");



            HttpResponseMessage response = await GenerateClient.Client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                bool api = await response.Content.ReadFromJsonAsync<bool>();
                if (api) ViewBag.Message = "Başarılı";
                else ViewBag.Message = "Başarısız";
                return View("AddHeaderClient");
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> ShowHeaderClient()
        {
            string url = GenerateClient.Client.BaseAddress + "Header/ShowHeader";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
            if (response.IsSuccessStatusCode)
            {
                List<HeaderDto> api = await response.Content.ReadFromJsonAsync<List<HeaderDto>>();
                return View("ShowHeaderClient", api);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> DeleteHeaderClient(int headerId)
        {
            string url = GenerateClient.Client.BaseAddress + "Header/DeleteHeader";

            HttpResponseMessage response = await GenerateClient.Client.DeleteAsync($"{url}?headerId={headerId}");
            if (response.IsSuccessStatusCode)
            {
                List<HeaderDto> api = await response.Content.ReadFromJsonAsync<List<HeaderDto>>();
                if (api.Count > 0)
                {
                    if (api.FirstOrDefault().HeaderId != headerId) ViewBag.Message = "Başarılı";
                    else ViewBag.Message = "Başarısız";
                }
                else ViewBag.Message = "Başarılı";
                return View("ShowHeaderClient", api);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateHeaderClient(int headerId)
        {
            HeaderDto headerDto = new HeaderDto();
            string url = GenerateClient.Client.BaseAddress + "Header/UpdateHeader";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}?headerId={headerId}").Result;
            if (response.IsSuccessStatusCode)
            {
                HeaderDto api = await response.Content.ReadFromJsonAsync<HeaderDto>();
                return View("UpdateHeaderClient", api);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateHeaderClientPost(int headerId, string headerTitle, string headerDescription, IFormFile newHeaderImage)
        {
            string url = GenerateClient.Client.BaseAddress + "Header/UpdateHeaderPost";

            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(headerId.ToString()), "headerId");
            content.Add(new StringContent(headerTitle), "headerTitle");
            content.Add(new StringContent(headerDescription), "headerDescription");

            if (newHeaderImage is not null)
            {
                content.Add(new StreamContent(newHeaderImage.OpenReadStream()), "newHeaderImage", newHeaderImage.FileName);
            }
            else
            {
                url = GenerateClient.Client.BaseAddress + "Header/UpdateHeaderPostNoImage";
               
            }



            HttpResponseMessage response = await GenerateClient.Client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                List<HeaderDto> api = await response.Content.ReadFromJsonAsync<List<HeaderDto>>();
                if (api.FirstOrDefault().HeaderId != 0) ViewBag.Message = "Başarılı";
                else ViewBag.Message = "Başarısız";
                return View("ShowHeaderClient", api);
            }
            else
                return RedirectToAction("Login", "User");
        }
    }
}
