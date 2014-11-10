namespace FLMS.Data.Migrations
{
    using FLMS.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FLMS.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FLMS.Data.ApplicationDbContext context)
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
