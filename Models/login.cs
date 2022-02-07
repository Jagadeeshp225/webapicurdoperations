using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finalassignmnet2.Models
{
    public class login
    {
        [Key]
        public string email { get; set; }
        public string password { get; set; }
    }
}