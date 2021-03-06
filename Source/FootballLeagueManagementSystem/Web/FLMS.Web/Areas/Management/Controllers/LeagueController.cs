﻿namespace FLMS.Web.Areas.Management.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using FLMS.Data;
    using FLMS.Data.Models;
    using FLMS.Web.Areas.Administration.ViewModels.League;
    using FLMS.Web.Areas.Management.Controllers.Base;
    using FLMS.Web.Areas.Management.ViewModels.League;

    public class LeagueController : ManagementController
    {
        public LeagueController(IFlmsData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Details(int id)
        {
            var league = this.Data.Leagues.GetById(id);

            if (league == null)
            {
                throw new HttpException(404, "League not found!");
            }

            return this.View(league);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var seasons = this.Data.Seasons.All().ToList();

            var model = new LeagueInputModel();
            model.SelectableSeasons = seasons.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name.ToString()
            }).ToList();

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeagueViewModel inputModel)
        {
            if (inputModel != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<League>(inputModel);
                this.Data.Leagues.Add(dbModel);
                this.Data.SaveChanges();

                this.TempData["success"] = "Successfully created new league!";
                
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(inputModel);
        }
    }
}