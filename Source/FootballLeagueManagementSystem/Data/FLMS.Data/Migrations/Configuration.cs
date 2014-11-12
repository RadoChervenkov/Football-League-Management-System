namespace FLMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FLMS.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    internal sealed class Configuration : DbMigrationsConfiguration<FlmsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FlmsDbContext context)
        {
            if (!context.Roles.Any())
            {
                this.SeedRolesAndUsers(context);
            }
        }

        private void SeedRolesAndUsers(FlmsDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole("Administrator"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser { UserName = "admin" };
            userManager.Create(user, "admin321");
            userManager.AddToRole(user.Id, "Administrator");
        }
    }
}