namespace FLMS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class League
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int MaxTeamsCount { get; set; }

        public ICollection<Team> Teams { get; set; }

        public int SeasonId { get; set; }

        public virtual Season Season { get; set; }
    }
}