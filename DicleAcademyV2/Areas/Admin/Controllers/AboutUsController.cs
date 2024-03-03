using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Contracts;
using System.IO;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService _aboutUsService;
        FileDelete _fileDelete = new FileDelete();
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AboutUsController(IAboutUsService aboutUsService, IWebHostEnvironment webHostEnvironment)
        {
            _aboutUsService = aboutUsService;
            _webHostEnvironment = webHostEnvironment;
        }

        public bool AddAboutUs()
        {
            return true;
        }
        public async Task<bool> AddAboutUsPost(string aboutUsTitle, string aboutUsDescription, IFormFile aboutUsImage)
        {

            
            AboutUsDto aboutUsDto = new AboutUsDto();

            if (aboutUsImage != null && aboutUsImage.Length > 0)
            {
                var fileName = Path.GetFileName(aboutUsImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/AboutUsImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await aboutUsImage.CopyToAsync(fileStream);
                }
                aboutUsDto.AboutUsImage = fileName;

            }

            aboutUsDto.AboutUsDescription = aboutUsDescription;
            aboutUsDto.AboutUsTitle = aboutUsTitle;

            AboutUsDto incomingDto = _aboutUsService.CreateAboutUs(aboutUsDto);

            if (incomingDto is not null) return true; 
            else return false; 

            
        }
        public List<AboutUsDto> ShowAboutUs()
        {
            List<AboutUsDto> aboutUsList = new List<AboutUsDto>();
            aboutUsList = _aboutUsService.GetAllAboutUs().ToList();

            return aboutUsList;
        }
        public List<AboutUsDto> DeleteAboutUs(int aboutUsId)
        {
            string aboutUsImage = _aboutUsService.GetByIdAboutUs(aboutUsId).AboutUsImage;
            AboutUsDto aboutUsDto = new AboutUsDto();
            List<AboutUsDto> aboutUsDtoList = new List<AboutUsDto>();

            _aboutUsService.DeleteAboutUs(aboutUsId);

            aboutUsDto = _aboutUsService.GetByIdAboutUs(aboutUsId);
            aboutUsDtoList = _aboutUsService.GetAllAboutUs().ToList();
            if (aboutUsDto is null)
            {
                string path = "AboutUsImages\\" + aboutUsImage;
                _fileDelete.DeleteFile(_webHostEnvironment, path);
                

                return aboutUsDtoList;
            }
            else return aboutUsDtoList;
        }
        public async Task<List<AboutUsDto>> UpdateAboutUsPost(string aboutUsId, string aboutUsTitle, string aboutUsDescription, IFormFile newAboutUsImage)
        {
            AboutUsDto aboutUsDto = new AboutUsDto();

            if (newAboutUsImage != null && newAboutUsImage.Length > 0)
            {
                var fileName = Path.GetFileName(newAboutUsImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/AboutUsImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newAboutUsImage.CopyToAsync(fileStream);
                }
                aboutUsDto.AboutUsImage = fileName;
            }
            else
            {
                aboutUsDto.AboutUsImage = _aboutUsService.GetByIdAboutUs(Convert.ToInt32(aboutUsId)).AboutUsImage;
            }

            aboutUsDto.AboutUsTitle = aboutUsTitle;
            aboutUsDto.AboutUsDescription = aboutUsDescription;
            aboutUsDto.AboutUsId = Convert.ToInt32(aboutUsId);

            _aboutUsService.UpdateAboutUs(aboutUsDto);

            List<AboutUsDto> list = _aboutUsService.GetAllAboutUs().ToList();

            return list;
        }
        public AboutUsDto UpdateAboutUs(int aboutUsId)
        {
            AboutUsDto aboutUsDto = new AboutUsDto();

            aboutUsDto = _aboutUsService.GetByIdAboutUs(aboutUsId);

            return aboutUsDto;
        }
    }
}
