﻿using System;
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
        public int Age { get; set; }
        [DisplayName("Pet Color")]
        public string Color { get; set; }
        [DisplayName("Image")]
        public string ImageUrl { get; set; }
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        [DisplayName("Details")]
        public string Details { get; set; }
        [DisplayName("Price")]
        public decimal Price { get; set; }
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

        [DisplayName("Pet Type")]
        public int PetTypeID { get; set; }
        public virtual PetType PetType { get; set; }
        public string PetTypeName { get; set; }
    }
}