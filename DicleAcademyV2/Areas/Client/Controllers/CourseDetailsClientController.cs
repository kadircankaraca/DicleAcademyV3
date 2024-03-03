using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class CourseDetailsClientController : Controller
    {
        public async Task<IActionResult> AddCourseDetailsClient()
        {
            string url = GenerateClient.Client.BaseAddress + "CourseDetails/AddCourseDetails";
            string url2 = GenerateClient.Client.BaseAddress + "CourseDetails/GetCategoryList";
            string url3 = GenerateClient.Client.BaseAddress + "CourseDetails/GetCourseList";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
            HttpResponseMessage response2 = GenerateClient.Client.GetAsync($"{url2}").Result;
            HttpResponseMessage response3 = GenerateClient.Client.GetAsync($"{url3}").Result;
            if (response.IsSuccessStatusCode)
            {
                List<CoursesCategoriesDto> categoryList = await response2.Content.ReadFromJsonAsync<List<CoursesCategoriesDto>>();
                List<CoursesDto> courseList = await response3.Content.ReadFromJsonAsync<List<CoursesDto>>();

                if (response.IsSuccessStatusCode)
                {
                    return View("AddCourseDetailsClient", Tuple.Create(courseList, categoryList));
                }
                else return RedirectToAction("Login", "User");
            }

            if (response.IsSuccessStatusCode) return View("AddCourseDetailsClient");
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> AddCourseDetailsClientPost(CourseDetailsDto courseDetails, string courseDescriptionEn, string courseLocationEn)
        {
            string url = GenerateClient.Client.BaseAddress + "CourseDetails/AddCourseDetailsPost";

            var content = new MultipartFormDataContent();

            // courseDetails objesini JSON'a dönüştürüp ekleyin
            var jsonContent = new StringContent(JsonSerializer.Serialize(courseDetails), Encoding.UTF8, "application/json");
            content.Add(jsonContent, "courseDetails");

            // courseDescriptionEn ve courseLocationEn değerlerini ekleyin
            content.Add(new StringContent(courseDescriptionEn), "courseDescriptionEn");
            content.Add(new StringContent(courseLocationEn), "courseLocationEn");

            // JSON içeriğini MultipartFormDataContent'e ekleyin
            HttpResponseMessage response = await GenerateClient.Client.PostAsync(url, content);


            if (response.IsSuccessStatusCode)
            {
                var success = await response.Content.ReadFromJsonAsync<bool>();


                if (success)
                    ViewBag.Message = "Başarılı";
                else
                    ViewBag.Message = "Başarısız";

                return View("AddCourseDetailsClient");
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}
