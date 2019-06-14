using System.Collections.Generic;

namespace Scraper.Api.Models.Response
{
    public class ShowDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CastDto> Cast { get; set; }
    }
}
