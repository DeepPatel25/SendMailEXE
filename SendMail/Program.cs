using Newtonsoft.Json;
using SendMail.Handler;
using SendMail.Models;

string fileContent = File.ReadAllText("config.json");

MailSendModel? config = JsonConvert.DeserializeObject<MailSendModel>(fileContent);

if (
    config == null
    || string.IsNullOrEmpty(config.ClientId)
    || string.IsNullOrEmpty(config.ClientSecret)
    || string.IsNullOrEmpty(config.TenantId)
    || string.IsNullOrEmpty(config.FromUser)
    || string.IsNullOrEmpty(config.ToUser)
)
{
    Console.WriteLine("Configuration is missing or invalid.");
    return;
}

GraphEmailService service = new(
    tenantId: config.TenantId,
    clientId: config.ClientId,
    clientSecret: config.ClientSecret,
    fromUser: config.FromUser // must be licensed mailbox
);

await service.SendEmailAsync(
    new
    {
        message = new
        {
            subject = "Mail Testing Using Graph QL Service.",
            body = new ItemBody(
                "<p>Hello Team,<br/>Here is the <b>latest</b> update with attachment.</p>",
                "HTML"
            ),
            importance = "normal", // low, high, normal
            toRecipients = new List<Recipient>
            {
                new(config.ToUser, "Testing User"),
                new("second@gmail.com", "Testing User 2"),
            },
            ccRecipients = new List<Recipient> { new(config.CcUser, "Manager") },
            attachments = new List<FileAttachment>
            {
                // AttachmentHelper.CreateFileAttachment("report.txt", "report.txt", "text/plain"),
            },
            internetMessageHeaders = new[]
            {
                new { name = "X-Custom-Header", value = "Developer Testing" },
            },
        },
        saveToSentItems = true,
    }
);
