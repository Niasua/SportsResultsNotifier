using SportsResultsNotifier.UI.Services;

using var httpClient = new HttpClient();
var scraper = new ScraperService(httpClient);

var results = await scraper.GetResultsAsync();

Console.WriteLine(results);