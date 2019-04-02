using System;

namespace PetApplication.Models
{
    public abstract class IEntity
    {
        public int Id { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}