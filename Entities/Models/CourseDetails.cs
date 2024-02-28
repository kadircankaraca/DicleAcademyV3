using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CourseDetails
    {
        [Key]
        public int CourseDetailsId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseLocation { get; set; }
        public double CourseDuration { get; set; } //kurs süresi
        public string Image {  get; set; }

        [ForeignKey("CourseId")]
        public Courses Courses { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("CategoryId")]
        public CoursesCategories CoursesCategories { get; set; }
        public int CategoryId { get; set; }
    }
}