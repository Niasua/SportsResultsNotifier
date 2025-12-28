using SportsResultsNotifier.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsResultsNotifier.UI;
using SportsResultsNotifier.UI.Settings;

// builder creation
var builder = Host.CreateApplicationBuilder(args);

// services config
// using Typed Client

builder.Services.AddHttpClient<ScraperService>();
builder.Services.AddHostedService<Worker>();

// link EmailSettings class to JSON file
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddTransient<EmailService>();
// create host
var host = builder.Build();

host.Run();