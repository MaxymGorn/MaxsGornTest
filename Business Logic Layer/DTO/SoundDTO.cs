using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTO
{
    public class SoundDTO
    {
        public int id { get; set; }
        public string FileNameUrl { get; set; }
        public string DateStart { get; set; }
        public string Duration { get; set; }
        public int UserId { get; set; }
    }
}
