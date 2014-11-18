namespace FLMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FLMS.Data.Common.Models;

    public abstract class Comment : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}