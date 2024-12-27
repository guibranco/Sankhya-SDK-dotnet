using System;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Serializer]
[Entity("ImagemAlternativaProduto")]
public class ProductAlternativeImage : IEntity, IEquatable<ProductAlternativeImage>
{
    public bool Equals(ProductAlternativeImage other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _code == other._code
                && _codeSet == other._codeSet
                && _codeProduct == other._codeProduct
                && _codeProductSet == other._codeProductSet
                && string.Equals(_fileName, other._fileName, StringComparison.OrdinalIgnoreCase)
                && _fileNameSet == other._fileNameSet
                && _codeUser == other._codeUser
                && _codeUserSet == other._codeUserSet
                && _dateChanged.Equals(other._dateChanged)
                && _dateChangedSet == other._dateChangedSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj)
            || (obj is ProductAlternativeImage image && Equals(image));
    }

    [SuppressMessage(
        "ReSharper",
        "NonReadonlyMemberInGetHashCode",
        Justification = "Used to compute hash internally"
    )]
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

    public static bool operator ==(ProductAlternativeImage left, ProductAlternativeImage right) =>
        Equals(left, right);

    public static bool operator !=(ProductAlternativeImage left, ProductAlternativeImage right) =>
        !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private int _codeProduct;

    private bool _codeProductSet;

    private string _fileName;

    private bool _fileNameSet;

    private int _codeUser;

    private bool _codeUserSet;

    private DateTime _dateChanged;

    private bool _dateChangedSet;

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

    public bool ShouldSerializeCode() => _codeSet;

    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    public bool ShouldSerializeFileName() => _fileNameSet;

    public bool ShouldSerializeCodeUser() => _codeUserSet;

    public bool ShouldSerializeDateChanged() => _dateChangedSet;
}
