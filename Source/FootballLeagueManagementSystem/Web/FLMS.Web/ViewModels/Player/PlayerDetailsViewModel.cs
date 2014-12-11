namespace FLMS.Web.ViewModels.Player
{
    using System;

    using AutoMapper;
    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class PlayerDetailsViewModel : IMapFrom<Player>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Team { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public PlayerPosition Position { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Player, PlayerDetailsViewModel>()
                         .ForMember(p => p.Team, opt => opt.MapFrom(p => p.Team.Name));
        }
    }
}