namespace FLMS.Web.Areas.Management.ViewModels.Match
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;
    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class MatchDropdownViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchDropdownViewModel>()
                         .ForMember(m => m.Name, opt => opt.MapFrom(m => m.HomeTeam.Name + " - " + m.AwayTeam.Name));
        }
    }
}