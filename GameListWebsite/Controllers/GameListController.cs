using GameListRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameListWebsite.Controllers
{
    public class GameListController : Controller
    {
        // GET: GameList
        public ActionResult Index()
        {
            var db = new GameListDB();
            var list = db.GameList;
            return View(list);
        }

        public ActionResult Detail(int gameId)
        {
            return Content(gameId.ToString());
        }
    }
}