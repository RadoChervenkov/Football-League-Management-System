namespace FLMS.Web.Areas.Administration.Controllers
{
    using FLMS.Data;
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

        [HttpGet]
        public ActionResult Create(LeagueInputModel inputModel)
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

        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }
    }
}