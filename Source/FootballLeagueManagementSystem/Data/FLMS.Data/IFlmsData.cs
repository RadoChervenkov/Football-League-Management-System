using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLMS.Data
{
    public interface IFlmsData
    {
        IFlmsDbContext Context { get; }

        int SaveChanges();
    }
}
