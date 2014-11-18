namespace FLMS.Data.Models
{
    public class TeamComment : Comment
    {
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}