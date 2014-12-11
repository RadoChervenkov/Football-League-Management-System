namespace FLMS.Web.Areas.Management.ViewModels.Match
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class MatchInputModel : IMapFrom<Match>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        public int LeagueId { get; set; }

        public IEnumerable<SelectListItem> SelectableTeams { get; set; }
    }
}