using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class GetCategoryWithCoursesDto
    {
        public string CategoryName { get; set; }
        public List<CoursesDto> Courses { get; set; }
        public CoursesCategoriesDto CoursesCategory { get; set; }
    }
}
