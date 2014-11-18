namespace FLMS.Web.Areas.Management.ViewModels.League
{
    using FLMS.Web.Infrastructure.Mapping;
    using FLMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class LeagueDropdownViewModel : IMapFrom<League>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SelectListItem> SelectableLeagues { get; set; }
    }
}