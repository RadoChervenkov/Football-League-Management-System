namespace FLMS.Web.Areas.Management.ViewModels.League
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class LeagueDropdownViewModel : IMapFrom<League>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public IEnumerable<SelectListItem> SelectableLeagues { get; set; }
    }
}