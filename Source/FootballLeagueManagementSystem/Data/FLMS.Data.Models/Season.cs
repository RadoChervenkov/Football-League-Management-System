namespace FLMS.Data.Models
{
    using FLMS.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class Season : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}