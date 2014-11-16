namespace FLMS.Web.Areas.Administration.ViewModels.Teams
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;
    using FLMS.Data.Models;
    using FLMS.Web.Areas.Administration.ViewModels.Base;
    using FLMS.Web.Infrastructure.Mapping;


    public class TeamViewModel : AdministrationViewModel, IMapFrom<Team>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "League")]
        [UIHint("LeagueDropdown")]
        public int LeagueId { get; set; }

        [Display(Name = "League")]
        [HiddenInput(DisplayValue = false)]
        public string LeagueName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamViewModel>()
                         .ForMember(m => m.LeagueName, opt => opt.MapFrom(a => a.League.Name));
        }
    }
}