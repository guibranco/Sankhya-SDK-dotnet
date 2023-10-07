//

using System.Xml.Serialization;

namespace Sankhya.Service;

/// <summary>
///     The notas canceladas.
/// </summary>
public sealed class CancelledInvoices
{
    /// <summary>
    /// Gets or sets the justification.
    /// </summary>
    /// <value>
    /// The justification.
    /// </value>
    [XmlAttribute("justificativa")]
    public string Justification { get; set; }

    /// <summary>
    /// Gets or sets the single numbers.
    /// </summary>
    /// <value>
    /// The single numbers.
    /// </value>
    [XmlElement("nunota")]
    public int[] SingleNumbers { get; set; }
}
