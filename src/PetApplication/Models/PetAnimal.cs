using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PetApplication.Models
{
    public class PetAnimal : IEntity
    {
        [DisplayName("Pet Name")]
        public string Name { get; set; }
        [DisplayName("Short Code")]
        public string ShortCode { get; set; }
        [DisplayName("Age of Month")]
        public string Age { get; set; }
        [DisplayName("Pet Color")]
        public string Color { get; set; }
        [DisplayName("Image")]
        public string ImageUrl { get; set; }
        [DisplayName("Quantity")]
        public string Quantity { get; set; }
        [DisplayName("Details")]
        public string Details { get; set; }
        [DisplayName("Price")]
        public string Price { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("IsSold")]
        public Boolean IsSold { get; set; }

        
        [DisplayName("Area")]
        public string Area { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("Division")]
        public string Division { get; set; }

        [DisplayName("Type")]
        public int PetTypeID { get; set; }
        public virtual PetType PetType { get; set; }
        public string PetTypeName { get; set; }
    }
}