using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double CoursesDuration { get; set; }
        public int CoursesQuota { get; set; }
        public string Image { get; set; }

        [ForeignKey("CategoryId")]
        public CoursesCategories CoursesCategories { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("InstructorId")]
        public Instructors Instructors { get; set; }
        public int InstructorId { get; set; }
    }
}
