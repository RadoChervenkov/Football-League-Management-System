namespace FLMS.Web.Areas.Administration.ViewModels.Team
{
    using FLMS.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using FLMS.Data.Models;
    
    public class TeamViewModel : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}