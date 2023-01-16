// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Field.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Service
{
    using CrispyWaffle.Extensions;
    using System.ComponentModel;
    using System.Xml.Serialization;

    /// <summary>
    /// Class Field. This class cannot be inherited.
    /// </summary>
    public sealed class Field
    {
        #region Private Members

        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The name set
        /// </summary>
        private bool _nameSet;

        /// <summary>
        /// The list
        /// </summary>
        private string _list;
        /// <summary>
        /// The list set
        /// </summary>
        private bool _listSet;

        /// <summary>
        /// The except
        /// </summary>
        private bool _except;
        /// <summary>
        /// The except set
        /// </summary>
        private bool _exceptSet;

        /// <summary>
        /// The value
        /// </summary>
        private string _value;
        /// <summary>
        /// The value set
        /// </summary>
        private bool _valueSet;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [XmlAttribute("name")]
        public string Name
        {
            get => _name; set
            {
                _name = value;
                _nameSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the list.
        /// </summary>
        /// <value>The list.</value>
        [XmlAttribute("list")]
        public string List
        {
            get => _list; set
            {
                _list = value;
                _listSet = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Field"/> is except.
        /// </summary>
        /// <value><c>true</c> if except; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool Except
        {
            get => _except; set
            {
                _except = value;
                _exceptSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the except internal.
        /// </summary>
        /// <value>The except internal.</value>
        [XmlAttribute("except")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ExceptInternal
        {
            get => _except.ToString(); set
            {
                _except = value.ToBoolean(@"S|N");
                _exceptSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [XmlText]
        public string Value
        {
            get => _value; set
            {
                _value = value;
                _valueSet = true;
            }
        }

        #endregion

        #region Serializer Helpers

        /// <summary>
        /// Shoulds the name of the serialize.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeName() => _nameSet;

        /// <summary>
        /// Shoulds the serialize list.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeList() => _listSet;

        /// <summary>
        /// Shoulds the serialize except internal.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeExceptInternal() => _exceptSet;

        /// <summary>
        /// Shoulds the serialize value.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeValue() => _valueSet;

        #endregion

    }
}
