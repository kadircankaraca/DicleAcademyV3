using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GetInTouchController : Controller
    {
        private readonly IGetInTouchService _getInTouchService;

        public GetInTouchController(IGetInTouchService getInTouchService)
        {
            _getInTouchService = getInTouchService;
        }

        public IActionResult AddGetInTouch()
        {
            return View();
        }

        public IActionResult AddGetInTouchPost(GetInTouchDto getInTouchDto, string getInTouchTitleEn, string getInTouchDescriptionEn)
        {
            GetInTouchDto incomingDto = _getInTouchService.CreateGetInTouch(getInTouchDto);

            if (incomingDto is not null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            return View("AddGetInTouch");
        }

        public IActionResult ShowGetInTouch()
        {
            List<GetInTouchDto> getInTouchList = _getInTouchService.GetAllGetInTouch().ToList();
            return View(getInTouchList);
        }


        public IActionResult UpdateGetInTouchPost(GetInTouchDto getInTouchDto)
        {
            _getInTouchService.UpdateGetInTouch(getInTouchDto);

            List<GetInTouchDto> getInTouchList = _getInTouchService.GetAllGetInTouch().ToList();

            return View("ShowGetInTouch", getInTouchList);
        }

        public IActionResult UpdateGetInTouch(int getInTouchId)
        {
            GetInTouchDto getInTouchDto = _getInTouchService.GetByIdGetInTouch(getInTouchId);

            return View(getInTouchDto);
        }

        public IActionResult DeleteGetInTouch(int getInTouchId)
        {
            _getInTouchService.DeleteGetInTouch(getInTouchId);

            GetInTouchDto getInTouchDto = _getInTouchService.GetByIdGetInTouch(getInTouchId);
            List<GetInTouchDto> getInTouchList = _getInTouchService.GetAllGetInTouch().ToList();

            if (getInTouchDto is null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            return View("ShowGetInTouch", getInTouchList);
        }
    }
}
