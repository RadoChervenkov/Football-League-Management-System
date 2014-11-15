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

        public Season Season { get; set; }

        public IEnumerable<SelectListItem> SelectableSeasons { get; set; }
    }
}