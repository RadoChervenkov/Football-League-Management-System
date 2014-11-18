namespace FLMS.Data
{
    using System;
    using System.Collections.Generic;

    using FLMS.Data.Common.Models;
    using FLMS.Data.Common.Repository;
    using FLMS.Data.Models;

    public class FlmsData : IFlmsData
    {
        private readonly IFlmsDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public FlmsData(IFlmsDbContext context)
        {
            this.context = context;
        }

        public IFlmsDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IDeletableEntityRepository<Player> Players
        {
            get
            {
                return this.GetDeletableEntityRepository<Player>();
            }
        }

        public IDeletableEntityRepository<Season> Seasons
        {
            get
            {
                return this.GetDeletableEntityRepository<Season>();
            }
        }

        public IDeletableEntityRepository<League> Leagues
        {
            get
            {
                return this.GetDeletableEntityRepository<League>();
            }
        }

        public IDeletableEntityRepository<Team> Teams
        {
            get
            {
                return this.GetDeletableEntityRepository<Team>();
            }
        }

        public IDeletableEntityRepository<Match> Matches
        {
            get
            {
                return this.GetDeletableEntityRepository<Match>();
            }
        }
        
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }
            
            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}