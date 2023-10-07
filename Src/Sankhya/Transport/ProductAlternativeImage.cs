using System;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;

namespace Sankhya.Transport;

/// <summary>
/// Class ProductAlternativeImage. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Serializer]
[Entity("ImagemAlternativaProduto")]
public class ProductAlternativeImage : IEntity, IEquatable<ProductAlternativeImage>
{
    #region Equality members

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    public bool Equals(ProductAlternativeImage other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || _code == other._code
                && _codeSet == other._codeSet
                && _codeProduct == other._codeProduct
                && _codeProductSet == other._codeProductSet
                && string.Equals(
                    _fileName,
                    other._fileName,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _fileNameSet == other._fileNameSet
                && _codeUser == other._codeUser
                && _codeUserSet == other._codeUserSet
                && _dateChanged.Equals(other._dateChanged)
                && _dateChangedSet == other._dateChangedSet;
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

        return ReferenceEquals(this, obj) || obj is ProductAlternativeImage image && Equals(image);
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
            hashCode = (hashCode * 397) ^ _codeProduct;
            hashCode = (hashCode * 397) ^ _codeProductSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _fileName != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_fileName)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _fileNameSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeUser;
            hashCode = (hashCode * 397) ^ _codeUserSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChanged.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChangedSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(ProductAlternativeImage left, ProductAlternativeImage right) =>
        Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(ProductAlternativeImage left, ProductAlternativeImage right) =>
        !Equals(left, right);

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
    /// The code product
    /// </summary>
    private int _codeProduct;

    /// <summary>
    /// The code product set
    /// </summary>
    private bool _codeProductSet;

    /// <summary>
    /// The file name
    /// </summary>
    private string _fileName;

    /// <summary>
    /// The file name set
    /// </summary>
    private bool _fileNameSet;

    /// <summary>
    /// The code user
    /// </summary>
    private int _codeUser;

    /// <summary>
    /// The code user set
    /// </summary>
    private bool _codeUserSet;

    /// <summary>
    /// The date changed
    /// </summary>
    private DateTime _dateChanged;

    /// <summary>
    /// The date changed set
    /// </summary>
    private bool _dateChangedSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
    [EntityElement("NUIMG")]
    [EntityKey]
    public int Code
    {
        get => _code;
        set
        {
            _code = value;
            _codeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code product.
    /// </summary>
    /// <value>The code product.</value>
    [EntityElement("CODPROD")]
    [EntityKey]
    public int CodeProduct
    {
        get => _codeProduct;
        set
        {
            _codeProduct = value;
            _codeProductSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    /// <value>The name of the file.</value>
    [EntityElement("NOMEARQ")]
    public string FileName
    {
        get => _fileName;
        set
        {
            _fileName = value;
            _fileNameSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code user.
    /// </summary>
    /// <value>The code user.</value>
    [EntityElement("CODUSU")]
    [EntityKey]
    public int CodeUser
    {
        get => _codeUser;
        set
        {
            _codeUser = value;
            _codeUserSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date changed.
    /// </summary>
    /// <value>The date changed.</value>
    [EntityElement("DHALTER")]
    public DateTime DateChanged
    {
        get => _dateChanged;
        set
        {
            _dateChanged = value;
            _dateChangedSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize code.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCode() => _codeSet;

    /// <summary>
    /// Should the serialize code product.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    /// <summary>
    /// Should the name of the serialize file.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeFileName() => _fileNameSet;

    /// <summary>
    /// Should the serialize code user.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeUser() => _codeUserSet;

    /// <summary>
    /// Should the serialize date changed.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    #endregion
}
