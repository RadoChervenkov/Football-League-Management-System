namespace FLMS.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using FLMS.Data;
    using FLMS.Web.Areas.Administration.Controllers.Base;
    using FLMS.Web.Areas.Administration.ViewModels.Seasons;
    using Kendo.Mvc.UI;
    
    using Model = FLMS.Data.Models.Season;
    using ViewModel = FLMS.Web.Areas.Administration.ViewModels.Seasons.SeasonsViewModel;

    public class SeasonsController : KendoGridAdministrationController
    {
        public SeasonsController(IFlmsData data)
            : base(data)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }
        public ActionResult Index()
        {
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
                this.Data.Seasons.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Seasons.All().Project().To<SeasonsViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Seasons.GetById(id) as T;
        }
    }
}