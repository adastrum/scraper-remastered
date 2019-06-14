using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Scraper.Api.Models;
using Scraper.Core.Dto;
using Scraper.Core.Entities;
using Scraper.Core.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Scraper.Api.HostedServices
{
    public class ShowScrapingService : IHostedService
    {
        private readonly int _batchSize = 100;

        private readonly ITvMazeApiClient _tvMazeService;
        private readonly IShowRepository _showRepository;

        public ShowScrapingService(ITvMazeApiClient tvMazeService, IShowRepository showRepository)
        {
            _tvMazeService = tvMazeService;
            _showRepository = showRepository;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _showRepository.ClearAsync();

            var skip = 0;
            var take = _batchSize;

            do
            {
                var tasks = Enumerable
                .Range(skip, take)
                .Select(showId => FetchAsync(showId));

                var results = await Task.WhenAll(tasks);

                var shows = results
                    .Where(x => x.IsSuccess)
                    .Select(x => x.Value)
                    .ToList();

                if (!shows.Any())
                {
                    break;
                }

                await _showRepository.SaveAsync(shows);

                skip += _batchSize;
            }
            while (true);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }

        private async Task<Result<Show>> FetchAsync(int showId)
        {
            var showJson = await _tvMazeService.GetShowAsync(showId);
            if (string.IsNullOrEmpty(showJson))
            {
                return Result<Show>.Failure();
            }

            var tvMazeShow = JsonConvert.DeserializeObject<TvMazeShow>(showJson);

            var show = tvMazeShow.ToShow();

            return Result<Show>.Success(show);
        }
    }
}
