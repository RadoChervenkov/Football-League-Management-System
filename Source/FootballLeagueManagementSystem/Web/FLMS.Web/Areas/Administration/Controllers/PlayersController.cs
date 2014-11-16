namespace FLMS.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;
    using System.Linq;
    using FLMS.Data;
    using FLMS.Web.Areas.Administration.Controllers.Base;
    using Kendo.Mvc.UI;
    using AutoMapper.QueryableExtensions;

    using FLMS.Web.Areas.Administration.ViewModels.Players;
    using System.Threading;
    using System.Globalization;
    using FLMS.Web.Areas.Administration.ViewModels.Team;

    using Model = FLMS.Data.Models.Player;
    using ViewModel = FLMS.Web.Areas.Administration.ViewModels.Players.PlayersViewModel;

    public class PlayersController : KendoGridAdministrationController
    {
        public PlayersController(IFlmsData data) : base(data)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        public ActionResult Index()
        {
            ViewData["teams"] = this.Data.Teams.All().Project().To<TeamViewModel>();
                                    //.Select(t => new TeamViewModel
                                    //       {
                                    //           Id = t.Id,
                                    //           Name = t.Name
                                    //       });

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
                this.Data.Players.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }
            
            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Players.All().Project().To<PlayersViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Players.GetById(id) as T;
        }
    }
}