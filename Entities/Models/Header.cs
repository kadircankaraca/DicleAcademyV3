using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Header
    {
        [Key]
        public int HeaderId { get; set; }
        public string HeaderImage { get; set; }
        public string HeaderDescription { get; set; }
        public string HeaderTitle { get; set; }

    }
}
