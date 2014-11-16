namespace FLMS.Web.Areas.Administration.ViewModels.Players
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;
    using FLMS.Data.Models;
    using FLMS.Web.Areas.Administration.ViewModels.Base;
    using FLMS.Web.Infrastructure.Mapping;

    public class PlayersViewModel : AdministrationViewModel, IMapFrom<Player>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType("Date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(50, 250)]
        [Display(Name = "Height")]
        public int Height { get; set; }

        [Required]
        [Range(40, 200)]
        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Required]
        [UIHint("TeamDropdown")]
        public int TeamId { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Player, PlayersViewModel>()
                         .ForMember(m => m.TeamName, opt => opt.MapFrom(a => a.Team.Name));
        }
    }
}