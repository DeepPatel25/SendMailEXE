using Newtonsoft.Json;

namespace SendMail.Models;

/// <summary>
/// Represents a file attachment for an email message.
/// </summary>
public class FileAttachment
{
    /// <summary>
    /// The type of the attachment.
    /// </summary>
    [JsonProperty("@odata.type")]
    public string ODataType { get; set; } = "#microsoft.graph.fileAttachment";

    /// <summary>
    /// The name of the attachment.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = default!;

    /// <summary>
    /// The content type of the attachment.
    /// </summary>
    [JsonProperty("contentType")]
    public string ContentType { get; set; } = default!;

    /// <summary>
    /// Indicates whether the attachment is inline.
    /// </summary>
    [JsonProperty("isInline")]
    public bool IsInline { get; set; }

    /// <summary>
    /// The base64-encoded content of the attachment.
    /// </summary>
    [JsonProperty("contentBytes")]
    public string ContentBytes { get; set; } = default!;
}
