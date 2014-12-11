namespace FLMS.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using FLMS.Data;
    using FLMS.Web.Areas.Administration.Controllers.Base;

    public class MatchesController : AdminController
    {
        public MatchesController(IFlmsData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}