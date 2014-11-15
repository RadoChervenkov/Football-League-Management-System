namespace FLMS.Web.Areas.Administration.ViewModels.League
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class LeagueInputModel : IMapFrom<League>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Season")]
        public string SeasonId { get; set; }

        public IEnumerable<SelectListItem> SelectableSeasons { get; set; }
    }
}