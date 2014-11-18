﻿namespace FLMS.Web.Areas.Management.Controllers
{
    using FLMS.Data;
    using FLMS.Web.Areas.Management.Controllers.Base;
    using System;
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using FLMS.Web.Areas.Management.ViewModels.Team;
    using FLMS.Web.Areas.Management.ViewModels.Match;
    using AutoMapper;
    using FLMS.Data.Models;
    using FLMS.Web.Areas.Management.ViewModels.League;

    public class MatchController : ManagementController
    {
        public MatchController(IFlmsData data) : base(data)
        {
        }

        [HttpGet]
        public ActionResult Create()
        {
            var leagues = this.Data.Leagues.All().Project().To<LeagueDropdownViewModel>().ToList();

            var model = new LeagueDropdownViewModel();
            model.SelectableLeagues = leagues.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name.ToString()
            }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MatchInputModel input)
        {
            if (input != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<Match>(input);
                dbModel.State = MatchState.Pending;
                this.Data.Matches.Add(dbModel);
                this.Data.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GetTeams(int id)
        {
            var teams = this.Data.Teams.All().Where(t => t.LeagueId == id).Project().To<TeamViewModel>().ToList();

            var model = new MatchInputModel();
            model.LeagueId = id;
            model.SelectableTeams = teams.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name.ToString()
            }).ToList();

            return PartialView("_CreateMatchPartial", model);
        }

        [HttpGet]
        public ActionResult Result()
        {
            var matches = this.Data.Matches.All().Where(m => m.State == MatchState.Pending)
                              .Project().To<MatchDropdownViewModel>().ToList();

            var model = new MatchResultInputModel();
            model.SelectableTeams = matches.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name.ToString()
            }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result(MatchResultInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var match = this.Data.Matches.All().Where(m => m.Id == model.Id && m.State == MatchState.Pending).FirstOrDefault();
                if (match != null)
                {
                    if (model.HomeGoals > model.AwayGoals)
                    {
                        match.Result = MatchResult.HomeWins;
                    }
                    else if (model.AwayGoals > model.HomeGoals)
                    {
                        match.Result = MatchResult.AwayWins;
                    }
                    else
                    {
                        match.Result = MatchResult.Draw;
                    }

                    match.HomeGoals = model.HomeGoals;
                    match.AwayGoals = model.AwayGoals;
                    match.State = MatchState.Finished;

                    this.Data.SaveChanges();

                    TempData["success"] = "Successfully added match result!";

                    return RedirectToAction("Index", "Home");
                    
                }

                throw new HttpException(400, "Invalid match!");                
            }

            return View(model);
        }
    }
}