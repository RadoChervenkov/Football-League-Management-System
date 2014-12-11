namespace FLMS.Web.ViewModels.Team
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class TeamCreateViewModel : IMapFrom<Team>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public ICollection<Player> Players { get; set; }
    }
}