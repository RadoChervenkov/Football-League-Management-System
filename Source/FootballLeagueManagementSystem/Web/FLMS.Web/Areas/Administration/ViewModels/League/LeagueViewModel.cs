namespace FLMS.Web.Areas.Administration.ViewModels.League
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;
    using FLMS.Data.Models;
    using FLMS.Web.Areas.Administration.ViewModels.Base;
    using FLMS.Web.Infrastructure.Mapping;

    public class LeagueViewModel : AdministrationViewModel, IMapFrom<League>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("SeasonDropdown")]
        public int SeasonId { get; set; }

        [Display(Name = "Season")]
        public string SeasonName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<League, LeagueViewModel>()
                         .ForMember(m => m.SeasonName, opt => opt.MapFrom(a => a.Season.Name));
        }
    }
}