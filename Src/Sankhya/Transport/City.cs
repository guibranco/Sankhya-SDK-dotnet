// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="City.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Transport
{
    using CrispyWaffle.Serialization;
    using System.ComponentModel;
    using System;
    using Sankhya.Attributes;

    /// <summary>
    /// The city entity
    /// </summary>
    /// <seealso cref="IEntity" />

    [Serializer]
    [Entity("Cidade")]
    public class City : IEntity, IEquatable<City>
    {
        #region Equality members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        // ReSharper disable once CyclomaticComplexity
        public bool Equals(City other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return ReferenceEquals(this, other) || _code == other._code && _codeSet == other._codeSet && _codeState == other._codeState &&
                   _codeStateSet == other._codeStateSet && _codeRegion == other._codeRegion &&
                   _codeRegionSet == other._codeRegionSet && _codeFiscal == other._codeFiscal &&
                   _codeFiscalSet == other._codeFiscalSet &&
                   string.Equals(_name, other._name, StringComparison.InvariantCultureIgnoreCase) &&
                   _nameSet == other._nameSet &&
                   string.Equals(
                       _descriptionCorreios,
                       other._descriptionCorreios,
                       StringComparison.InvariantCultureIgnoreCase) &&
                   _descriptionCorreiosSet == other._descriptionCorreiosSet &&
                   Equals(_state, other._state) && _stateSet == other._stateSet &&
                   Equals(_region, other._region) && _regionSet == other._regionSet &&
                   _areaCode == other._areaCode && _areaCodeSet == other._areaCodeSet &&
                   string.Equals(_latitude, other._latitude, StringComparison.InvariantCultureIgnoreCase) &&
                   _latitudeSet == other._latitudeSet &&
                   string.Equals(_longitude, other._longitude, StringComparison.InvariantCultureIgnoreCase) &&
                   _longitudeSet == other._longitudeSet;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return ReferenceEquals(this, obj) || obj.GetType() == GetType() && Equals((City)obj);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _code;
                hashCode = (hashCode * 397) ^ _codeSet.GetHashCode();
                hashCode = (hashCode * 397) ^ _codeState;
                hashCode = (hashCode * 397) ^ _codeStateSet.GetHashCode();
                hashCode = (hashCode * 397) ^ _codeRegion;
                hashCode = (hashCode * 397) ^ _codeRegionSet.GetHashCode();
                hashCode = (hashCode * 397) ^ _codeFiscal;
                hashCode = (hashCode * 397) ^ _codeFiscalSet.GetHashCode();
                hashCode = (hashCode * 397) ^ (_name != null
                                                   ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name)
                                                   : 0);
                hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
                hashCode = (hashCode * 397) ^ (_descriptionCorreios != null
                                                   ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_descriptionCorreios)
                                                   : 0);
                hashCode = (hashCode * 397) ^ _descriptionCorreiosSet.GetHashCode();
                hashCode = (hashCode * 397) ^ (_state != null
                                                   ? _state.GetHashCode()
                                                   : 0);
                hashCode = (hashCode * 397) ^ _stateSet.GetHashCode();
                hashCode = (hashCode * 397) ^ (_region != null
                                                   ? _region.GetHashCode()
                                                   : 0);
                hashCode = (hashCode * 397) ^ _regionSet.GetHashCode();
                hashCode = (hashCode * 397) ^ _areaCode;
                hashCode = (hashCode * 397) ^ _areaCodeSet.GetHashCode();
                hashCode = (hashCode * 397) ^ (_latitude != null
                                                   ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_latitude)
                                                   : 0);
                hashCode = (hashCode * 397) ^ _latitudeSet.GetHashCode();
                hashCode = (hashCode * 397) ^ (_longitude != null
                                                   ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_longitude)
                                                   : 0);
                hashCode = (hashCode * 397) ^ _longitudeSet.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(City left, City right) => Equals(left, right);

        /// <summary>
        /// Implements the !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(City left, City right) => !Equals(left, right);

        #endregion

        #region Private Members

        /// <summary>
        /// The code
        /// </summary>
        private int _code;
        /// <summary>
        /// The code set
        /// </summary>
        private bool _codeSet;

        /// <summary>
        /// The code state
        /// </summary>
        private int _codeState;
        /// <summary>
        /// The code state set
        /// </summary>
        private bool _codeStateSet;

        /// <summary>
        /// The code region
        /// </summary>
        private int _codeRegion;
        /// <summary>
        /// The code region set
        /// </summary>
        private bool _codeRegionSet;

        /// <summary>
        /// The code fiscal
        /// </summary>
        private int _codeFiscal;
        /// <summary>
        /// The code fiscal set
        /// </summary>
        private bool _codeFiscalSet;

        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The name set
        /// </summary>
        private bool _nameSet;

        /// <summary>
        /// The description correios
        /// </summary>
        private string _descriptionCorreios;
        /// <summary>
        /// The description correios set
        /// </summary>
        private bool _descriptionCorreiosSet;

        /// <summary>
        /// The state
        /// </summary>
        private State _state;
        /// <summary>
        /// The state set
        /// </summary>
        private bool _stateSet;

        /// <summary>
        /// The region
        /// </summary>
        private Region _region;
        /// <summary>
        /// The region set
        /// </summary>
        private bool _regionSet;

        /// <summary>
        /// The area code
        /// </summary>
        private int _areaCode;
        /// <summary>
        /// The area code set
        /// </summary>
        private bool _areaCodeSet;

        /// <summary>
        /// The latitude
        /// </summary>
        private string _latitude;
        /// <summary>
        /// The latitude set
        /// </summary>
        private bool _latitudeSet;

        /// <summary>
        /// The longitude
        /// </summary>
        private string _longitude;
        /// <summary>
        /// The longitude set
        /// </summary>
        private bool _longitudeSet;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [EntityKey]
        [EntityElement("CODCID")]
        public int Code
        {
            get => _code; set
            {
                _code = value;
                _codeSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the state of the code.
        /// </summary>
        /// <value>The state of the code.</value>
        [EntityElement("UF")]
        public int CodeState
        {
            get => _codeState;
            set
            {
                _codeState = value;
                _codeStateSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the code region.
        /// </summary>
        /// <value>The code region.</value>
        [EntityElement("CODREG")]
        public int CodeRegion
        {
            get => _codeRegion;
            set
            {
                _codeRegion = value;
                _codeRegionSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the code fiscal.
        /// </summary>
        /// <value>The code fiscal.</value>
        [EntityElement("CODMUNFIS")]
        public int CodeFiscal
        {
            get => _codeFiscal; set
            {
                _codeFiscal = value;
                _codeFiscalSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [EntityElement("NOMECID")]
        public string Name
        {
            get => _name; set
            {
                _name = value;
                _nameSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the description correios.
        /// </summary>
        /// <value>The description correios.</value>
        [EntityElement("DESCRICAOCORREIO")]
        public string DescriptionCorreios
        {
            get => _descriptionCorreios; set
            {
                _descriptionCorreios = value;
                _descriptionCorreiosSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the area code
        /// </summary>
        /// <value>The area code.</value>
        [EntityElement("DDD")]
        public int AreaCode
        {
            get => _areaCode;
            set
            {
                _areaCode = value;
                _areaCodeSet = true;
            }
        }

        /// <summary>
        /// Gets or sets latitude
        /// </summary>
        /// <value>The latitude.</value>
        [EntityElement("LATITUDE")]
        public string Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                _latitudeSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the longitude
        /// </summary>
        /// <value>The longitude.</value>
        [EntityElement("LONGITUDE")]
        public string Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;
                _longitudeSet = true;
            }
        }


        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [EntityReference]
        public State State
        {
            get => _state;
            set
            {
                _state = value;
                _stateSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>The region.</value>
        [EntityReference]
        public Region Region
        {
            get => _region;
            set
            {
                _region = value;
                _regionSet = true;
            }
        }

        #endregion

        #region Serializer Helpers

        /// <summary>
        /// Should the serialize code.
        /// </summary>
        /// <returns>Boolean.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]

        public bool ShouldSerializeCode() => _codeSet;

        /// <summary>
        /// Should the state of the serialize code.
        /// </summary>
        /// <returns>Boolean.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeCodeState() => _codeStateSet;

        /// <summary>
        /// Should the serialize code region.
        /// </summary>
        /// <returns>Boolean.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeCodeRegion() => _codeRegionSet;

        /// <summary>
        /// Should the serialize code fiscal.
        /// </summary>
        /// <returns>Boolean.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeCodeFiscal() => _codeFiscalSet;

        /// <summary>
        /// Should the name of the serialize.
        /// </summary>
        /// <returns>Boolean.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeName() => _nameSet;

        /// <summary>
        /// Should the serialize description correios.
        /// </summary>
        /// <returns>Boolean.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeDescriptionCorreios() => _descriptionCorreiosSet;

        /// <summary>
        /// The should serialize area code serialization helper method
        /// </summary>
        /// <returns>Returns <c>true</c> when the field should be serialized, false otherwise</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]

        public bool ShouldSerializeAreaCode() => _areaCodeSet;

        /// <summary>
        /// The should serialize latitude serialization helper method
        /// </summary>
        /// <returns>Returns <c>true</c> when the field should be serialized, false otherwise</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]

        public bool ShouldSerializeLatitude() => _latitudeSet;

        /// <summary>
        /// The should serialize longitude serialization helper method
        /// </summary>
        /// <returns>Returns <c>true</c> when the field should be serialized, false otherwise</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]

        public bool ShouldSerializeLongitude() => _longitudeSet;

        /// <summary>
        /// Should the state of the serialize.
        /// </summary>
        /// <returns>Boolean.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeState() => _stateSet;

        /// <summary>
        /// Should the serialize region.
        /// </summary>
        /// <returns>Boolean.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeRegion() => _regionSet;

        #endregion
    }
}
