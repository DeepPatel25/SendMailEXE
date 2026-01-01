namespace SendMail.Handler;

using System.IO;
using SendMail.Models;

/// <summary>
/// Helper class for creating file attachments for emails.
/// </summary>
public static class AttachmentHelper
{
    #region Methods

    /// <summary>
    /// Creates a file attachment from the specified file path.
    /// </summary>
    /// <param name="filePath">file path of the attachment</param>
    /// <param name="name">name of the attachment</param>
    /// <param name="mimeType">MIME type of the attachment</param>
    /// <returns></returns>
    public static FileAttachment CreateFileAttachment(string filePath, string name, string mimeType)
    {
        byte[] bytes = File.ReadAllBytes(filePath);
        string base64 = Convert.ToBase64String(bytes);

        return new FileAttachment
        {
            Name = name,
            ContentType = mimeType,
            IsInline = false,
            ContentBytes = base64,
        };
    }

    #endregion
}
