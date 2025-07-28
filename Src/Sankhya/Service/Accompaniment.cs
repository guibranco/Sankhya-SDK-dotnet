using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class Accompaniment. This class cannot be inherited.
/// </summary>
public sealed class Accompaniment
{
    /// <summary>
    /// The date
    /// </summary>
    private DateTime _date;

    /// <summary>
    /// The date set
    /// </summary>
    private bool _dateSet;

    /// <summary>
    /// The time
    /// </summary>
    private TimeSpan _time;

    /// <summary>
    /// The time set
    /// </summary>
    private bool _timeSet;

    /// <summary>
    /// The occurrence
    /// </summary>
    private string _occurrence;

    /// <summary>
    /// The occurrence set
    /// </summary>
    private bool _occurrenceSet;

    /// <summary>
    /// The user
    /// </summary>
    private string _user;

    /// <summary>
    /// The user set
    /// </summary>
    private bool _userSet;

    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    /// <value>The date.</value>
    [XmlIgnore]
    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            _dateSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date internal.
    /// </summary>
    /// <value>The date internal.</value>
    [XmlAttribute("dhocorrencia")]
    public string DateInternal
    {
        get => _date.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture);
        set
        {
            _date = DateTime.ParseExact(value, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
            _dateSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the time.
    /// </summary>
    /// <value>The time.</value>
    [XmlIgnore]
    public TimeSpan Time
    {
        get => _time;
        set
        {
            _time = value;
            _timeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the time internal.
    /// </summary>
    /// <value>The time internal.</value>
    [XmlAttribute("horaocorrencia")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TimeInternal
    {
        get => _time.ToString();
        set
        {
            if (!TimeSpan.TryParse(value, out _time))
            {
                return;
            }

            _timeSet = true;
        }
    }

    /// <summary>
    /// Gets the full date.
    /// </summary>
    /// <value>The full date.</value>
    [XmlIgnore]
    public DateTime FullDate => _date.Add(_time);

    /// <summary>
    /// Gets or sets the occurrence.
    /// </summary>
    /// <value>The occurrence.</value>
    [XmlAttribute("ocorrencias")]
    public string Occurrence
    {
        get => _occurrence;
        set
        {
            _occurrence = value;
            _occurrenceSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>The user.</value>
    [XmlAttribute("usuario")]
    public string User
    {
        get => _user;
        set
        {
            _user = value;
            _userSet = true;
        }
    }

    /// <summary>
    /// Shoulds the serialize date internal.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateInternal() => _dateSet;

    /// <summary>
    /// Shoulds the serialize time internal.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTimeInternal() => _timeSet;

    /// <summary>
    /// Shoulds the serialize occurrence.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOccurrence() => _occurrenceSet;

    /// <summary>
    /// Shoulds the serialize user.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUser() => _userSet;
}
