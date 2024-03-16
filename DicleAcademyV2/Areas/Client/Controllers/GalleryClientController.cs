using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class GalleryClientController : Controller
    {
        public IActionResult AddGalleryClient()
        {
            string url = GenerateClient.Client.BaseAddress + "Gallery/AddGallery";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;

            if (response.IsSuccessStatusCode) return View("AddGalleryClient");
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> AddGalleryClientPost(IFormFile GalleryImage)
        {
            string url = GenerateClient.Client.BaseAddress + "Gallery/AddGalleryPost";

            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(GalleryImage.OpenReadStream()), "GalleryImage", GalleryImage.FileName);

            HttpResponseMessage response = await GenerateClient.Client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                bool api = await response.Content.ReadFromJsonAsync<bool>();
                if (api) ViewBag.Message = "Başarılı";
                else ViewBag.Message = "Başarısız";
                return View("AddGalleryClient");
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> ShowGalleryClient()
        {
            string url = GenerateClient.Client.BaseAddress + "Gallery/ShowGallery";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
            if (response.IsSuccessStatusCode)
            {
                List<GalleryDto> api = await response.Content.ReadFromJsonAsync<List<GalleryDto>>();
                return View("ShowGalleryClient", api);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> DeleteGalleryClient(int galleryId)
        {
            string url = GenerateClient.Client.BaseAddress + "Gallery/DeleteGallery";

            HttpResponseMessage response = await GenerateClient.Client.DeleteAsync($"{url}?galleryId={galleryId}");
            if (response.IsSuccessStatusCode)
            {
                List<GalleryDto> api = await response.Content.ReadFromJsonAsync<List<GalleryDto>>();
                if (api.Count > 0)
                {
                    if (api.FirstOrDefault().GalleryId != galleryId) ViewBag.Message = "Başarılı";
                    else ViewBag.Message = "Başarısız";
                }
                else ViewBag.Message = "Başarılı";
                return View("ShowGalleryClient", api);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateGalleryClient(int galleryId)
        {
            GalleryDto galleryDto = new GalleryDto();
            string url = GenerateClient.Client.BaseAddress + "Gallery/UpdateGallery";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}?galleryId={galleryId}").Result;
            if (response.IsSuccessStatusCode)
            {
                GalleryDto api = await response.Content.ReadFromJsonAsync<GalleryDto>();
                return View("UpdateGalleryClient", api);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateGalleryClientPost(int galleryId, IFormFile newGalleryImage)
        {
            if(newGalleryImage is not null)
            {
                string url = GenerateClient.Client.BaseAddress + "Gallery/UpdateGalleryPost";

                using var content = new MultipartFormDataContent();
                content.Add(new StringContent(galleryId.ToString()), "galleryId");
                content.Add(new StreamContent(newGalleryImage.OpenReadStream()), "newGalleryImage", newGalleryImage.FileName);

                HttpResponseMessage response = await GenerateClient.Client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    List<GalleryDto> api = await response.Content.ReadFromJsonAsync<List<GalleryDto>>();
                    if (api.FirstOrDefault().GalleryId != 0) ViewBag.Message = "Başarılı";
                    else ViewBag.Message = "Başarısız";
                    return View("ShowGalleryClient", api);
                }
                else
                    return RedirectToAction("Login", "User");
            }
            else
            {
                string url = GenerateClient.Client.BaseAddress + "Gallery/ShowGallery";

                HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
                if (response.IsSuccessStatusCode)
                {
                    List<GalleryDto> api = await response.Content.ReadFromJsonAsync<List<GalleryDto>>();
                    return View("ShowGalleryClient", api);
                }
                else return RedirectToAction("Login", "User");

            }
            
        }
    }
}
