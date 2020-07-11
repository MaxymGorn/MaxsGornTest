using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaxsGornTest.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
        public virtual List<Sound> Portfolios { get; set; }
    }
}