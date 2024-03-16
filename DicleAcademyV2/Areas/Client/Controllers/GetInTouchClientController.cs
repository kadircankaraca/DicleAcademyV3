using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class GetInTouchClientController : Controller
    {
        public IActionResult AddGetInTouchClient()
        {
            string url = GenerateClient.Client.BaseAddress + "GetInTouch/AddGetInTouch";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
            if (response.IsSuccessStatusCode)
            {
                GetInTouchDto getInTouchDto = new GetInTouchDto();
                return View("AddGetInTouchClient", getInTouchDto);

            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> AddGetInTouchClientPost(GetInTouchDto incomingGetInTouchDto)
        {
            string url = GenerateClient.Client.BaseAddress + "GetInTouch/AddGetInTouchPost";

            GetInTouchDto newGetInTouchDto = new GetInTouchDto();
            var jsonContent = new StringContent(JsonSerializer.Serialize(incomingGetInTouchDto), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await GenerateClient.Client.PostAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var success = await response.Content.ReadFromJsonAsync<bool>();
                if (success) ViewBag.Message = "Başarılı";
                else ViewBag.Message = "Başarısız";
                return View("AddGetInTouchClient", newGetInTouchDto);
            }
            else
                return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> ShowGetInTouchClient()
        {
            string url = GenerateClient.Client.BaseAddress + "GetInTouch/ShowGetInTouch";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;

            if (response.IsSuccessStatusCode)
            {
                List<GetInTouchDto> getInTouchList = await response.Content.ReadFromJsonAsync<List<GetInTouchDto>>();
                return View("ShowGetInTouchClient", getInTouchList);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> DeleteGetInTouchClient(int getInTouchId)
        {
            string url = GenerateClient.Client.BaseAddress + "GetInTouch/DeleteGetInTouch";

            HttpResponseMessage response = await GenerateClient.Client.DeleteAsync($"{url}?getInTouchId={getInTouchId}");
            if (response.IsSuccessStatusCode)
            {
                List<GetInTouchDto> getInTouchList = await response.Content.ReadFromJsonAsync<List<GetInTouchDto>>();
                if (getInTouchList.Count > 0)
                {
                    if (getInTouchList.FirstOrDefault().GetInTouchId != getInTouchId) ViewBag.Message = "Başarılı";
                    else ViewBag.Message = "Başarısız";
                }
                else ViewBag.Message = "Başarılı";

                return View("ShowGetInTouchClient", getInTouchList);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateGetInTouchClient(int getInTouchId)
        {
            string url = GenerateClient.Client.BaseAddress + "GetInTouch/UpdateGetInTouch";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}?getInTouchId={getInTouchId}").Result;

            if (response.IsSuccessStatusCode)
            {
                GetInTouchDto getInTouchDto = await response.Content.ReadFromJsonAsync<GetInTouchDto>();
                return View("UpdateGetInTouchClient", getInTouchDto);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateGetInTouchClientPost(GetInTouchDto getInTouchDto)
        {
            string url = GenerateClient.Client.BaseAddress + "GetInTouch/UpdateGetInTouchPost";

            var jsonContent = new StringContent(JsonSerializer.Serialize(getInTouchDto), Encoding.UTF8, "application/json");


            HttpResponseMessage response = await GenerateClient.Client.PutAsync(url, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                List<GetInTouchDto> getInTouchList = await response.Content.ReadFromJsonAsync<List<GetInTouchDto>>();
                return View("ShowGetInTouchClient", getInTouchList);
            }
            else return RedirectToAction("Login", "User");
        }
    }
}
