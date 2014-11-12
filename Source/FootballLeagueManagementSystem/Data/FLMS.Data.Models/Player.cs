namespace FLMS.Data.Models
{
    using FLMS.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Player : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public float Weight { get; set; }

        public float Height { get; set; }

        //public PlayerPosition Position { get; set; }

        //public string PictureLink { get; set; }

        //public int TeamId { get; set; }

        //public virtual Team Team { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}