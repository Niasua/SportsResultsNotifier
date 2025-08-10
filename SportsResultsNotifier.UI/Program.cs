using SportsResultsNotifier.UI.Services;

using var httpClient = new HttpClient();
var scraper = new ScraperService(httpClient);

var results = await scraper.GetResultsAsync();

var emailService = new EmailService(
    smtpServer: "smtp.gmail.com",
    port: 587,
    username: "example@gmail.com",
    password: "examplePassword",
    from: "example@gmail.com"
    
);

await emailService.SendEmailAsync(
    to: "example@gmail.com",
    subject: "Sports Results Notifier",
    body: results
);

Console.WriteLine("Notification sent successfully.");