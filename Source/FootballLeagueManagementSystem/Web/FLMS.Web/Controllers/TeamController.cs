namespace FLMS.Web.Controllers
{
    using System.Web.Mvc;
    using FLMS.Data;
    using FLMS.Web.ViewModels.Team;

    public class TeamController : BaseController
    {
        public TeamController(IFlmsData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateTeamViewModel team)
        {
            return View();
        }

        public ActionResult LoadPlayersForm(int count)
        {
            ViewBag.PlayersCount = count;
            return PartialView("_PlayersForm");
        }
    }
}