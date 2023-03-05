namespace Sankhya.Service;

using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

/// <summary>
/// Class Release. This class cannot be inherited.
/// </summary>
[XmlType("liberacao")]
public sealed class Release
{

    #region Private Members

    /// <summary>
    /// The key
    /// </summary>
    private int _key;
    /// <summary>
    /// The key set
    /// </summary>
    private bool _keySet;

    /// <summary>
    /// The event
    /// </summary>
    private int _event;
    /// <summary>
    /// The event set
    /// </summary>
    private bool _eventSet;

    /// <summary>
    /// The event description
    /// </summary>
    private string _eventDescription;
    /// <summary>
    /// The event description set
    /// </summary>
    private bool _eventDescriptionSet;

    /// <summary>
    /// The table
    /// </summary>
    private string _table;
    /// <summary>
    /// The table set
    /// </summary>
    private bool _tableSet;

    /// <summary>
    /// The sequence
    /// </summary>
    private int _sequence;
    /// <summary>
    /// The sequence set
    /// </summary>
    private bool _sequenceSet;

    /// <summary>
    /// The sequence cascade
    /// </summary>
    private int _sequenceCascade;
    /// <summary>
    /// The sequence cascade set
    /// </summary>
    private bool _sequenceCascadeSet;

    /// <summary>
    /// The date requested
    /// </summary>
    private DateTime _dateRequested;
    /// <summary>
    /// The date requested set
    /// </summary>
    private bool _dateRequestedSet;

    /// <summary>
    /// The date released
    /// </summary>
    private DateTime _dateReleased;
    /// <summary>
    /// The date released set
    /// </summary>
    private bool _dateReleasedSet;

    /// <summary>
    /// The description
    /// </summary>
    private string _description;
    /// <summary>
    /// The description set
    /// </summary>
    private bool _descriptionSet;

    /// <summary>
    /// The releasing
    /// </summary>
    private int _releasing;
    /// <summary>
    /// The releasing set
    /// </summary>
    private bool _releasingSet;

    /// <summary>
    /// The limit
    /// </summary>
    private int _limit;
    /// <summary>
    /// The limit set
    /// </summary>
    private bool _limitSet;

    /// <summary>
    /// The requester
    /// </summary>
    private int _requester;
    /// <summary>
    /// The requester set
    /// </summary>
    private bool _requesterSet;

    /// <summary>
    /// The total amount
    /// </summary>
    private decimal _totalAmount;
    /// <summary>
    /// The total amount set
    /// </summary>
    private bool _totalAmountSet;

    /// <summary>
    /// The current amount
    /// </summary>
    private decimal _currentAmount;
    /// <summary>
    /// The current amount set
    /// </summary>
    private bool _currentAmountSet;

    /// <summary>
    /// The released amount
    /// </summary>
    private decimal _releasedAmount;
    /// <summary>
    /// The released amount set
    /// </summary>
    private bool _releasedAmountSet;

    /// <summary>
    /// The previous requested amount
    /// </summary>
    private decimal _previousRequestedAmount;
    /// <summary>
    /// The previous requested amount set
    /// </summary>
    private bool _previousRequestedAmountSet;

    /// <summary>
    /// The percentage
    /// </summary>
    private decimal _percentage;
    /// <summary>
    /// The percentage set
    /// </summary>
    private bool _percentageSet;

    /// <summary>
    /// The previous percentage
    /// </summary>
    private decimal _previousPercentage;
    /// <summary>
    /// The previous percentage set
    /// </summary>
    private bool _previousPercentageSet;

    /// <summary>
    /// The event type
    /// </summary>
    private string _eventType;
    /// <summary>
    /// The event type set
    /// </summary>
    private bool _eventTypeSet;

    /// <summary>
    /// The edit releasing
    /// </summary>
    private bool _editReleasing;
    /// <summary>
    /// The edit releasing set
    /// </summary>
    private bool _editReleasingSet;

    /// <summary>
    /// The edit current amount
    /// </summary>
    private bool _editCurrentAmount;
    /// <summary>
    /// The edit current amount set
    /// </summary>
    private bool _editCurrentAmountSet;

    /// <summary>
    /// The releasing notes
    /// </summary>
    private string _releasingNotes;
    /// <summary>
    /// The releasing notes set
    /// </summary>
    private bool _releasingNotesSet;

    /// <summary>
    /// The hash
    /// </summary>
    private string _releaseHash;
    /// <summary>
    /// The hash set
    /// </summary>
    private bool _releaseHashSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the key
    /// </summary>
    /// <value>
    /// The key.
    /// </value>

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

    /// <summary>
    /// Gets or sets the event
    /// </summary>
    /// <value>
    /// The event.
    /// </value>

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

    /// <summary>
    /// Gets or sets the event description
    /// </summary>
    /// <value>
    /// The event description.
    /// </value>

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

    /// <summary>
    /// Gets or sets the table
    /// </summary>
    /// <value>
    /// The table.
    /// </value>

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

    /// <summary>
    /// Gets or sets the sequence
    /// </summary>
    /// <value>
    /// The sequence.
    /// </value>
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
    /// Gets or sets the sequence cascade
    /// </summary>
    /// <value>
    /// The sequence cascade.
    /// </value>
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

