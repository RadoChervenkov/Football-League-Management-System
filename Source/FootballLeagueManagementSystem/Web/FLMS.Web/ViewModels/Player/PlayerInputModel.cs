namespace FLMS.Web.ViewModels.Player
{
    using FLMS.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using FLMS.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class PlayerInputModel : IMapFrom<Player>
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(30, 300)]
        public float Weight { get; set; }

        [Required]
        [Range(120, 250)]
        public float Height { get; set; }
        
        public PlayerPosition Position { get; set; }
    }
}