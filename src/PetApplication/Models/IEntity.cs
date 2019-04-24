using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetApplication.Models
{
    public abstract class IEntity
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Create by:")]
        public string CreateBy { get; set; }
        [DisplayName("Created Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        public DateTime CreateDate { get; set; }
    }
}