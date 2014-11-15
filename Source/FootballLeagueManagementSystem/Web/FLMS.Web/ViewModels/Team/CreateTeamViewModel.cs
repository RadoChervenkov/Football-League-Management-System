namespace FLMS.Web.ViewModels.Team
{
    using FLMS.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class CreateTeamViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public ICollection<Player> Players { get; set; }
    }
}