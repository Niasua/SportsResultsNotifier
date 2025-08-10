using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using SportsResultsNotifier.UI.Services;
using SportsResultsNotifier.UI;

using var httpClient = new HttpClient();
var scraper = new ScraperService(httpClient);

var results = await scraper.GetResultsAsync();

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

string host = config["Smtp:Host"];
int port = int.Parse(config["Smtp:Port"]);
bool enableSs1 = bool.Parse(config["Smtp:EnableSs1"]);
string user = config["Smtp:User"];
string pass = config["Smtp:Password"];

var emailService = new EmailService(
    smtpServer: host,
    port: port,
    username: user,
    password: pass,
    from: user
    
);

await emailService.SendEmailAsync(
    to: "example@gmail.com",
    subject: "Sports Results Notifier",
    body: results
);

Console.WriteLine("Notification sent successfully.");