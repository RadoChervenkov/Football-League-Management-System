﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FLMS.Data.Models
{
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

        public int CaptainId { get; set; }

        public virtual ApplicationUser Captain { get; set; }

        public ICollection<Player> Players { get; set; }

        public int LeagueId { get; set; }

        public virtual League League { get; set; }
    }
}