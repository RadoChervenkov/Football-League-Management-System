﻿namespace FLMS.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using FLMS.Data;
    using FLMS.Web.ViewModels.Team;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FLMS.Data.Models;

    public class TeamController : BaseController
    {
        public TeamController(IFlmsData data) : base(data)
        {
        }

        [HttpGet]
        public ActionResult All()
        {
            var teams = this.Data.Teams.All().Project().To<TeamListViewModel>().ToList();

            return View(teams);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var team = this.Data.Teams.All().Where(x => x.Id == id).Project()
                           .To<TeamDetailsViewModel>().First();

            return View(team);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreateViewModel team)
        {
            if (team != null && ModelState.IsValid)
            {
                var dbTeam = Mapper.Map<Team>(team);

                this.Data.Teams.Add(dbTeam);
                this.Data.SaveChanges();

                var id = dbTeam.Id;

                return RedirectToAction("Details", new { id = id });
            }

            return View(team);
        }

        public ActionResult LoadPlayersForm(int count)
        {
            ViewBag.PlayersCount = count;
            return PartialView("_PlayersForm");
        }
    }
}