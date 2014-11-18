using FLMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using FLMS.Web.ViewModels.Player;

namespace FLMS.Web.Controllers
{
    public class PlayerController : BaseController
    {
        public PlayerController(IFlmsData data) : base(data)
        {
        }

        public ActionResult Details(int id)
        {


            return View();
        }

        public ActionResult All()
        {
            var players = this.Data.Players.All().Project().To<PlayerListViewModel>().ToList();

            return View(players);
        }
    }
}