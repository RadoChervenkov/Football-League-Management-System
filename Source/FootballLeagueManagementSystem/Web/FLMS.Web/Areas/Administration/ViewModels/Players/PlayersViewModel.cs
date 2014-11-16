namespace FLMS.Web.Areas.Administration.ViewModels.Players
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using FLMS.Data.Models;
    using FLMS.Web.Areas.Administration.ViewModels.Base;
    using FLMS.Web.Infrastructure.Mapping;
    using AutoMapper;

    public class PlayersViewModel : AdministrationViewModel, IMapFrom<Player>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType("Date")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Height")]
        public float Height { get; set; }

        [Display(Name = "Weight")]
        public float Weight { get; set; }

        [UIHint("TeamDropdown")]
        public int? TeamId { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Player, PlayersViewModel>()
                         .ForMember(m => m.TeamName, opt => opt.MapFrom(a => a.Team.Name));
        }
    }
}