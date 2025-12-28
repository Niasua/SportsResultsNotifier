using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SportsResultsNotifier.UI.Services;
using System.ComponentModel;

namespace SportsResultsNotifier.UI;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ScraperService _scraperService;
    private readonly EmailService _emailService;

    // 24 hours - config
    private readonly TimeSpan _repeatInterval = TimeSpan.FromHours(24);

    public Worker(ILogger<Worker> logger, ScraperService scraperService, EmailService emailService)
    {
        _logger = logger;
        _scraperService = scraperService;
        _emailService = emailService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker started at: {time}", DateTimeOffset.Now);

        using PeriodicTimer timer = new PeriodicTimer(_repeatInterval);

        // first execution, before cycle
        try
        {
            await DoWork();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "error on first execution");
        }

        // 24h loop
        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                await DoWork();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "an error ocurred while performing daily task");
            }
        }
    }

    private async Task DoWork()
    {
        _logger.LogInformation("Obtaining data...");

        // scrap
        var data = await _scraperService.GetResultsAsync();

        // send email
        await _emailService.SendEmailAsync("nsuarez2410@gmail.com", "Daily Results", data);

        _logger.LogInformation("Task completed for today!");
    }
}
