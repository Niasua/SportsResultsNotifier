# Sports Results Notifier

Sports Results Notifier is a .NET Worker Service that scrapes basketball results from [Basketball Reference](https://www.basketball-reference.com/) every 24 hours and sends them via email automatically.

It leverages **Html Agility Pack** for scraping, **Microsoft.Extensions.Hosting** for background task management, and the **Options Pattern** for secure configuration.

---

## Features

- **Automated Service:** Runs as a background task without user intervention.
- **Web Scraping:** Extracts latest game results efficiently.
- **Email Notification:** Sends formatted results using SMTP.
- **Secure Configuration:** Supports User Secrets for local development.

---

## Configuration

This project requires configuration settings for the Email Service.

### Local Development (User Secrets)
For local development, it is recommended to use **User Secrets** to avoid committing sensitive data to the repository.

Run the following command in the project directory to set your secrets:

```bash
dotnet user-secrets set "EmailSettings:Password" "your_app_password"
dotnet user-secrets set "EmailSettings:Username" "your_email@gmail.com"
```

### Production (appsettings.json)
Alternatively, you can configure the appsettings.json file. Ensure this file contains the following structure:
```json
{
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "Port": 587,
    "Username": "YOUR_EMAIL@gmail.com",
    "Password": "YOUR_APP_PASSWORD",
    "From": "YOUR_EMAIL@gmail.com",
    "EnableSsl": true
  }
}
```