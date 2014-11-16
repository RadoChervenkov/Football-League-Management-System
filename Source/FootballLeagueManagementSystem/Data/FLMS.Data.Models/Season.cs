namespace FLMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    using FLMS.Data.Common.Models;
    
    public class Season : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}