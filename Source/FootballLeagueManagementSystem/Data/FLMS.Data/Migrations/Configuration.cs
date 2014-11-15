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
                new Player { FirstName = "Gosho", LastName = "Peshov", DateOfBirth = new DateTime(1990, 1, 1), Position = PlayerPosition.Goalkeeper, Height = 1.80f, Weight = 80f, Team = team },
                new Player { FirstName = "Ivan", LastName = "Stoyanov", DateOfBirth = new DateTime(1990, 2, 2), Position = PlayerPosition.Goalkeeper, Height = 1.81f, Weight = 81f, Team = team },
                new Player { FirstName = "Dragan", LastName = "Ivanov", DateOfBirth = new DateTime(1990, 3, 3), Position = PlayerPosition.Defender, Height = 1.82f, Weight = 82f, Team = team },
                new Player { FirstName = "Stoyan", LastName = "Geshev", DateOfBirth = new DateTime(1990, 4, 4), Position = PlayerPosition.Defender, Height = 1.83f, Weight = 83f, Team = team },
                new Player { FirstName = "Pesho", LastName = "Zashev", DateOfBirth = new DateTime(1990, 5, 5), Position = PlayerPosition.Defender, Height = 1.84f, Weight = 84f, Team = team },
                new Player { FirstName = "Tosho", LastName = "Iliev", DateOfBirth = new DateTime(1990, 6, 6), Position = PlayerPosition.Attacker, Height = 1.85f, Weight = 85f, Team = team },
                new Player { FirstName = "Stamat", LastName = "Petkanov", DateOfBirth = new DateTime(1990, 7, 7), Position = PlayerPosition.Attacker, Height = 1.86f, Weight = 86f, Team = team },
                new Player { FirstName = "Iliya", LastName = "Toshev", DateOfBirth = new DateTime(1990, 8, 8), Position = PlayerPosition.Attacker, Height = 1.87f, Weight = 87f, Team = team },
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
                IsActive = true,
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
                MaxTeamsCount = 10,
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