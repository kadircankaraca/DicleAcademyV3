using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeaderController : Controller
    {
        private readonly IHeaderService _headerService;
        FileDelete _fileDelete = new FileDelete();
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HeaderController(IHeaderService headerService, IWebHostEnvironment webHostEnvironment)
        {
            _headerService = headerService;
            _webHostEnvironment = webHostEnvironment;
        }

        public bool AddHeader()
        {
            return true;
        }
        public async Task<bool> AddHeaderPost(string headerTitle, string headerDescription, IFormFile image, string headerTitleEn, string headerDescriptionEn)
        {
            HeaderDto headerDto = new HeaderDto();
            headerDto.HeaderDescription = headerDescription;
            headerDto.HeaderTitle = headerTitle;

            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/HeaderImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                headerDto.HeaderImage = fileName;
            }

            HeaderDto incomingDto = _headerService.CreateHeader(headerDto);

            if (incomingDto is not null) return true;      
            else return false;
        }
        public List<HeaderDto> ShowHeader()
        {
            List<HeaderDto> headerList = _headerService.GetAllHeader().ToList();

            return headerList;
        }
        public HeaderDto UpdateHeader(int headerId)
        {
            HeaderDto header = _headerService.GetByIdHeader(headerId);
            return header;
        }
        public async Task<List<HeaderDto>> UpdateHeaderPost(string headerId, string headerTitle, string headerDescription, IFormFile newHeaderImage)
        {
            HeaderDto headerDto = new HeaderDto();
           
            if (newHeaderImage != null && newHeaderImage.Length > 0)
            {
                var fileName = Path.GetFileName(newHeaderImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/HeaderImages", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newHeaderImage.CopyToAsync(fileStream);
                }
                headerDto.HeaderImage = fileName;
            }
            else
            {
                headerDto.HeaderImage = _headerService.GetByIdHeader(headerDto.HeaderId).HeaderImage;
            }
            headerDto.HeaderDescription = headerDescription;
            headerDto.HeaderTitle = headerTitle;
            headerDto.HeaderId = Convert.ToInt32(headerId);

            _headerService.UpdateHeader(headerDto);

            List<HeaderDto> headerList = _headerService.GetAllHeader().ToList();
            return headerList;
        }

        public  List<HeaderDto> UpdateHeaderPostNoImage(string headerId, string headerTitle, string headerDescription)
        {
            HeaderDto headerDto = new HeaderDto();

            headerDto.HeaderImage = _headerService.GetByIdHeader(Convert.ToInt32(headerId)).HeaderImage;
            headerDto.HeaderDescription = headerDescription;
            headerDto.HeaderTitle = headerTitle;
            headerDto.HeaderId = Convert.ToInt32(headerId);

            _headerService.UpdateHeader(headerDto);

            List<HeaderDto> headerList = _headerService.GetAllHeader().ToList();
            return headerList;
        }
        public List<HeaderDto> DeleteHeader(int headerId)
        {
            string image = _headerService.GetByIdHeader(headerId).HeaderImage;

            _headerService.DeleteHeader(headerId);

            List<HeaderDto> headerList = _headerService.GetAllHeader().ToList();

            HeaderDto header = _headerService.GetByIdHeader(headerId);

            if (header is null)
            {
                string path = "HeaderImages\\" + image;
                _fileDelete.DeleteFile(_webHostEnvironment, path);

                return headerList;
            }
            else return headerList;
        }
    }
}
