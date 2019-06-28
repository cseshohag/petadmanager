using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetApplication.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Body { get; set; }
        public System.DateTime CommentDate { get; set; }

        public virtual PetAnimal PetAnimal { get; set; }
        
        public int PetAnimalId { get; set; }
        
    }
}