namespace FLMS.Data
{
    using FLMS.Data.Common.Repository;
    using FLMS.Data.Models;

    public interface IFlmsData
    {
        IDeletableEntityRepository<Player> Players { get; }

        IRepository<ApplicationUser> Users { get; }

        IDeletableEntityRepository<League> Leagues { get; }

        IDeletableEntityRepository<Season> Seasons { get; }

        IDeletableEntityRepository<Team> Teams { get; }

        IDeletableEntityRepository<Match> Matches { get; }
        
        IFlmsDbContext Context { get; }

        int SaveChanges();
    }
}