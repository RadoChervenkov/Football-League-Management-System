namespace FLMS.Web.Areas.Administration.ViewModels.Seasons
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using FLMS.Data.Models;
    using FLMS.Web.Areas.Administration.ViewModels.Base;
    using FLMS.Web.Infrastructure.Mapping;
    
    public class SeasonViewModel : AdministrationViewModel, IMapFrom<Season>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Season name")]
        public string Name { get; set; }
    }
}