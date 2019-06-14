using System.Threading.Tasks;

namespace Scraper.Core.Interfaces
{
    public interface ITvMazeApiClient
    {
        Task<string> GetShowAsync(int showId);
    }
}