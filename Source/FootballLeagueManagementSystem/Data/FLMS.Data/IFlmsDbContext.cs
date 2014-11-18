namespace FLMS.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using FLMS.Data.Models;

    public interface IFlmsDbContext
    {
        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<Player> Players { get; set; }

        IDbSet<Season> Seasons { get; set; }

        IDbSet<League> Leagues { get; set; }

        IDbSet<Team> Teams { get; set; }

        IDbSet<Match> Matches { get; set; }
        
        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}