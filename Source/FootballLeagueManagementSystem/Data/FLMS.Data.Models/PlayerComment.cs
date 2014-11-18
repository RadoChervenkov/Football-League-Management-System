using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLMS.Data.Models
{
    public class PlayerComment : Comment
    {
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }
}
