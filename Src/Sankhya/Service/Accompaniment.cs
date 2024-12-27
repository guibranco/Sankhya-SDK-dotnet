using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class Accompaniment
{
    private DateTime _date;

    private bool _dateSet;

    private TimeSpan _time;

    private bool _timeSet;

    private string _occurrence;

    private bool _occurrenceSet;

    private string _user;

    private bool _userSet;

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

    [XmlIgnore]
    public DateTime FullDate => _date.Add(_time);

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateInternal() => _dateSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTimeInternal() => _timeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOccurrence() => _occurrenceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUser() => _userSet;
}
