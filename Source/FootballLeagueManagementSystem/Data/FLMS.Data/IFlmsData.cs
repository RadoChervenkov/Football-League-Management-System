using FLMS.Data.Common.Repository;
using FLMS.Data.Models;
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

        IDeletableEntityRepository<Player> Players { get; }

        IRepository<ApplicationUser> Users { get; }
    }
}