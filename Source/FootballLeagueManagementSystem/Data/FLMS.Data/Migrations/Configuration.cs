namespace FLMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FLMS.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System;
    
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
                this.SeedSeasons(context);
                this.SeedLeagues(context);
                this.SeedTeams(context);
                this.SeedPlayers(context);
            }
        }

        private void SeedPlayers(FlmsDbContext context)
        {
            var team = context.Teams.Where(x => x.Name == "TelerikAcademy").First();

            var players = new List<Player>()
            {
                new Player { FirstName = "Gosho", LastName = "Peshov", DateOfBirth = new DateTime(1990, 1, 1), Position = PlayerPosition.Goalkeeper, Height = 180, Weight = 80, Team = team },
                new Player { FirstName = "Ivan", LastName = "Stoyanov", DateOfBirth = new DateTime(1990, 2, 2), Position = PlayerPosition.Goalkeeper, Height = 181, Weight = 81, Team = team },
                new Player { FirstName = "Dragan", LastName = "Ivanov", DateOfBirth = new DateTime(1990, 3, 3), Position = PlayerPosition.Defender, Height = 182, Weight = 82, Team = team },
                new Player { FirstName = "Stoyan", LastName = "Geshev", DateOfBirth = new DateTime(1990, 4, 4), Position = PlayerPosition.Defender, Height = 183, Weight = 83, Team = team },
                new Player { FirstName = "Pesho", LastName = "Zashev", DateOfBirth = new DateTime(1990, 5, 5), Position = PlayerPosition.Defender, Height = 184, Weight = 84, Team = team },
                new Player { FirstName = "Tosho", LastName = "Iliev", DateOfBirth = new DateTime(1990, 6, 6), Position = PlayerPosition.Attacker, Height = 185, Weight = 85, Team = team },
                new Player { FirstName = "Stamat", LastName = "Petkanov", DateOfBirth = new DateTime(1990, 7, 7), Position = PlayerPosition.Attacker, Height = 186, Weight = 86, Team = team },
                new Player { FirstName = "Iliya", LastName = "Toshev", DateOfBirth = new DateTime(1990, 8, 8), Position = PlayerPosition.Attacker, Height = 187, Weight = 87, Team = team },
            };

            foreach (var player in players)
            {
                context.Players.Add(player);
            }

            context.SaveChanges();
        }

        private void SeedTeams(FlmsDbContext context)
        {
            var league = context.Leagues.Where(x => x.Name == "Elites").First();

            var seedTeam = new Team()
            {
                Name = "TelerikAcademy",
                League = league
            };

            context.Teams.Add(seedTeam);
            context.SaveChanges();
        }

        private void SeedLeagues(FlmsDbContext context)
        {
            var season = context.Seasons.Where(x => x.Name == "Season 2014").First();

            var league = new League()
            {
                Name = "Elites",
                Season = season
            };

            context.Leagues.Add(league);
            context.SaveChanges();
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

        private void SeedSeasons(FlmsDbContext context)
        {
            var season2014 = new Season
            {
                Name = "Season 2014"
            };

            var season2015 = new Season
            {
                Name = "Season 2015"
            };

            context.Seasons.Add(season2014);
            context.Seasons.Add(season2015);

            context.SaveChanges();
        }
    }
}