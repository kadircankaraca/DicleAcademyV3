using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class BestCoursesDto
    {    
        public int BestCourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseId { get; set; }
    }
}
