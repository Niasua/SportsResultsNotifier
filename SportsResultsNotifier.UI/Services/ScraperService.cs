using HtmlAgilityPack;

namespace SportsResultsNotifier.UI.Services;

public class ScraperService
{
    private readonly HttpClient _httpClient;

    public ScraperService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetResultsAsync()
    {
        var url = "https://www.basketball-reference.com/boxscores/";
        var html = await _httpClient.GetStringAsync(url);

        var htmDoc = new HtmlDocument();
        htmDoc.LoadHtml(html);

        return "...";
    }
}
