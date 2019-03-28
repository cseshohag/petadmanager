using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetApplication.Models
{
    public class PetType
    {
        [Key]
        public int PetTypeID { get; set; }
        [DisplayName("Pet Type")]
        public string PetTypeName { get; set; }

    }
}