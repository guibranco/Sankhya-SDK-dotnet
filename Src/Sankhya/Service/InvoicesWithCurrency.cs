
//

namespace Sankhya.Service;

using System.Xml.Serialization;

/// <summary>
///     The notas com moeda.
/// </summary>
///
public sealed class InvoicesWithCurrency
{
    /// <summary>
    ///     Gets or sets the valor moeda.
    /// </summary>
    ///
    /// <value>
    ///     The valor moeda.
    /// </value>

    [XmlAttribute(AttributeName = "valorMoeda")]
    public string CurrencyValue { get; set; }
}