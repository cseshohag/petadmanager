﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetApplication.Models
{
    public abstract class IEntity
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Post Created by:")]
        public int CreateBy { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        public DateTime CreateDate { get; set; }
    }
}