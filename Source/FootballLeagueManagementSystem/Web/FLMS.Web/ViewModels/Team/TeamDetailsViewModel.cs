namespace FLMS.Web.ViewModels.Team
{
    using System.Collections.Generic;

    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;
    using FLMS.Web.ViewModels.Comment;
    using FLMS.Web.ViewModels.Player;

    public class TeamDetailsViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string League { get; set; }

        public string Season { get; set; }

        public ICollection<PlayerListViewModel> Players { get; set; }

        public ICollection<TeamCommentViewModel> Comments { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamDetailsViewModel>()
                         .ForMember(m => m.League, opt => opt.MapFrom(t => t.League.Name))
                         .ForMember(m => m.Season, opt => opt.MapFrom(t => t.League.Season.Name));
        }
    }
}