using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class BestCoursesClientController : Controller
    {
        public async Task<IActionResult> AddBestCoursesClient()
        {
            string url = GenerateClient.Client.BaseAddress + "BestCourses/AddBestCourses";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
            if (response.IsSuccessStatusCode)
            {
                List<CoursesDto> list = await response.Content.ReadFromJsonAsync<List<CoursesDto>>();
                if(list.Count > 0)
                {
                    BestCoursesDto bestCoursesDto = new BestCoursesDto();
                    return View("AddBestCoursesClient", Tuple.Create(bestCoursesDto, list));
                }
                else return RedirectToAction("Login", "User");
            }

            if (response.IsSuccessStatusCode) return View("AddBestCoursesClient");
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> AddBestCoursesClientPost(BestCoursesDto incomingBestCoursesDto)
        {
            string url = GenerateClient.Client.BaseAddress + "BestCourses/AddBestCoursesPost"; 
            string url2 = GenerateClient.Client.BaseAddress + "BestCourses/GetCourseList";

            BestCoursesDto newBestCoursesDto = new BestCoursesDto();
            var jsonContent = new StringContent(JsonSerializer.Serialize(incomingBestCoursesDto), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await GenerateClient.Client.PostAsync(url, jsonContent);
            HttpResponseMessage response2 = await GenerateClient.Client.GetAsync(url2);

            if (response.IsSuccessStatusCode)
            {
                var success = await response.Content.ReadFromJsonAsync<bool>();
                var courseList = await response2.Content.ReadFromJsonAsync<List<CoursesDto>>();
                if (success) ViewBag.Message = "Başarılı";
                else ViewBag.Message = "Başarısız";
                return View("AddBestCoursesClient", Tuple.Create(newBestCoursesDto ,courseList));
            }
            else
                return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> ShowBestCoursesClient()
        {
            string url = GenerateClient.Client.BaseAddress + "BestCourses/ShowBestCourses";
            string url2 = GenerateClient.Client.BaseAddress + "BestCourses/GetCourseList";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
            HttpResponseMessage response2 = await GenerateClient.Client.GetAsync(url2);

            if (response.IsSuccessStatusCode)
            {
                List<BestCoursesDto> bestCourseList = await response.Content.ReadFromJsonAsync<List<BestCoursesDto>>();
                List<CoursesDto> courseList = await response2.Content.ReadFromJsonAsync<List<CoursesDto>>();
                return View("ShowBestCoursesClient", Tuple.Create(courseList, bestCourseList));
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> DeleteBestCoursesClient(int bestCoursesId)
        {
            string url = GenerateClient.Client.BaseAddress + "BestCourses/DeleteBestCourses";
            string url2 = GenerateClient.Client.BaseAddress + "BestCourses/GetCourseList";

            HttpResponseMessage response = await GenerateClient.Client.DeleteAsync($"{url}?bestCoursesId={bestCoursesId}");
            HttpResponseMessage response2 = await GenerateClient.Client.GetAsync(url2);
            if (response.IsSuccessStatusCode)
            {
                List<BestCoursesDto> bestCoursesList = await response.Content.ReadFromJsonAsync<List<BestCoursesDto>>();
                List<CoursesDto> courseList = await response2.Content.ReadFromJsonAsync<List<CoursesDto>>();
                if (bestCoursesList.Count > 0)
                {
                    if (bestCoursesList.FirstOrDefault().BestCourseId != bestCoursesId) ViewBag.Message = "Başarılı";
                    else ViewBag.Message = "Başarısız";
                }
                else ViewBag.Message = "Başarılı";

                return View("ShowBestCoursesClient", Tuple.Create(courseList, bestCoursesList));
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateBestCoursesClient(int bestCoursesId)
        {
            string url = GenerateClient.Client.BaseAddress + "BestCourses/UpdateBestCourses";
            string url2 = GenerateClient.Client.BaseAddress + "BestCourses/GetCourseList";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}?bestCoursesId={bestCoursesId}").Result;
            HttpResponseMessage response2 = await GenerateClient.Client.GetAsync(url2);

            if (response.IsSuccessStatusCode)
            {
                BestCoursesDto bestCourseDto = await response.Content.ReadFromJsonAsync<BestCoursesDto>();
                var courseList = await response2.Content.ReadFromJsonAsync<List<CoursesDto>>();
                return View("UpdateBestCoursesClient", Tuple.Create(bestCourseDto, courseList));
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateBestCoursesClientPost(BestCoursesDto bestCoursesDto)
        {
            string url = GenerateClient.Client.BaseAddress + "BestCourses/UpdateBestCoursesPost";
            string url2 = GenerateClient.Client.BaseAddress + "BestCourses/GetCourseList";

            var jsonContent = new StringContent(JsonSerializer.Serialize(bestCoursesDto), Encoding.UTF8, "application/json");


            HttpResponseMessage response = await GenerateClient.Client.PutAsync(url, jsonContent);
            HttpResponseMessage response2 = await GenerateClient.Client.GetAsync(url2);
            if (response.IsSuccessStatusCode)
            {
                List<BestCoursesDto> bestCourseList = await response.Content.ReadFromJsonAsync<List<BestCoursesDto>>();
                var courseList = await response2.Content.ReadFromJsonAsync<List<CoursesDto>>();
                return View("ShowBestCoursesClient", Tuple.Create(courseList, bestCourseList));
            }
            else return RedirectToAction("Login", "User");
        }

    }
}
