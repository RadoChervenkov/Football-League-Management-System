namespace FLMS.Web.ViewModels.Team
{
    using FLMS.Web.Infrastructure.Mapping;
    using FLMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;

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