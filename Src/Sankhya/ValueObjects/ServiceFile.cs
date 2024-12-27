namespace Sankhya.ValueObjects;

/// <summary>
/// Represents a file used in a service.
/// </summary>
public sealed class ServiceFile
{
    /// <summary>
    /// Gets or sets the content type of the file.
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Gets or sets the file extension.
    /// </summary>
    public string FileExtension { get; set; }

    /// <summary>
    /// Gets or sets the data of the file.
    /// </summary>
    public byte[] Data { get; set; }
}
