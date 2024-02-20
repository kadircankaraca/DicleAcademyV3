using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class GetInTouch
    {
        [Key]
        public int GetInTouchId { get; set; }
        public string GetInTouchTitle { get; set; }
        public string GetInTouchDescription { get; set; }
        public string Adress {  get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
