using FLMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FLMS.Web.Controllers
{
    public class PlayerController : BaseController
    {
        public PlayerController(IFlmsData data) : base(data)
        {
        }
        // GET: Player
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {


            return View();
        }

        public ActionResult All()
        {
            var players = this.Data.Players.All();

            return View(players);
        }
    }
}