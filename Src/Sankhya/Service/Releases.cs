using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class Releases. This class cannot be inherited.
/// </summary>
[XmlRoot("liberacoes")]
[Serializer]
public sealed class Releases
{
    /// <summary>
    /// Gets or sets the release.
    /// </summary>
    /// <value>The release.</value>
    [XmlElement("liberacao")]
    public Release[] Release { get; set; }
}
