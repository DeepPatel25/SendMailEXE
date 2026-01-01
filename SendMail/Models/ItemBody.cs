using Newtonsoft.Json;

namespace SendMail.Models;

/// <summary>
/// Represents the body of an email item.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ItemBody"/> class with specified content and type.
/// </remarks>
/// <param name="content">The content of the email body.</param>
/// <param name="type">The content type of the email body (e.g., "HTML" or "Text").</param>
public class ItemBody(string content, string type = "HTML")
{
    #region Properties

    /// <summary>
    /// The content type of the email body (e.g., "HTML" or "Text").
    /// </summary>
    [JsonProperty("contentType")]
    public string ContentType { get; set; } = type;

    /// <summary>
    /// The content of the email body.
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; } = content;

    #endregion
}
