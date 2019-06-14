using Microsoft.AspNetCore.Mvc;
using Scraper.Api.Models.Response;
using Scraper.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scraper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly IShowRepository _showRepository;

        public ShowsController(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowDto>>> Get([FromQuery]int pageSize, [FromQuery]int pageNumber)
        {
            var shows = await _showRepository.FindAsync(pageSize, pageNumber);

            var showDtos = shows
                .Select(x => x.ToDto())
                .ToList();

            foreach (var showDto in showDtos)
            {
                showDto.Cast = showDto.Cast.OrderByDescending(x => x.Birthday).ToList();
            }

            return Ok(showDtos);
        }
    }
}
