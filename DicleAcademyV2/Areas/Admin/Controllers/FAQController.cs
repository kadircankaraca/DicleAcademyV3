using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FAQController : Controller
    {
        private readonly IFAQService _faqService;
        public FAQController(IFAQService faqService)
        {
            _faqService = faqService;
        }
        public IActionResult AddFAQ()
        {
            return View();
        }
        public IActionResult AddFAQPost(FAQDto faqDto)
        {
            FAQDto incomingDto = _faqService.CreateFAQ(faqDto);

            if (incomingDto is not null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            return View("AddFAQ");
        }
        public IActionResult ShowFAQ(FAQDto faqDto)
        {
            List<FAQDto> faqList = _faqService.GetAllFAQ().ToList();
            return View(faqList);
        }

        public IActionResult UpdateFAQPost(FAQDto faqDto)
        {
            _faqService.UpdateFAQ(faqDto);

            List<FAQDto> faqList = new List<FAQDto>();
            faqList = _faqService.GetAllFAQ().ToList();

            return View("ShowFAQ", faqList);
        }
        public IActionResult UpdateFAQ(int faqId)
        {
            FAQDto faqDto = new FAQDto();

            faqDto = _faqService.GetByIdFAQ(faqId);

            return View(faqDto);
        }
        public IActionResult DeleteFAQ(int faqId)
        {
            FAQDto faqDto = new FAQDto();
            List<FAQDto> faqList = new List<FAQDto>();

            _faqService.DeleteFAQ(faqId);
            faqDto = _faqService.GetByIdFAQ(faqId);

            if (faqDto is null) ViewBag.Message = "Başarılı";
            else ViewBag.Message = "Başarısız";

            faqList = _faqService.GetAllFAQ().ToList();

            return View("ShowFAQ", faqList);
        }

    }
}
