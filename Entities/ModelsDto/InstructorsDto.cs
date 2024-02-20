using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class InstructorsDto
    {   
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string InstructorDescription { get; set; }
        public string AreaOfExpertise { get; set; }
        public string InstructorImage { get; set; }
        public string TwitterAccountURL { get; set; }
        public string FacebookAccountURL { get; set; }
        public string InstagramAcoountURL { get; set; }

    }
}
