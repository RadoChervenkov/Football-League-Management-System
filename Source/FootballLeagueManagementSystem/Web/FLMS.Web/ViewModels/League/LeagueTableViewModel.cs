namespace FLMS.Web.ViewModels.League
{
    using System.Collections.Generic;

    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;
    using FLMS.Web.ViewModels.Team;

    public class LeagueTableViewModel : IMapFrom<League>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeasonId { get; set; }

        public ICollection<TeamRankViewModel> Teams { get; set; }
    }
}