using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class StudentsSay
    {
        [Key]
        public int StudentsSayId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentsSayTitle { get; set; }
        public string StudentsSayDescription { get; set; }
        public string StudentsSayImage { get; set; }
    }
}
