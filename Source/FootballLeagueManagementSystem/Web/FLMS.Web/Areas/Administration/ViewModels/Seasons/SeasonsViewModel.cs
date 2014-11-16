using FLMS.Data.Models;
using FLMS.Web.Areas.Administration.ViewModels.Base;
using FLMS.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FLMS.Web.Areas.Administration.ViewModels.Seasons
{
    public class SeasonsViewModel : AdministrationViewModel, IMapFrom<Season>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Season name")]
        public string Name { get; set; }
    }
}