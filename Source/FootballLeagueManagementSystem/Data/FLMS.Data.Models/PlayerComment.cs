namespace FLMS.Data.Models
{
    public class PlayerComment : Comment
    {
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }
}