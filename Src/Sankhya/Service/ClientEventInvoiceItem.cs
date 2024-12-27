using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class ClientEventInvoiceItem
{
    private int _singleNumber;

    private bool _singleNumberSet;

    private int _sequence;

    private bool _sequenceSet;

    private decimal _quantityTraded;

    private bool _quantityTradedSet;

    private int _codeExecution;

    private bool _codeExecutionSet;

    private int _codeSeller;

    private bool _codeSellerSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSequence() => _sequenceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeQuantityTraded() => _quantityTradedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeExecution() => _codeExecutionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSeller() => _codeSellerSet;
}
