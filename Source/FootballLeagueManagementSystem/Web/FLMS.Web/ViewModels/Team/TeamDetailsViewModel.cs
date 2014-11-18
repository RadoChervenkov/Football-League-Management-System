namespace FLMS.Web.ViewModels.Team
{
    using FLMS.Web.Infrastructure.Mapping;
    using FLMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public class TeamDetailsViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string League { get; set; }

        public string Season { get; set; }

        public ICollection<Player> Players { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamDetailsViewModel>()
                         .ForMember(m => m.League, opt => opt.MapFrom(t => t.League.Name))
                         .ForMember(m => m.Season, opt => opt.MapFrom(t => t.League.Season.Name));
        }
    }
}