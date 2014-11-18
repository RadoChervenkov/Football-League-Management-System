namespace FLMS.Web.Areas.Management.Controllers
{
    using System.Web.Mvc;

    using FLMS.Data;
    using FLMS.Web.Areas.Management.Controllers.Base;

    public class TeamController : ManagementController
    {
        public TeamController(IFlmsData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult GetPlayerInputs(int count)
        {
            ViewBag.InputsCount = count;
            return this.PartialView("_PlayersForm");
        }
    }
}