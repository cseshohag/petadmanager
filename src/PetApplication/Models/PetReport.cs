using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetApplication.Models
{
    public class PetReport
    {
        [Key]
        public int ReportID { get; set; }

        public int Id { get; set; }
        public string Report { get; set; }

        public virtual PetAnimal PetAminal { get; set; }
        
    }
}