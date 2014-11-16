namespace FLMS.Web.Areas.Administration.ViewModels.Seasons
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using FLMS.Data.Models;
    using FLMS.Web.Areas.Administration.ViewModels.Base;
    using FLMS.Web.Infrastructure.Mapping;
    

    public class SeasonsViewModel : AdministrationViewModel, IMapFrom<Season>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Season name")]
        public string Name { get; set; }
    }
}