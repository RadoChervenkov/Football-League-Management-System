namespace FLMS.Web.ViewModels.Player
{
    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class PlayerListViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public PlayerPosition Position { get; set; }
    }
}