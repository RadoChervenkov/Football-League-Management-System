namespace FLMS.Web.Areas.Management.ViewModels.Match
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class MatchResultInputModel : IMapFrom<Match>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public IEnumerable<SelectListItem> SelectableTeams { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchResultInputModel>()
                         .ForMember(m => m.Name, opt => opt.MapFrom(m => m.HomeTeam.Name + " - " + m.AwayTeam.Name));
        }
    }
}