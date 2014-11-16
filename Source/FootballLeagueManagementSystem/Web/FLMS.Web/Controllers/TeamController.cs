namespace FLMS.Web.Controllers
{
    using System.Web.Mvc;
    using FLMS.Data;
    using FLMS.Web.ViewModels.Team;
    using AutoMapper;
    using FLMS.Data.Models;

    [Authorize]
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTeamViewModel team)
        {
            if (team != null && ModelState.IsValid)
            {
                var dbTeam = Mapper.Map<Team>(team);

                this.Data.Teams.Add(dbTeam);
                this.Data.SaveChanges();

                var id = dbTeam.Id;

                return RedirectToAction("Details", new { id = id });
            }

            return View(team);
        }

        public ActionResult LoadPlayersForm(int count)
        {
            ViewBag.PlayersCount = count;
            return PartialView("_PlayersForm");
        }
    }
}