namespace FLMS.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FLMS.Data;
    using FLMS.Data.Models;
    using FLMS.Web.ViewModels.Team;

    public class TeamController : BaseController
    {
        public TeamController(IFlmsData data) : base(data)
        {
        }

        [HttpGet]
        public ActionResult All()
        {
            var teams = this.Data.Teams.All().Project().To<TeamListViewModel>().ToList();

            return this.View(teams);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var team = this.Data.Teams.All().Where(x => x.Id == id).Project()
                           .To<TeamDetailsViewModel>().First();

            if (team == null)
            {
                throw new HttpException(404, "Team not found");
            }

            return this.View(team);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreateViewModel team)
        {
            if (team != null && ModelState.IsValid)
            {
                var dbTeam = Mapper.Map<Team>(team);

                this.Data.Teams.Add(dbTeam);
                this.Data.SaveChanges();

                var id = dbTeam.Id;

                return this.RedirectToAction("Details", new { id = id });
            }

            return this.View(team);
        }

        [Authorize]
        public ActionResult LoadPlayersForm(int count)
        {
            ViewBag.PlayersCount = count;
            return this.PartialView("_PlayersForm");
        }
    }
}