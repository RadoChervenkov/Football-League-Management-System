namespace FLMS.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FLMS.Data.Common.Models;

    public class League : AuditInfo, IDeletableEntity
    {
        private ICollection<Team> teams;

        public League()
        {
            this.teams = new HashSet<Team>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int SeasonId { get; set; }

        public virtual Season Season { get; set; }

        public virtual ICollection<Team> Teams
        {
            get
            {
                return this.teams;
            }

            set
            {
                this.teams = value;
            }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}