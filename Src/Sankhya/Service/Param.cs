using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class Param
{
    private int _financialNumber;

    private bool _financialNumberSet;

    private int _financialNumberUpperCase;

    private bool _financialNumberUpperCaseSet;

    private int _bankNumber;

    private bool _bankNumberSet;

    private string _recompose;

    private bool _recomposeSet;

    private string _revertAllAnticipation;

    private bool _revertAllAnticipationSet;

    [XmlAttribute(AttributeName = "nuFin")]
    public int FinancialNumber
    {
        get => _financialNumber;
        set
        {
            _financialNumber = value;
            _financialNumberSet = true;
        }
    }

    [XmlAttribute(AttributeName = "NUFIN")]
    public int FinancialNumberUpperCase
    {
        get => _financialNumberUpperCase;
        set
        {
            _financialNumberUpperCase = value;
            _financialNumberUpperCaseSet = true;
        }
    }

    [XmlAttribute(AttributeName = "nuBco")]
    public int BankNumber
    {
        get => _bankNumber;
        set
        {
            _bankNumber = value;
            _bankNumberSet = true;
        }
    }

    [XmlAttribute(AttributeName = "recompoe")]
    public string Recompose
    {
        get => _recompose;
        set
        {
            _recompose = value;
            _recomposeSet = true;
        }
    }

    [XmlAttribute(AttributeName = "estornarTodosAntecipacao")]
    public string RevertAllAnticipation
    {
        get => _revertAllAnticipation;
        set
        {
            _revertAllAnticipation = value;
            _revertAllAnticipationSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFinancialNumber() => _financialNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFinancialNumberUpperCase() => _financialNumberUpperCaseSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeBankNumber() => _bankNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRecompose() => _recomposeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRevertAllAnticipation() => _revertAllAnticipationSet;
}
