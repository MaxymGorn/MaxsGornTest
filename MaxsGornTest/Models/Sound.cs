using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaxsGornTest.Models
{
    public class Sound
    {
        [Key]
        public int id { get; set; }
        public string FileNameUrl { get; set; }
        public string DateStart { get; set; }
        public string  Duration { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}