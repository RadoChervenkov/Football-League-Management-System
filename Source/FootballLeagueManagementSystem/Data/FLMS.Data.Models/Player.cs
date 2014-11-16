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
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
    
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(40, 250)]
        public int Weight { get; set; }

        [Required]
        [Range(50, 250)]
        public int Height { get; set; }

        public PlayerPosition Position { get; set; }
        
        [Required]
        public int TeamId { get; set; }
           
        public virtual Team Team { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}