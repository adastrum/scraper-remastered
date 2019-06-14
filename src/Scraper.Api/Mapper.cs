using Scraper.Api.Models.Response;
using Scraper.Core.Dto;
using Scraper.Core.Entities;
using System;
using System.Globalization;
using System.Linq;

namespace Scraper.Api
{
    public static class Mapper
    {
        public static Show ToShow(this TvMazeShow dto)
        {
            var show = new Show
            {
                Id = dto.id,
                Name = dto.name,
                Cast = dto._embedded?.cast?.Select(x => x.ToCast()).ToList()
            };

            return show;
        }

        public static ShowDto ToDto(this Show show)
        {
            var dto = new ShowDto
            {
                Id = show.Id,
                Name = show.Name,
                Cast = show.Cast
                    .Select(x => x.ToDto())
                    .ToList()
            };

            return dto;
        }

        private static Cast ToCast(this TvMazeCast dto)
        {
            var person = dto.person;
            if (person == null) return null;

            return new Cast
            {
                Id = person.id,
                Name = person.name,
                Birthday = person.birthday == null ? (DateTimeOffset?)null : DateTimeOffset.Parse(person.birthday)
            };
        }

        public static CastDto ToDto(this Cast cast)
        {
            var dto = new CastDto
            {
                Id = cast.Id,
                Name = cast.Name,
                Birthday = cast.Birthday?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            };

            return dto;
        }
    }
}
