using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class AboutUsDto
    {
        public int AboutUsId { get; set; }
        public string AboutUsTitle { get; set; }
        public string AboutUsDescription { get; set; }
        public string AboutUsImage { get; set; }
    }
}
