namespace FLMS.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;
    using FLMS.Data;
    using FLMS.Web.Areas.Administration.Controllers.Base;
    using Kendo.Mvc.UI;
    using Model = FLMS.Data.Models.Player;
    using ViewModel = FLMS.Web.Areas.Administration.ViewModels.Players.PlayersViewModel;

    public class PlayersController : KendoGridAdministrationController
    {
        public PlayersController(IFlmsData data) : base(data)
        {
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
                this.Data.Players.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }
            
            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Players.All();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Players.GetById(id) as T;
        }
    }
}