using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TwitterAccountURL { get; set; }
        public string FacebookAccountURL { get; set; }
        public string YoutubeAccountURL { get; set; }
        public string LinkedInAccountURL { get; set; }
        public string InstagramAcoountURL { get; set; }
       
    }
}
