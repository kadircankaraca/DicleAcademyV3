using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class CourseClientController : Controller
    {
        public async Task<IActionResult> AddCourseClient()
        {
            string url = GenerateClient.Client.BaseAddress + "Course/AddCourse";
            string url2 = GenerateClient.Client.BaseAddress + "Course/GetCategoryList";
            string url3 = GenerateClient.Client.BaseAddress + "Course/GetInstructorList";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
            HttpResponseMessage response2 = GenerateClient.Client.GetAsync($"{url2}").Result;
            HttpResponseMessage response3 = GenerateClient.Client.GetAsync($"{url3}").Result;
            if (response.IsSuccessStatusCode)
            {
                List<CoursesCategoriesDto> categoryList = await response2.Content.ReadFromJsonAsync<List<CoursesCategoriesDto>>();
                List<InstructorsDto> instructorList = await response3.Content.ReadFromJsonAsync<List<InstructorsDto>>();

                if (response.IsSuccessStatusCode)
                {
                    return View("AddCourseClient", Tuple.Create(instructorList, categoryList));
                }
                else return RedirectToAction("Login", "User");
            }

            if (response.IsSuccessStatusCode) return View("AddCourseClient");
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> AddCourseClientPost(CoursesDto courseDto)
        {
            try
            {
                string url = GenerateClient.Client.BaseAddress + "Course/AddCoursePost";

                courseDto.Image = "asd";
                var jsonContent = JsonSerializer.Serialize(courseDto);

                var response = await GenerateClient.Client.PostAsJsonAsync(url, jsonContent);


                if (response.IsSuccessStatusCode)
                {
                    var success = await response.Content.ReadFromJsonAsync<bool>();


                    if (success)
                        ViewBag.Message = "Başarılı";
                    else
                        ViewBag.Message = "Başarısız";

                    return View("AddCourseClient");
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return Ok();
        }

    }
}
