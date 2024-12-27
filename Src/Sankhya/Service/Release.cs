using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

[XmlType("liberacao")]
public sealed class Release
{
    private int _key;

    private bool _keySet;

    private int _event;

    private bool _eventSet;

    private string _eventDescription;

    private bool _eventDescriptionSet;

    private string _table;

    private bool _tableSet;

    private int _sequence;

    private bool _sequenceSet;

    private int _sequenceCascade;

    private bool _sequenceCascadeSet;

    private DateTime _dateRequested;

    private bool _dateRequestedSet;

    private DateTime _dateReleased;

    private bool _dateReleasedSet;

    private string _description;

    private bool _descriptionSet;

    private int _releasing;

    private bool _releasingSet;

    private int _limit;

    private bool _limitSet;

    private int _requester;

    private bool _requesterSet;

    private decimal _totalAmount;

    private bool _totalAmountSet;

    private decimal _currentAmount;

    private bool _currentAmountSet;

    private decimal _releasedAmount;

    private bool _releasedAmountSet;

    private decimal _previousRequestedAmount;

    private bool _previousRequestedAmountSet;

    private decimal _percentage;

    private bool _percentageSet;

    private decimal _previousPercentage;

    private bool _previousPercentageSet;

    private string _eventType;

    private bool _eventTypeSet;

    private bool _editReleasing;

    private bool _editReleasingSet;

    private bool _editCurrentAmount;

    private bool _editCurrentAmountSet;

    private string _releasingNotes;

    private bool _releasingNotesSet;

    private string _releaseHash;

    private bool _releaseHashSet;

    [XmlAttribute("chave")]
    public int Key
    {
        get => _key;
        set
        {
            _key = value;
            _keySet = true;
        }
    }

    [XmlAttribute("evento")]
    public int Event
    {
        get => _event;
        set
        {
            _event = value;
            _eventSet = true;
        }
    }

    [XmlAttribute("descricaoEvento")]
    public string EventDescription
    {
        get => _eventDescription;
        set
        {
            _eventDescription = value;
            _eventDescriptionSet = true;
        }
    }

    [XmlAttribute("tabela")]
    public string Table
    {
        get => _table;
        set
        {
            _table = value;
            _tableSet = true;
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

    [XmlAttribute("sequenciaCascata")]
    public int SequenceCascade
    {
        get => _sequenceCascade;
        set
        {
            _sequenceCascade = value;
            _sequenceCascadeSet = true;
        }
    }

    [XmlAttribute("dhSolicitacao")]
    public string DateRequestedInternal
    {
        get => _dateRequested.ToString(@"dd/MM/yyyy HH:mm");
        set
        {
            if (
                string.IsNullOrWhiteSpace(value)
                || !DateTime.TryParseExact(
                    value,
                    @"dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var result
                )
            )
            {
                return;
            }

            _dateRequested = result;
            _dateRequestedSet = true;
        }
    }

    [XmlIgnore]
    public DateTime DateRequested
    {
        get => _dateRequested;
        set
        {
            _dateRequested = value;
            _dateReleasedSet = true;
        }
    }

    [XmlAttribute("dhLiberacao")]
    public string DateReleasedInternal
    {
        get => _dateReleased.ToString(@"dd;MM/yyyy HH:mm");
        set
        {
            if (
                string.IsNullOrWhiteSpace(value)
                || !DateTime.TryParseExact(
                    value,
                    @"dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var result
                )
            )
            {
                return;
            }

            _dateReleased = result;
            _dateReleasedSet = true;
        }
    }

    [XmlIgnore]
    public DateTime DateReleased
    {
        get => _dateReleased;
        set
        {
            _dateReleased = value;
            _dateReleasedSet = true;
        }
    }

    [XmlAttribute("descricao")]
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            _descriptionSet = true;
        }
    }

    [XmlAttribute("liberador")]
    public int Releasing
    {
        get => _releasing;
        set
        {
            _releasing = value;
            _releasingSet = true;
        }
    }

