namespace FLMS.Data.Models
{
    using FLMS.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Team : AuditInfo, IDeletableEntity
    {
        private ICollection<Player> players;

        public Team()
        {
            this.players = new HashSet<Player>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Player> Players
        {
            get
            {
                return this.players;
            }
            set
            {
                this.players = value;
            }
        }

        public int LeagueId { get; set; }

        public virtual League League { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}