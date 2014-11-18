namespace FLMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FLMS.Data.Common.Models;

    public class Match : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int HomeTeamId { get; set; }

        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }

        public int LeagueId { get; set; }

        public virtual League League { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public MatchResult Result { get; set; }

        public MatchState State { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}