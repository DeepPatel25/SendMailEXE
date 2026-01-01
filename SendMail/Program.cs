using SendMail.Handler;
using SendMail.Models;

GraphEmailService service = new(
    tenantId: "your-tenant-id",
    clientId: "your-client-id",
    clientSecret: "your-client-secret",
    fromUser: "name@domain.com" // must be licensed mailbox
);

await service.SendEmailAsync(
    new
    {
        message = new
        {
            subject = "Quarterly Update",
            body = new ItemBody(
                "<p>Hello Team,<br/>Here is the <b>latest</b> update with attachment.</p>",
                "HTML"
            ),
            importance = "High",
            sensitivity = "Confidential",
            toRecipients = new List<Recipient> { new("alice@domain.com", "Alice") },
            ccRecipients = new List<Recipient> { new("manager@domain.com", "Manager") },
            attachments = new List<FileAttachment>
            {
                // AttachmentHelper.CreateFileAttachment("report.txt", "report.txt", "text/plain"),
            },
            internetMessageHeaders = new[] { new { name = "X-Custom-Header", value = "MyValue" } },
        },
        saveToSentItems = true,
    }
);
