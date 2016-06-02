using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameListRepository.Models
{
    public class GameInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Genre { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Exclusive { get; set; }
        public string ReleaseDateEurope { get; set; }
        public string ReleaseDateJapan { get; set; }
        public string ReleaseDateUS { get; set; }
        
        public GameInfo(GameInfoJSON json_data)
        {
            Id = json_data.id;
            Title = json_data.title;
            Genre = json_data.genre;
            Developer = json_data.developer;
            Publisher = json_data.publisher;
            Exclusive = json_data.exclusive;
            ReleaseDateEurope = json_data.rdate_eu;
            ReleaseDateJapan = json_data.rdate_ja;
            ReleaseDateUS = json_data.rdate_us;
        }
    }

    public class GameInfoJSON
    {
        public int id;
        public string title { get; set; }
        public List<string> genre { get; set; }
        public string developer { get; set; }
        public string publisher { get; set; }
        public string exclusive { get; set; }
        public string rdate_eu { get; set; }
        public string rdate_ja { get; set; }
        public string rdate_us { get; set; }
    }
}