    [XmlAttribute("limit")]
    public int Limit
    {
        get => _limit;
        set
        {
            _limit = value;
            _limitSet = true;
        }
    }

    [XmlAttribute("solicitante")]
    public int Requester
    {
        get => _requester;
        set
        {
            _requester = value;
            _requesterSet = true;
        }
    }

    [XmlAttribute("valorTotal")]
    public decimal TotalAmount
    {
        get => _totalAmount;
        set
        {
            _totalAmount = value;
            _totalAmountSet = true;
        }
    }

    [XmlAttribute("valorAtual")]
    public decimal CurrentAmount
    {
        get => _currentAmount;
        set
        {
            _currentAmount = value;
            _currentAmountSet = true;
        }
    }

    [XmlAttribute("valorLiberado")]
    public decimal ReleasedAmount
    {
        get => _releasedAmount;
        set
        {
            _releasedAmount = value;
            _releasedAmountSet = true;
        }
    }

    [XmlAttribute("vlrSolicitadoAnterior")]
    public decimal PreviousRequestedAmount
    {
        get => _previousRequestedAmount;
        set
        {
            _previousRequestedAmount = value;
            _previousRequestedAmountSet = true;
        }
    }

    [XmlAttribute("porcentagem")]
    public decimal Percentage
    {
        get => _percentage;
        set
        {
            _percentage = value;
            _percentageSet = true;
        }
    }

    [XmlAttribute("porcentagemAnterior")]
    public decimal PreviousPercentage
    {
        get => _previousPercentage;
        set
        {
            _previousPercentage = value;
            _previousPercentageSet = true;
        }
    }

    [XmlAttribute("tipoEvento")]
    public string EventType
    {
        get => _eventType;
        set
        {
            _eventType = value;
            _eventTypeSet = true;
        }
    }

    [XmlIgnore]
    public bool EditReleasing
    {
        get => _editReleasing;
        set
        {
            _editReleasing = value;
            _editReleasingSet = true;
        }
    }

    [XmlAttribute("editaLiberador")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string EditReleasingInternal
    {
        get => _editReleasing.ToString(@"S", @"N");
        set
        {
            _editReleasing = value.ToBoolean();
            _editReleasingSet = true;
        }
    }

    [XmlIgnore]
    public bool EditCurrentAmount
    {
        get => _editCurrentAmount;
        set
        {
            _editCurrentAmount = value;
            _editCurrentAmountSet = true;
        }
    }

    [XmlAttribute("editaVlrAtual")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string EditCurrentAmountInternal
    {
        get => _editCurrentAmount.ToString(@"S", @"N");
        set
        {
            _editCurrentAmount = value.ToBoolean();
            _editCurrentAmountSet = true;
        }
    }

    [XmlAttribute("obsLiberador")]
    public string ReleasingNotes
    {
        get => _releasingNotes;
        set
        {
            _releasingNotes = value;
            _releasingNotesSet = true;
        }
    }

    [XmlAttribute("hashLiberacao")]
    public string ReleaseHash
    {
        get => _releaseHash;
        set
        {
            _releaseHash = value;
            _releaseHashSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeKey() => _keySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEvent() => _eventSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEventDescription() => _eventDescriptionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTable() => _tableSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSequence() => _sequenceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSequenceCascade() => _sequenceCascadeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateRequestedInternal() => _dateRequestedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateReleased() => _dateReleasedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDescription() => _descriptionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReleasing() => _releasingSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLimit() => _limitSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRequester() => _requesterSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTotalAmount() => _totalAmountSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCurrentAmount() => _currentAmountSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReleasedAmount() => _releasedAmountSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePreviousRequestedAmount() => _previousRequestedAmountSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePercentage() => _percentageSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePreviousPercentage() => _previousPercentageSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEventType() => _eventTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEditReleasing() => _editReleasingSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEditCurrentAmount() => _editCurrentAmountSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReleasingNotes() => _releasingNotesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReleaseHash() => _releaseHashSet;
}
