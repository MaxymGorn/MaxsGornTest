using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation_Layer.Controllers
{
    public class UploadViewModel
    {
        [Required]
        public HttpPostedFileBase blob { get; set; }
        [Required]
        public string dateStart { get; set; }
        [Required]
        public string duration { get; set; }
    }
}