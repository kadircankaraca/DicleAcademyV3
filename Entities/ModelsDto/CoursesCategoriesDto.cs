using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class CoursesCategoriesDto
    {
        public int CategoryId { get; set;}
        public string CategoryName { get; set;}
        public string CategoryImage { get; set; }
        public string CategoryDescription { get; set; }
        public int TotalCourseNumber { get; set; }
    }
}
