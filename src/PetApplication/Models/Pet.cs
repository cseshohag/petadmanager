using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetApplication.Models
{
    public class Pet
    {
        [Key]
        public int PetID { get; set; }
        [DisplayName("Pet Name")]
        public string PetName { get; set; }
        [DisplayName("Pet Type")]
        public int PetTypeID { get; set; }

        public virtual PetType PetType { get; set; }
        public string PetTypeName { get; set; }
    }
}