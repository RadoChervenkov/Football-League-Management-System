namespace FLMS.Web.Areas.Management.Controllers
{
    using System.Web.Mvc;

    public class TeamController : Controller
    {
        // GET: Management/Team
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPlayerInputs(int count)
        {
            ViewBag.InputsCount = count;
            return PartialView("_PlayersForm");
        }
    }
}