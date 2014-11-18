namespace FLMS.Web.ViewModels.Team
{
    using FLMS.Web.Infrastructure.Mapping;
    using FLMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

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