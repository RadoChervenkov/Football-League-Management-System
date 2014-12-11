namespace FLMS.Web.ViewModels.Team
{
    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class TeamRankViewModel : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Loses { get; set; }

        public int Points { get; set; }
    }
}