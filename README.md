# scraper-remastered
Another take on the [old task](https://github.com/adastrum/scraper) about web scraping.

* [Polly](https://github.com/App-vNext/Polly) for retries (transient failures and rate limiting)
* [LiteDb](http://www.litedb.org/) for persistence
* Scraping running as background ask (.NET Core [hosted service](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.2&tabs=visual-studio)).
