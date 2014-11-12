using FLMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace FLMS.Data
{
    public interface IFlmsDbContext
    {
        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<Player> Players { get; set; }
        
        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}