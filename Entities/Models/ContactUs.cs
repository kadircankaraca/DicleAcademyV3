﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactUsId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        [ForeignKey("CourseId")]
        public Courses Courses { get; set; }
        public int CourseId { get; set; }
    }
}
