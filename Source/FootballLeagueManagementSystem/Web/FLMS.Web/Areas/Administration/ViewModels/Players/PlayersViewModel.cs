namespace FLMS.Web.Areas.Administration.ViewModels.Players
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using FLMS.Data.Models;
    using FLMS.Web.Areas.Administration.ViewModels.Base;
    using FLMS.Web.Infrastructure.Mapping;

    public class PlayersViewModel : AdministrationViewModel, IMapFrom<Player>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Възраст")]
        public int Age { get; set; }

        [DataType("Date")]
        public DateTime DateOfBirth { get; set; }
    }
}