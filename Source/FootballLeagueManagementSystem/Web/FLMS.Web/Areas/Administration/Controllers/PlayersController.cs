using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FLMS.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using FLMS.Data;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using FLMS.Data.Models;
    using System.Collections;
    using Model = FLMS.Data.Models.Player;
    using ViewModel = FLMS.Web.Areas.Administration.ViewModels.Players.PlayersViewModel;
    using FLMS.Web.Areas.Administration.Controllers.Base;

    public class PlayersController : KendoGridAdministrationController
    {
        public PlayersController(IFlmsData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Players.All();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Players.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null)
                model.Id = dbModel.Id;
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
    }
}