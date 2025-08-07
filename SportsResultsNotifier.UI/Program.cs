using SportsResultsNotifier.UI.Services;

using var httpClient = new HttpClient();
var scraper = new ScraperService(httpClient);

var results = await scraper.GetResultsAsync();

Console.WriteLine(results);

var emailService = new EmailService(
    smtpServer: "smtp.gmail.com",
    port: 587,
    username: "example@gmail.com",
    password: "passwordExample",
    from: "example@gmail.com"
    
);

await emailService.SendEmailAsync(
    to: "example@gmail.com",
    subject: "Sports Results Notifier Test",
    body: "This is an email sent from C#"
);

Console.WriteLine("Sent successfully.");