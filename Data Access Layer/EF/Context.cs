using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data_Access_Layer.EF;

namespace MaxsGornTest.Models
{
    public class Context : DbContext
    {
        public Context()
            : base("name=Default")
        {
        }
        public Context(string connectionString)
     : base(connectionString)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Sound> Sounds { get; set; }
        static Context()
        {
            //Database.SetInitializer<Context>(new DbInitializer());
        }
    }

}