using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finalassignmnet2.Models
{
    public class Details
    {
        [Key]
        public string email { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string mobile { get; set; }

    }
}