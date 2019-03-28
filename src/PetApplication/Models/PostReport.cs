using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetApplication.Models
{
    public class PostReport
    {
        [Key]
        public int ReportID { get; set; }

        public int PetPostID { get; set; }
        public string Report { get; set; }

        public virtual PetPost PetPost { get; set; }
        
    }
}