using Newtonsoft.Json;

namespace SendMail.Models;

/// <summary>
/// Email address model class
/// </summary>
public class EmailAddress
{
    /// <summary>
    /// Email address
    /// </summary>
    [JsonProperty("address")]
    public string Address { get; set; } = default!;

    /// <summary>
    /// Name associated with the email address
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = default!;
}
