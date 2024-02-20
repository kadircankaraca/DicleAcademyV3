using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademy.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICoursesCategoriesService _coursesCategoriesService;

        public CategoryController(ICoursesCategoriesService coursesCategoriesService)
        {
            _coursesCategoriesService = coursesCategoriesService;
        }

        public IActionResult Index()
        {
          var category=  _coursesCategoriesService.GetAllCoursesCategories();
            return View("CategoryIndex" , category);
        }
        public IActionResult CategoryDetails(int id)
        { //category detail
            return View("CategoryDetailsIndex");
        }
    }
}
