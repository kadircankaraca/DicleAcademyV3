using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class CoursesDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int InstructorId { get; set; }
        public double CoursesDuration { get; set; }
        public int CoursesQuota { get; set; }
        public string Image { get; set; }
        //public IFormFile? ImageFile { get; set; }
        public int CategoryId { get; set; }
    }
}