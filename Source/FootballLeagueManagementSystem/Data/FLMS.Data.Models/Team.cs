namespace FLMS.Data.Models
{
    using FLMS.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Team : AuditInfo, IDeletableEntity
    {
        private ICollection<Player> players;
        private ICollection<Match> matches;
        private ICollection<TeamComment> comments;

        public Team()
        {
            this.players = new HashSet<Player>();
            this.matches = new HashSet<Match>();
            this.comments = new HashSet<TeamComment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? LeagueId { get; set; }

        public virtual League League { get; set; }

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

        public virtual ICollection<Match> Matches
        {
            get
            {
                return this.matches;
            }
            set
            {
                this.matches = value;
            }
        }

        public virtual ICollection<TeamComment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}