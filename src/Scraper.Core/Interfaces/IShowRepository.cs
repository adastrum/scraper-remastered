using Scraper.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scraper.Core.Interfaces
{
    public interface IShowRepository
    {
        Task SaveAsync(IEnumerable<Show> shows);

        Task ClearAsync();

        Task<IEnumerable<Show>> FindAsync(int pageSize, int pageNumber);
    }
}