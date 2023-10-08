using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class ClientEventInvoiceItem. This class cannot be inherited.
/// </summary>
public sealed class ClientEventInvoiceItem
{
    /// <summary>
    /// The single number
    /// </summary>
    private int _singleNumber;

    /// <summary>
    /// The single number set
    /// </summary>
    private bool _singleNumberSet;

    /// <summary>
    /// The sequence
    /// </summary>
    private int _sequence;

    /// <summary>
    /// The sequence set
    /// </summary>
    private bool _sequenceSet;

    /// <summary>
    /// The quantity traded
    /// </summary>
    private decimal _quantityTraded;

    /// <summary>
    /// The quantity traded set
    /// </summary>
    private bool _quantityTradedSet;

    /// <summary>
    /// The code execution
    /// </summary>
    private int _codeExecution;

    /// <summary>
    /// The code execution set
    /// </summary>
    private bool _codeExecutionSet;

    /// <summary>
    /// The code seller
    /// </summary>
    private int _codeSeller;

    /// <summary>
    /// The code seller set
    /// </summary>
    private bool _codeSellerSet;

    /// <summary>
    /// Gets or sets the single number.
    /// </summary>
    /// <value>The single number.</value>
    [XmlAttribute("nuNota")]
    public int SingleNumber
    {
        get => _singleNumber;
        set
        {
            _singleNumber = value;
            _singleNumberSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the sequence.
    /// </summary>
    /// <value>The sequence.</value>
    [XmlAttribute("sequencia")]
    public int Sequence
    {
        get => _sequence;
        set
        {
            _sequence = value;
            _sequenceSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the quantity traded.
    /// </summary>
    /// <value>The quantity traded.</value>
    [XmlAttribute("qtdNeg")]
    public decimal QuantityTraded
    {
        get => _quantityTraded;
        set
        {
            _quantityTraded = value;
            _quantityTradedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code execution.
    /// </summary>
    /// <value>The code execution.</value>
    [XmlAttribute("codExec")]
    public int CodeExecution
    {
        get => _codeExecution;
        set
        {
            _codeExecution = value;
            _codeExecutionSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code seller.
    /// </summary>
    /// <value>The code seller.</value>
    [XmlAttribute("codeVend")]
    public int CodeSeller
    {
        get => _codeSeller;
        set
        {
            _codeSeller = value;
            _codeSellerSet = true;
        }
    }

    /// <summary>
    /// Should the serialize single number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    /// <summary>
    /// Should the serialize sequence.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSequence() => _sequenceSet;

    /// <summary>
    /// Should the serialize quantity traded.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeQuantityTraded() => _quantityTradedSet;

    /// <summary>
    /// Should the serialize code execution.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeExecution() => _codeExecutionSet;

    /// <summary>
    /// Should the serialize code seller.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSeller() => _codeSellerSet;
}
