using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetApplication.Models
{
    public class PetAnimal : IEntity
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public string PhoneNumber { get; set; }
    }
}