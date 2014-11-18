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

        public ActionResult Index()
        {
            var season = this.Data.Seasons.All().Where(s => s.Name == "Season 2014").FirstOrDefault();

            var leagues = this.Data.Leagues.All()
                              .Where(l => l.Season.Name == season.Name).Project().To<LeagueTableViewModel>().ToList();

            for (int i = 0; i < leagues.Count; i++)
            {
                var currentLeague = leagues[i];

                foreach (var team in currentLeague.Teams)
                {
                    var homeWins = this.Data.Teams.All().Where(x => x.Id == team.Id).FirstOrDefault()
                                       .Matches.Where(m => m.HomeTeamId == team.Id && m.State == MatchState.Finished && m.Result == MatchResult.HomeWins);

                    var awayWins = this.Data.Teams.All().Where(x => x.Id == team.Id).FirstOrDefault();
                                       /*.Matches.Where(m => m.AwayTeamId == team.Id && m.State == MatchState.Finished && m.Result == MatchResult.AwayWins);*/

                    int k = 0;

                    //var drawsHome = this.Data.Teams.All().Where(x => x.Id == team.Id).FirstOrDefault()
                    //                    .Matches.Where(m => m.HomeTeamId == team.Id && m.State == MatchState.Finished && m.Result == MatchResult.Draw).Count();

                    //var drawsAway = this.Data.Teams.All().Where(x => x.Id == team.Id).FirstOrDefault()
                    //                    .Matches.Where(m => m.AwayTeamId == team.Id && m.State == MatchState.Finished && m.Result == MatchResult.Draw).Count();

                    //var totalWins = homeWins + awayWins;
                    //var totalDraws = drawsHome + drawsAway;

                    //var loses = this.Data.Teams.All().Where(x => x.Id == team.Id).FirstOrDefault().Matches.Where(m => m.State == MatchState.Finished).Count() - totalWins - totalDraws;

                    //var totalLoses = loses;

                    //team.Wins = totalWins;
                    //team.Loses = totalLoses;
                    //team.Draws = totalDraws;

                    //team.Points += (totalWins * 3);
                    //team.Points += totalDraws;
                }
            }

            return View(leagues);
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