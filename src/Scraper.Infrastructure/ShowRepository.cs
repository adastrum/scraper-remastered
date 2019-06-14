using LiteDB;
using Scraper.Core.Entities;
using Scraper.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scraper.Infrastructure
{
    public class ShowRepository : IShowRepository
    {
        private const string ShowDbName = "shows";
        private const int MaxLimit = 100;

        public async Task SaveAsync(IEnumerable<Show> shows)
        {
            using (var db = new LiteDatabase(ShowDbName))
            {
                var collection = db.GetCollection<Show>();

                collection.Insert(shows);
            }
        }

        public async Task ClearAsync()
        {
            using (var db = new LiteDatabase(ShowDbName))
            {
                db.GetCollection<Show>().Delete(_ => true);
            }
        }

        public async Task<IEnumerable<Show>> FindAsync(int pageSize, int pageNumber)
        {
            using (var db = new LiteDatabase(ShowDbName))
            {
                var skip = pageNumber == 0 ? 0 : pageSize * (pageNumber - 1);
                var limit = pageSize > MaxLimit ? MaxLimit : pageSize;

                return db.GetCollection<Show>().Find(_ => true, skip, limit);
            }
        }
    }
}
