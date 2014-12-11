namespace FLMS.Web.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;

    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;

    public class PostTeamCommentViewModel : IMapFrom<TeamComment>
    {
        public PostTeamCommentViewModel()
        {
        }

        public PostTeamCommentViewModel(int ticketId)
        {
            this.TeamId = ticketId;
        }

        public int TeamId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        [UIHint("MultiLineText")]
        public string Content { get; set; }
    }
}