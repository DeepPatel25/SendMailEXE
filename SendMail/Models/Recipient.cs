using Newtonsoft.Json;

namespace SendMail.Models;

/// <summary>
/// Recipient model class
/// </summary>
public class Recipient
{
    #region Properties

    /// <summary>
    /// Email address of the recipient
    /// </summary>
    [JsonProperty("emailAddress")]
    public EmailAddress EmailAddress { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor for Recipient class
    /// </summary>
    /// <param name="address">An email address</param>
    /// <param name="name">A name associated with the email address</param>
    public Recipient(string address, string name = "")
    {
        EmailAddress = new EmailAddress { Address = address, Name = name };
    }

    #endregion
}
