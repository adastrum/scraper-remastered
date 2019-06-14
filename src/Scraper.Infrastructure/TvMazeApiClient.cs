using Scraper.Core.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Scraper.Infrastructure
{
    public class TvMazeApiClient : ITvMazeApiClient
    {
        private readonly HttpClient _httpClient;

        public TvMazeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetShowAsync(int showId)
        {
            var requestUri = $"{showId}?embed=cast";

            var response = await _httpClient.GetAsync(requestUri);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
