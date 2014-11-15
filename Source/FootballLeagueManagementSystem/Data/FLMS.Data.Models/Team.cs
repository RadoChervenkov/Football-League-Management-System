namespace FLMS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Team
    {
        private ICollection<Player> players;

        public Team()
        {
            this.players = new HashSet<Player>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ManagerId { get; set; }

        public virtual ApplicationUser Manager { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Player> Players
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
    }
}