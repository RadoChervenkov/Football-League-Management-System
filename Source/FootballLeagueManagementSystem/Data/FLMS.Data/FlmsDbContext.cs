namespace FLMS.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using FLMS.Data.Common.Models;
    using FLMS.Data.Migrations;
    using FLMS.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class FlmsDbContext : IdentityDbContext<ApplicationUser>, IFlmsDbContext
    {
        public FlmsDbContext() : base("FootballLeagueManagementSystemConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FlmsDbContext, Configuration>());
        }

        public virtual IDbSet<Player> Players { get; set; }

        public virtual IDbSet<League> Leagues { get; set; }

        public virtual IDbSet<Season> Seasons { get; set; }

        public virtual IDbSet<Team> Teams { get; set; }

        public virtual IDbSet<Match> Matches { get; set; }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
        
        public static FlmsDbContext Create()
        {
            return new FlmsDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }
        
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                        .HasRequired(x => x.HomeTeam)
                        .WithMany()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                        .HasRequired(x => x.AwayTeam)
                        .WithMany()
                        .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                         e =>
                             e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}