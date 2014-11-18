using FLMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using FLMS.Web.ViewModels.League;
using FLMS.Data.Models;

namespace FLMS.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IFlmsData data) : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 60 * 60)]
        [ChildActionOnly]
        public ActionResult GetLeaguesData()
        {
            var season = this.Data.Seasons.All().Where(s => s.Name == "Season 2014").FirstOrDefault();

            var leagues = this.Data.Leagues.All()
                              .Where(l => l.Season.Name == season.Name).Project().To<LeagueTableViewModel>().ToList();

            for (int i = 0; i < leagues.Count; i++)
            {
                var currentLeague = leagues[i];

                foreach (var team in currentLeague.Teams)
                {
                    var winsHome = this.Data.Matches.All().Where(m => m.LeagueId == currentLeague.Id && m.HomeTeamId == team.Id && m.State == MatchState.Finished && m.Result == MatchResult.HomeWins).Count();
                    var winsAway = this.Data.Matches.All().Where(m => m.LeagueId == currentLeague.Id && m.AwayTeamId == team.Id && m.State == MatchState.Finished && m.Result == MatchResult.AwayWins).Count();

                    var drawsHome = this.Data.Matches.All().Where(m => m.LeagueId == currentLeague.Id && m.HomeTeamId == team.Id && m.State == MatchState.Finished && m.Result == MatchResult.Draw).Count();
                    var drawsAway = this.Data.Matches.All().Where(m => m.LeagueId == currentLeague.Id && m.AwayTeamId == team.Id && m.State == MatchState.Finished && m.Result == MatchResult.Draw).Count();

                    var losesHome = this.Data.Matches.All().Where(m => m.LeagueId == currentLeague.Id && m.HomeTeamId == team.Id && m.State == MatchState.Finished && m.Result == MatchResult.AwayWins).Count();
                    var losesAway = this.Data.Matches.All().Where(m => m.LeagueId == currentLeague.Id && m.AwayTeamId == team.Id && m.State == MatchState.Finished && m.Result == MatchResult.HomeWins).Count();

                    var totalWins = winsHome + winsAway;
                    var totalDraws = drawsHome + drawsAway;
                    var totalLoses = losesHome + losesAway;

                    team.Wins = totalWins;
                    team.Loses = totalLoses;
                    team.Draws = totalDraws;

                    team.Points += (totalWins * 3);
                    team.Points += totalDraws;
                }

                currentLeague.Teams = currentLeague.Teams.OrderByDescending(x => x.Points).ToList();
            }
            
            return PartialView("_LeaguesPartial", leagues);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}