    /// <summary>
    /// Gets or sets the date requested
    /// </summary>
    /// <value>
    /// The date requested.
    /// </value>
    [XmlAttribute("dhSolicitacao")]
    public string DateRequestedInternal
    {
        get => _dateRequested.ToString(@"dd/MM/yyyy HH:mm");
        set
        {
            if (string.IsNullOrWhiteSpace(value) ||
                !DateTime.TryParseExact(value,
                    @"dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var result))
            {
                return;
            }

            _dateRequested = result;
            _dateRequestedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date requested
    /// </summary>
    /// <value>
    /// The date requested.
    /// </value>
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

    /// <summary>
    /// Gets or sets the date released
    /// </summary>
    /// <value>
    /// The date released.
    /// </value>
    [XmlAttribute("dhLiberacao")]
    public string DateReleasedInternal
    {
        get => _dateReleased.ToString(@"dd;MM/yyyy HH:mm");
        set
        {
            if (string.IsNullOrWhiteSpace(value) ||
                !DateTime.TryParseExact(value,
                    @"dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var result))
            {
                return;
            }

            _dateReleased = result;
            _dateReleasedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date released
    /// </summary>
    /// <value>
    /// The date released.
    /// </value>
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

    /// <summary>
    /// Gets or sets the description
    /// </summary>
    /// <value>
    /// The description.
    /// </value>
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

    /// <summary>
    /// Gets or sets the releasing
    /// </summary>
    /// <value>
    /// The releasing.
    /// </value>
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

    /// <summary>
    /// Gets or sets the limit
    /// </summary>
    /// <value>
    /// The limit.
    /// </value>
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

    /// <summary>
    /// Gets or sets the requester
    /// </summary>
    /// <value>
    /// The requester.
    /// </value>
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

    /// <summary>
    /// Gets or sets the total amount
    /// </summary>
    /// <value>
    /// The total amount.
    /// </value>
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

    /// <summary>
    /// Gets or sets the current amount
    /// </summary>
    /// <value>
    /// The current amount.
    /// </value>
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

    /// <summary>
    /// Gets or sets the released amount
    /// </summary>
    /// <value>
    /// The released amount.
    /// </value>
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

    /// <summary>
    /// Gets or sets the previous requested amount
    /// </summary>
    /// <value>
    /// The previous requested amount.
    /// </value>
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

    /// <summary>
    /// Gets or sets the percentage
    /// </summary>
    /// <value>
    /// The percentage.
    /// </value>
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

    /// <summary>
    /// Gets or sets the previous percentage
    /// </summary>
    /// <value>
    /// The previous percentage.
    /// </value>
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

    /// <summary>
    /// Gets or sets the event type
    /// </summary>
    /// <value>
    /// The event type.
    /// </value>
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

    /// <summary>
    /// Gets or sets a value indicating whether [edit releasing].
    /// </summary>
    /// <value><c>true</c> if [edit releasing]; otherwise, <c>false</c>.</value>
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

    /// <summary>
    /// Gets or sets the edit releasing internal.
    /// </summary>
    /// <value>The edit releasing internal.</value>
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

    /// <summary>
    /// Gets or sets the edit current amount
    /// </summary>
    /// <value>
    /// The edit current amount flag.
    /// </value>
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

    /// <summary>
    /// Gets or sets the edit current amount internal 
    /// </summary>
    /// <value>
    /// The edit current amount internal flag as string.
    /// </value>
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

    /// <summary>
    /// Gets or sets the releasing notes.
    /// </summary>
    /// <value>The releasing notes.</value>
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

    /// <summary>
    /// Gets or sets the release hash
    /// </summary>
    /// <value>
    /// The release hash.
    /// </value>
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


    #endregion

    #region Serializer Helpers

    /// <summary>
    /// The should serialize key serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeKey() => _keySet;

    /// <summary>
    /// The should serialize event serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeEvent() => _eventSet;

    /// <summary>
    /// The should serialize event description serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeEventDescription() => _eventDescriptionSet;

    /// <summary>
    /// The should serialize table serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeTable() => _tableSet;

    /// <summary>
    /// The should serialize sequence serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeSequence() => _sequenceSet;

    /// <summary>
    /// The should serialize sequence cascade serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeSequenceCascade() => _sequenceCascadeSet;

    /// <summary>
    /// The should serialize date requested serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeDateRequestedInternal() => _dateRequestedSet;

    /// <summary>
    /// The should serialize date released serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeDateReleased() => _dateReleasedSet;

    /// <summary>
    /// The should serialize description serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDescription() => _descriptionSet;

    /// <summary>
    /// If should the serialize releasing.
    /// </summary>
    /// <returns><c>true</c> if should serialize, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeReleasing() => _releasingSet;

    /// <summary>
    /// The should serialize limit serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLimit() => _limitSet;

    /// <summary>
    /// The should serialize requester serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRequester() => _requesterSet;

    /// <summary>
    /// The should serialize total amount serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTotalAmount() => _totalAmountSet;

    /// <summary>
    /// The should serialize current amount serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCurrentAmount() => _currentAmountSet;

    /// <summary>
    /// The should serialize released amount serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReleasedAmount() => _releasedAmountSet;

    /// <summary>
    /// The should serialize previous requested amount serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePreviousRequestedAmount() => _previousRequestedAmountSet;

    /// <summary>
    /// The should serialize percentage serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePercentage() => _percentageSet;

    /// <summary>
    /// The should serialize previous percentage serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePreviousPercentage() => _previousPercentageSet;

    /// <summary>
    /// The should serialize event type serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEventType() => _eventTypeSet;

    /// <summary>
    /// If should serialize edit releasing.
    /// </summary>
    /// <returns><c>true</c> if should serialize, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEditReleasing() => _editReleasingSet;

    /// <summary>
    /// The should serialize edit current amount serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEditCurrentAmount() => _editCurrentAmountSet;

    /// <summary>
    /// If Should the serialize releasing notes.
    /// </summary>
    /// <returns><c>true</c> if should serialize, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReleasingNotes() => _releasingNotesSet;

    /// <summary>
    /// The should serialize hash serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeReleaseHash() => _releaseHashSet;

    #endregion

}