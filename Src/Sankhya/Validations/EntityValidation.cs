using System;
using System.Text.RegularExpressions;

namespace Sankhya.Validations;

/// <summary>
/// Provides validation patterns for entity-related operations.
/// </summary>
public static class EntityValidation
{
    /// <summary>
    /// Pattern to match first-level reference fields.
    /// </summary>
    public static readonly Regex ReferenceFieldsFirstLevelPattern = new(
        @"^(?!AD)(?<entity>[A-Z].+)_(?<field>.+)$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match second-level reference fields.
    /// </summary>
    public static readonly Regex ReferenceFieldsSecondLevelPattern = new(
        @"^(?!AD)(?<parentEntity>[A-Z].+)_(?<entity>[A-Z].+)_(?<field>.+)$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match property value errors.
    /// </summary>
    public static readonly Regex PropertyValueErrorPattern = new(
        @"erro ao obter valor da propriedade '(?<propertyName>(?:(?:[A-Z]+)(?:-(?:>|&gt;))?)+)",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match property name errors.
    /// </summary>
    public static readonly Regex PropertyNameErrorPattern = new(
        @"Descritor do campo '(?<propertyName>[A-Z]+)' inválido",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match property name association errors.
    /// </summary>
    public static readonly Regex PropertyNameAssociationErrorPattern = new(
        @"O identificador de várias partes ""(?<entity>[A-Z]+)\.(?<propertyName>[A-Z]+)"" não pôde ser associado",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match property not found errors.
    /// </summary>
    public static readonly Regex PropertyNotFoundPattern = new(
        @"Campo não existe: (?<entity>[A-Z]+)->(?<propertyName>[A-Z]+)",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match invalid property name errors.
    /// </summary>
    public static readonly Regex PropertyNameInvalidErrorPattern = new(
        @"Nome de coluna '(?<propertyName>.+?)' inválido",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match property width errors.
    /// </summary>
    public static readonly Regex PropertyWidthErrorPattern = new(
        @"^Propriedade '(?<propertyName>.+?)' com largura acima do limite: \((?<currentWidth>\d+) > (?<widthAllowed>\d+)\)$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match foreign key restriction errors.
    /// </summary>
    public static readonly Regex PropertyForeignKeyRestrictionPattern = new(
        "conflitou com a restrição do FOREIGN KEY \"(?<foreignKey>.+?)\". O conflito ocorreu no bando de dados \"(?<dataBase>.+?)\", tabela \"(?<table>.+?)\", column '(?<column>.+?)'",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match duplicated document errors.
    /// </summary>
    public static readonly Regex DuplicatedDocumentPattern = new(
        @"CNPJ/CPF já existente para o parceiro: '(?<name>.+?)'$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match business rule restriction errors.
    /// </summary>
    public static readonly Regex BusinessRuleRestrictionPattern = new(
        "^A regra \\\"(?<ruleName>.+?)\\\" não permitiu a operação\\.(\r?\n)*(?<errorMessage>.+?)$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match full transaction logs errors.
    /// </summary>
    public static readonly Regex FullTransactionLogsPattern = new(
        @"^ Log de transações do banco de dados '(?<database>.+?)' cheio",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match missing relation errors.
    /// </summary>
    public static readonly Regex MissingRelationPattern = new(
        @"^Relacionamento: '(?<missingRelation>.+?)' não encontrado em: '(?<entity>.+?)'",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );

    /// <summary>
    /// Pattern to match missing attribute errors.
    /// </summary>
    public static readonly Regex MissingAttributePattern = new(
        @"^É necessário informar o atributo '(?<attributeName>.+?)'$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
        TimeSpan.FromMilliseconds(100)
    );
}
