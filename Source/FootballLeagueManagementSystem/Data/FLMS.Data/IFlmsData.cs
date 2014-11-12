namespace FLMS.Data
{
    using FLMS.Data.Common.Repository;
    using FLMS.Data.Models;

    public interface IFlmsData
    {
        IDeletableEntityRepository<Player> Players { get; }

        IRepository<ApplicationUser> Users { get; }
        
        IFlmsDbContext Context { get; }

        int SaveChanges();
    }
}