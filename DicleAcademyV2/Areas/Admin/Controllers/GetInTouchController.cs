using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GetInTouchController : Controller
    {
        private readonly IGetInTouchService _getInTouchService;

        public GetInTouchController(IGetInTouchService getInTouchService)
        {
            _getInTouchService = getInTouchService;
        }

        public bool AddGetInTouch()
        {
            return true;
        }
        public bool AddGetInTouchPost([FromBody] GetInTouchDto getInTouchDto, string getInTouchTitleEn, string getInTouchDescriptionEn)
        {
            GetInTouchDto incomingDto = _getInTouchService.CreateGetInTouch(getInTouchDto);

            if (incomingDto is not null) return true;
            else return false;
        }
        public List<GetInTouchDto> ShowGetInTouch()
        {
            List<GetInTouchDto> getInTouchList = _getInTouchService.GetAllGetInTouch().ToList();
            return getInTouchList;
        }
        public List<GetInTouchDto> UpdateGetInTouchPost([FromBody] GetInTouchDto getInTouchDto)
        {
            _getInTouchService.UpdateGetInTouch(getInTouchDto);

            List<GetInTouchDto> getInTouchList = _getInTouchService.GetAllGetInTouch().ToList();

            return getInTouchList;
        }
        public GetInTouchDto UpdateGetInTouch(int getInTouchId)
        {
            GetInTouchDto getInTouchDto = _getInTouchService.GetByIdGetInTouch(getInTouchId);

            return getInTouchDto;
        }
        public List<GetInTouchDto> DeleteGetInTouch(int getInTouchId)
        {
            _getInTouchService.DeleteGetInTouch(getInTouchId);

            GetInTouchDto getInTouchDto = _getInTouchService.GetByIdGetInTouch(getInTouchId);
            List<GetInTouchDto> getInTouchList = _getInTouchService.GetAllGetInTouch().ToList();

            return getInTouchList;
        }
    }
}
