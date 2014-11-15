namespace FLMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using FLMS.Data.Common.Models;

    public class Player : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public float Weight { get; set; }

        public float Height { get; set; }

        public PlayerPosition Position { get; set; }
           
        // public string PictureLink { get; set; }
           
         public int TeamId { get; set; }
           
         public virtual Team Team { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}