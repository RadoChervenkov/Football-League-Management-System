﻿namespace FLMS.Web.Areas.Administration.ViewModels.League
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;
    using FLMS.Data.Models;
    using FLMS.Web.Areas.Administration.ViewModels.Base;
    using FLMS.Web.Infrastructure.Mapping;

    public class LeagueViewModel : AdministrationViewModel, IMapFrom<League>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Season")]
        [UIHint("SeasonDropdown")]
        public int SeasonId { get; set; }

        [Display(Name = "Season")]
        [StringLength(100)]
        [HiddenInput(DisplayValue = false)]
        public string SeasonName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<League, LeagueViewModel>()
                         .ForMember(m => m.SeasonName, opt => opt.MapFrom(a => a.Season.Name));
        }
    }
}