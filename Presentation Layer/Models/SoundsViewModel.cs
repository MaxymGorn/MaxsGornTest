using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation_Layer.Models
{
    public class SoundsViewModel
    {
        public int id { get; set; }
        public string FileNameUrl { get; set; }
        public string DateStart { get; set; }
        public string Duration { get; set; }
        public int UserId { get; set; }
    }
}