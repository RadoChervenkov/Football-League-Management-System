namespace FLMS.Web.Areas.Management.ViewModels.Team
{
    using System.Web.Mvc;

    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class TeamViewModel : IMapFrom<Team>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}