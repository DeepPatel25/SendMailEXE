namespace SendMail.Models;

/// <summary>
/// Model for sending mail
/// </summary>
public class MailSendModel
{
    /// <summary>
    /// Tenant ID
    /// </summary>
    public string TenantId { get; set; } = default!;

    /// <summary>
    /// Client ID
    /// </summary>
    public string ClientId { get; set; } = default!;

    /// <summary>
    /// client Secret
    /// </summary>
    public string ClientSecret { get; set; } = default!;

    /// <summary>
    /// From User
    /// </summary>
    public string FromUser { get; set; } = default!;

    /// <summary>
    /// To User
    /// </summary>
    public string ToUser { get; set; } = default!;

    /// <summary>
    /// CC User
    /// </summary>
    public string CcUser { get; set; } = default!;
}
