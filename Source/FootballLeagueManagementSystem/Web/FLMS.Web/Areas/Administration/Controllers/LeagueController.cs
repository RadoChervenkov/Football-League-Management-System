namespace FLMS.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using FLMS.Data;
    using FLMS.Data.Models;
    using FLMS.Web.Areas.Administration.ViewModels.League;
    using FLMS.Web.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class LeagueController : BaseController
    {
        public LeagueController(IFlmsData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var league = this.Data.Leagues.GetById(id);

            //project to

            if (league == null)
            {
                throw new HttpException(404, "League not found!");
            }

            return View(league);
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

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeagueInputModel inputModel)
        {
            if (inputModel != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<League>(inputModel);
                this.Data.Leagues.Add(dbModel);
                this.Data.SaveChanges();
                
                return RedirectToAction("Index");
            }

            return View(inputModel);
        }
    }
}