namespace FLMS.Web.Areas.Management.ViewModels.League
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class LeagueInputModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        public int SeasonId { get; set; }

        public IEnumerable<SelectListItem> SelectableSeasons { get; set; }
    }
}