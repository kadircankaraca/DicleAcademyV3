using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class WelcomeInformations
    {
        [Key]
        public int WelcomeInformationId { get; set; }
        public string WelcomeInformationTitle { get; set; }
        public string WelcomeInformationDescription { get; set; }
        public string WelcomeInformationImage { get; set; }


    }
}
