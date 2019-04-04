using System;
using System.ComponentModel.DataAnnotations;

namespace PetApplication.Models
{
    public abstract class IEntity
    {
        public int Id { get; set; }
        public int CreateBy { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        public DateTime CreateDate { get; set; }
    }
}