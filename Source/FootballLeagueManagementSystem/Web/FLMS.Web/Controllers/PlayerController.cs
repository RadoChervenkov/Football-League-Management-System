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
            var player = this.Data.Players.All().Where(p => p.Id == id).Project().To<PlayerDetailsViewModel>().FirstOrDefault();

            if (player == null)
            {
                throw new HttpException(404, "Player not found");
            }

            return View(player);
        }

        public ActionResult All()
        {
            var players = this.Data.Players.All().Project().To<PlayerListViewModel>().ToList();

            return View(players);
        }
    }
}