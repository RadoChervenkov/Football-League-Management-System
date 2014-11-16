namespace FLMS.Web.Areas.Administration.Controllers
{
    using FLMS.Data;
    using FLMS.Web.Areas.Administration.Controllers.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : AdminController
    {
        public HomeController(IFlmsData data) : base(data)
        {
        }

        // GET: Administration/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}