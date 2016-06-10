using GameListRepository;
using GameListRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameListWebsite.Controllers
{
    public class GameListController : Controller
    {
        private GameListDB db = new GameListDB();
        private const int perPage = 20;

        // GET: GameList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexAngular()
        {
            return View();
        }

        public ActionResult JsonListGame(string genre = "", int page = 0)
        {
            List<GameInfo> list = db.GameList.Where(game => string.IsNullOrEmpty(genre) || game.Genre.Contains(genre)).ToList();
            int numGame = list.Count;
            int numPage = Convert.ToInt32(Math.Ceiling((double)numGame / perPage));

            if (numPage > 0)
            {
                page = page < numPage ? page : numPage - 1;
                if (page == numPage - 1)
                    list = list.GetRange(page * perPage, numGame - (page * perPage));
                else
                    list = list.GetRange(page * perPage, perPage);
            }

            return Json(new { numGame = numGame, numPage = numPage, gameList = list }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(int gameId)
        {
            return Content(gameId.ToString());
        }

        public ActionResult JsonGetGenre()
        {
            HashSet<string> GenreList = new HashSet<string>();
            var list = db.GameList;
            list.ForEach(e =>
            {
                e.Genre.ForEach(item => { GenreList.Add(item); });
            });
            var outputList = GenreList.ToList();
            outputList.Sort();
            return Json(outputList, JsonRequestBehavior.AllowGet);
        }
    }
}