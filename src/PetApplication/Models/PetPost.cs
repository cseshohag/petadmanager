using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetApplication.Models
{
    public class PetPost
    {
        [Key]
        public int PetPostID { get; set; }
        [DisplayName("Pet Name")]
        public int PetID { get; set; }
        [DisplayName("Price")]
        public int PetPrice { get; set; }
        [DisplayName("Details")]
        public string PetDetails { get; set; }
        [DisplayName("Image")]
        public string PetImageUrl { get; set; }
        [DisplayName("Location")]
        public string PetLocation { get; set; }
        [DisplayName("Post Created Date")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:dd-MM-yyyy HH:mm}")]
        public DateTime? PostCreatedDate { get; set; }
        [DisplayName("Pet Color")]
        public string PetColor { get; set; }
        [DisplayName("Status")]
        public string PostStatus { get; set; }


        public virtual Pet Pet { get; set; }
        public string PetName { get; set; }

        

    }
}