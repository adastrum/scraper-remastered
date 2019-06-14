using System.Collections.Generic;

namespace Scraper.Core.Dto
{
    //todo
    public class TvMazeShow
    {
        public int id { get; set; }
        public string name { get; set; }
        public TvMazeEmbedded _embedded { get; set; }
    }

    //todo
    public class TvMazeEmbedded
    {
        public List<TvMazeCast> cast { get; set; }
    }

    //todo
    public class TvMazeCast
    {
        public TvMazePerson person { get; set; }
    }

    //todo
    public class TvMazePerson
    {
        public int id { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
    }
}
