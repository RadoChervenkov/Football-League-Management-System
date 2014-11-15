namespace FLMS.Data.Models
{
    using FLMS.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class League : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeasonId { get; set; }

        public virtual Season Season { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}