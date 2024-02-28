using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly IAuthenticationService _authenticationService;
        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task UserCheck(UserForAuthenticationDto user)
        {
            //UserForRegistrationDto userr = new UserForRegistrationDto();

            //userr.UserName = "kdrkrc19";
            //userr.Password = "aBcde123-";
            //userr.PhoneNumber = "1234567890";
            //userr.Roles = new List<string>();
            //userr.Roles.Add("Admin");
            //userr.FirstName = "Kadircan";
            //userr.LastName = "Karaca";
            //userr.Email = "kadircankaraca01@gmail.com";

            //_authenticationService.RegisterUser(userr);

            bool isAvailableUser = await _authenticationService.ValidateUser(user);
            if (isAvailableUser)
            {
                TokenDto token = await _authenticationService.CreateToken(isAvailableUser);
                if (token is not null)
                {
                    GenerateClient.Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.AccessToken);
                }
            }
            string url = GenerateClient.Client.BaseAddress + "Admin/Index";
            HttpResponseMessage ProductCategoryResponce = GenerateClient.Client.PostAsync($"{url}", null).Result;
        }

        public IActionResult AddAdmin()
        {
            return View();
        }
    }
}
