namespace FLMS.Web.ViewModels.League
{
    using FLMS.Web.Infrastructure.Mapping;
    using FLMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
using FLMS.Web.ViewModels.Team;

    public class LeagueTableViewModel : IMapFrom<League>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeasonId { get; set; }

        public ICollection<TeamRankViewModel> Teams { get; set; }
    }
}