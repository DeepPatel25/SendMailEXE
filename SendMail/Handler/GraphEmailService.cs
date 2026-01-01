using Newtonsoft.Json;
using RestSharp;

namespace SendMail.Handler;

/// <summary>
/// Service to send emails using Microsoft Graph API
/// </summary>
public class GraphEmailService(
    string tenantId,
    string clientId,
    string clientSecret,
    string fromUser
)
{
    #region Fields

    /// <summary>
    /// Configuration parameters for Microsoft Graph API
    /// </summary>
    private readonly string _tenantId = tenantId;

    /// <summary>
    /// Configuration parameters for Microsoft Graph API
    /// </summary>
    private readonly string _clientId = clientId;

    /// <summary>
    /// Configuration parameters for Microsoft Graph API
    /// </summary>
    private readonly string _clientSecret = clientSecret;

    /// <summary>
    /// Configuration parameters for Microsoft Graph API
    /// </summary>
    private readonly string _fromUser = fromUser;

    #endregion

    #region Methods

    /// <summary>
    /// Get OAuth2 access token from Microsoft Identity Platform
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception">returns an error message if the token request fails</exception>
    private async Task<string> GetAccessTokenAsync()
    {
        string baseUrl = "https://login.microsoftonline.com";
        string endpoint = $"/{_tenantId}/oauth2/v2.0/token";

        RestClient client = new(baseUrl);
        RestRequest request = new(endpoint, Method.Post);

        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddParameter("client_id", _clientId);
        request.AddParameter("client_secret", _clientSecret);
        request.AddParameter("scope", "https://graph.microsoft.com/.default");
        request.AddParameter("grant_type", "client_credentials");

        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new Exception($"Token Error: {response.Content}");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        dynamic result = JsonConvert.DeserializeObject(response.Content!);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return result.access_token;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    /// <summary>
    /// Send an email using Microsoft Graph API
    /// </summary>
    /// <param name="mailRequest">mail request object</param>
    /// <returns>returns a boolean indicating success or failure</returns>
    /// <exception cref="Exception">exception if sending fails</exception>
    public async Task SendEmailAsync(object mailRequest)
    {
        string accessToken = await GetAccessTokenAsync();
        string baseUrl = "https://graph.microsoft.com";
        string endpoint = $"/v1.0/users/{_fromUser}/sendMail";

        RestClient client = new(baseUrl);
        RestRequest request = new(endpoint, Method.Post);

        request.AddHeader("Authorization", $"Bearer {accessToken}");
        request.AddHeader("Content-Type", "application/json");

        request.AddJsonBody(mailRequest);

        RestResponse response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new Exception($"Mail Error: {response.Content}");

        Console.WriteLine("✅ Email sent successfully!");
    }

    #endregion
}
