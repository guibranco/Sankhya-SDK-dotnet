using System.Xml.Serialization;
using Sankhya.Helpers;

namespace Sankhya.Service;

/// <summary>
/// Class DataRow. This class cannot be inherited.
/// </summary>
[XmlRoot("DataRow")]
public sealed class DataRow
{
    /// <summary>
    /// Gets or sets the local fields.
    /// </summary>
    /// <value>The local fields.</value>
    [XmlElement("localFields")]
    public EntityDynamicSerialization LocalFields { get; set; }

    /// <summary>
    /// Gets or sets the keys.
    /// </summary>
    /// <value>The keys.</value>
    [XmlElement("key")]
    public EntityDynamicSerialization Keys { get; set; }
}
