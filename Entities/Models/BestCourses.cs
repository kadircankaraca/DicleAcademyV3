using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BestCourses
    {
        [Key]
        public int BestCourseId { get; set; }
        public string CourseName { get; set; }

        [ForeignKey("CourseId")]
        public Courses Courses { get; set; }
        public int CourseId { get; set; }
    }
}
