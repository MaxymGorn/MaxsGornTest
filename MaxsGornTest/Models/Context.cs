using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxsGornTest.Models
{
    public class Context : DbContext
    {
        public Context()
            : base("name=Default")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Sound> Sounds { get; set; }
    }

}