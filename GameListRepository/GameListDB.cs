using GameListRepository.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace GameListRepository
{
    public class GameListDB
    {
        public static List<GameInfo> _gamelist;
        public List<GameInfo> GameList
        {
            get
            {
                if (_gamelist == null)
                    updateGameListCache();
                return _gamelist;
            }
        }

        public void Refresh()
        {
            updateGameListCache();
        }

        private void updateGameListCache()
        {
            var serializer = new JavaScriptSerializer();
            var json_list = serializer.Deserialize<List<GameInfoJSON>>(File.ReadAllText(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["DBFilePath"])));
            _gamelist = json_list.Select(item => new GameInfo(item)).ToList();

            _gamelist.ForEach(game =>
            {
                game.Genre = game.Genre.Select(g => g[0].ToString().ToUpper() + g.Substring(1)).ToList();
            });
        }
    }
}