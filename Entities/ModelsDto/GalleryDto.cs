using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class GalleryDto
    {       
        public int GalleryId { get; set; }
        public string GalleryImage { get; set; }
    }
}
