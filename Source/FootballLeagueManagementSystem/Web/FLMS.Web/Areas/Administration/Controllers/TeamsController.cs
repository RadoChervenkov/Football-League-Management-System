namespace FLMS.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using FLMS.Data;
    using FLMS.Web.Areas.Administration.Controllers.Base;
    using FLMS.Web.Areas.Administration.ViewModels.League;
    using FLMS.Web.Areas.Administration.ViewModels.Teams;
    using Kendo.Mvc.UI;

    using Model = FLMS.Data.Models.Team;
    using ViewModel = FLMS.Web.Areas.Administration.ViewModels.Teams.TeamViewModel;


    public class TeamsController : KendoGridAdministrationController
    {
        public TeamsController(IFlmsData data)
            : base(data)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        public ActionResult Index()
        {
            ViewData["leagues"] = this.Data.Leagues.All().Project().To<LeagueViewModel>();

            return View();
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null)
            {
                model.Id = dbModel.Id;
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]
                                    DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Teams.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Teams.All().Project().To<TeamViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Teams.GetById(id) as T;
        }
    }
}