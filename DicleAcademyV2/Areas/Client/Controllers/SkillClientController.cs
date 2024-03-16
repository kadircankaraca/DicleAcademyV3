using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Area("Client")]
    public class SkillClientController : Controller
    {
        public IActionResult AddSkillClient()
        {
            string url = GenerateClient.Client.BaseAddress + "Skill/AddSkill";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;
            if (response.IsSuccessStatusCode)
            {
                SkillsDto skillDto = new SkillsDto();
                return View("AddSkillClient", skillDto);

            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> AddSkillClientPost(SkillsDto incomingSkillsDto, string skillTitleEn, string skillDescriptionEn)
        {
            string url = GenerateClient.Client.BaseAddress + "Skill/AddSkillPost";

            SkillsDto newSkillsDto = new SkillsDto();
            using var jsonContent = new MultipartFormDataContent();
            jsonContent.Add(new StringContent(JsonSerializer.Serialize(incomingSkillsDto), Encoding.UTF8, "application/json"), "skillsDto");
            //jsonContent.Add(new StringContent(skillTitleEn), "skillTitleEn");
            //jsonContent.Add(new StringContent(skillDescriptionEn), "skillDescriptionEn");

            HttpResponseMessage response = await GenerateClient.Client.PostAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var success = await response.Content.ReadFromJsonAsync<bool>();
                if (success) ViewBag.Message = "Başarılı";
                else ViewBag.Message = "Başarısız";
                return View("AddSkillClient", newSkillsDto);
            }
            else
                return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> ShowSkillClient()
        {
            string url = GenerateClient.Client.BaseAddress + "Skill/ShowSkill";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}").Result;

            if (response.IsSuccessStatusCode)
            {
                List<SkillsDto> skillList = await response.Content.ReadFromJsonAsync<List<SkillsDto>>();
                return View("ShowSkillClient", skillList);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> DeleteSkillClient(int skillId)
        {
            string url = GenerateClient.Client.BaseAddress + "Skill/DeleteSkill";

            HttpResponseMessage response = await GenerateClient.Client.DeleteAsync($"{url}?skillId={skillId}");
            if (response.IsSuccessStatusCode)
            {
                List<SkillsDto> skillList = await response.Content.ReadFromJsonAsync<List<SkillsDto>>();
                if (skillList.Count > 0)
                {
                    if (skillList.FirstOrDefault().SkillId != skillId) ViewBag.Message = "Başarılı";
                    else ViewBag.Message = "Başarısız";
                }
                else ViewBag.Message = "Başarılı";

                return View("ShowSkillClient", skillList);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateSkillClient(int skillId)
        {
            string url = GenerateClient.Client.BaseAddress + "Skill/UpdateSkill";

            HttpResponseMessage response = GenerateClient.Client.GetAsync($"{url}?skillId={skillId}").Result;

            if (response.IsSuccessStatusCode)
            {
                SkillsDto skillDto = await response.Content.ReadFromJsonAsync<SkillsDto>();
                return View("UpdateSkillClient", skillDto);
            }
            else return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> UpdateSkillClientPost(SkillsDto skillDto, string newSkillImage)
        {
            string url = GenerateClient.Client.BaseAddress + "Skill/UpdateSkillPost";

            using var jsonContent = new MultipartFormDataContent();
            jsonContent.Add(new StringContent(JsonSerializer.Serialize(skillDto), Encoding.UTF8, "application/json"));
            jsonContent.Add(new StringContent(newSkillImage), "newSkillImage");

            HttpResponseMessage response = await GenerateClient.Client.PutAsync(url, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                List<SkillsDto> skillList = await response.Content.ReadFromJsonAsync<List<SkillsDto>>();
                return View("ShowSkillClient", skillList);
            }
            else return RedirectToAction("Login", "User");
        }
    }
}
