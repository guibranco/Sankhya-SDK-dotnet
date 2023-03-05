namespace Sankhya.Service;

using System.Xml.Serialization;
using CrispyWaffle.Serialization;

/// <summary>
/// Class Path. This class cannot be inherited.
/// </summary>
[Serializer]
public sealed class Path
{
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    [XmlText]
    public string Value { get; set; }

}