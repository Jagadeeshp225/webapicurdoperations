using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace finalassignmnet2.Models
{
    public class context:DbContext

    {
        public context():base("DefaultConnection")
        {

        }
        public DbSet<Details> Detail { get; set; }
        public DbSet<login> login { get; set; }
    }
}