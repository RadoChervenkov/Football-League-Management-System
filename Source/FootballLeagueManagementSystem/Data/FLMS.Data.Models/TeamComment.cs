using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLMS.Data.Models
{
    public class TeamComment : Comment
    {
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
