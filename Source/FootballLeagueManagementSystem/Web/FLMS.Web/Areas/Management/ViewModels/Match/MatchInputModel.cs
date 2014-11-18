namespace FLMS.Web.Areas.Management.ViewModels.Match
{
    using FLMS.Web.Infrastructure.Mapping;
    using FLMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class MatchInputModel : IMapFrom<Match>
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        public int LeagueId { get; set; }

        public IEnumerable<SelectListItem> SelectableTeams { get; set; }
    }
}