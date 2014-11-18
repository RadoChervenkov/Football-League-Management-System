namespace FLMS.Web.Areas.Management.ViewModels.Match
{
    using FLMS.Web.Infrastructure.Mapping;
    using FLMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;

    public class MatchDropdownViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchDropdownViewModel>()
                         .ForMember(m => m.Name, opt => opt.MapFrom(m => m.HomeTeam.Name + " - " + m.AwayTeam.Name));
        }
    }
}