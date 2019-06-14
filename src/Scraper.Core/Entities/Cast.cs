using System;

namespace Scraper.Core.Entities
{
    public class Cast
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset? Birthday { get; set; }
    }
}
