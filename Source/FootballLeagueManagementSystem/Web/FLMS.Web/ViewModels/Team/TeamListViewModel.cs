namespace FLMS.Web.ViewModels.Team
{
    using AutoMapper;
    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class TeamListViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string League { get; set; }

        public string Season { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamListViewModel>()
                         .ForMember(m => m.League, opt => opt.MapFrom(t => t.League.Name))
                         .ForMember(m => m.Season, opt => opt.MapFrom(t => t.League.Season.Name));
        }
    }
}