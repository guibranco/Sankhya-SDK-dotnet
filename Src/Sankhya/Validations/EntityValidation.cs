// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="EntityValidation.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Validations
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class EntityValidation.
    /// </summary>
    public static class EntityValidation
    {
        /// <summary>
        /// The reference fields first level pattern
        /// </summary>
        public static readonly Regex ReferenceFieldsFirstLevelPattern = new(@"^(?!AD)(?<entity>[A-Z].+)_(?<field>.+)$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The reference fields second level pattern
        /// </summary>
        public static readonly Regex ReferenceFieldsSecondLevelPattern = new(@"^(?!AD)(?<parentEntity>[A-Z].+)_(?<entity>[A-Z].+)_(?<field>.+)$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The property value error pattern
        /// </summary>
        public static readonly Regex PropertyValueErrorPattern = new(@"erro ao obter valor da propriedade '(?<propertyName>(?:(?:[A-Z]+)(?:-(?:>|&gt;))?)+)", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The property name error pattern
        /// </summary>
        public static readonly Regex PropertyNameErrorPattern = new(@"Descritor do campo '(?<propertyName>[A-Z]+)' inválido", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The property name association error pattern
        /// </summary>
        public static readonly Regex PropertyNameAssociationErrorPattern = new(@"O identificador de várias partes ""(?<entity>[A-Z]+)\.(?<propertyName>[A-Z]+)"" não pôde ser associado", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The property not found pattern
        /// </summary>
        public static readonly Regex PropertyNotFoundPattern = new(@"Campo não existe: (?<entity>[A-Z]+)->(?<propertyName>[A-Z]+)", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The property name invalid error pattern
        /// </summary>
        public static readonly Regex PropertyNameInvalidErrorPattern = new(@"Nome de coluna '(?<propertyName>.+?)' inválido", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The property width error pattern
        /// </summary>
        public static readonly Regex PropertyWidthErrorPattern = new(@"^Propriedade '(?<propertyName>.+?)' com largura acima do limite: \((?<currentWidth>\d+) > (?<widthAllowed>\d+)\)$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The property foreign key restriction pattern
        /// </summary>
        public static readonly Regex PropertyForeignKeyRestrictionPattern = new("conflitou com a restrição do FOREIGN KEY \"(?<foreignKey>.+?)\". O conflito ocorreu no bando de dados \"(?<dataBase>.+?)\", tabela \"(?<table>.+?)\", column '(?<column>.+?)'", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The duplicated document pattern
        /// </summary>
        public static readonly Regex DuplicatedDocumentPattern = new(@"CNPJ/CPF já existente para o parceiro: '(?<name>.+?)$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The business rule restriction pattern
        /// </summary>
        public static readonly Regex BusinessRuleRestrictionPattern = new("^A regra \\\"(?<ruleName>.+?)\\\" não permitiu a operação\\.(\r?\n)*(?<errorMessage>.+?)$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The transaction log full pattern
        /// </summary>
        public static readonly Regex FullTransactionLogsPattern = new(@"^ Log de transações do banco de dados '(?<database>.+?)' cheio", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The missing relation pattern
        /// </summary>
        public static readonly Regex MissingRelationPattern = new(@"^Relacionamento: '(?<missingRelation>.+?)' não encontrado em: '(?<entity>.+?)'", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// The missing attribute pattern
        /// </summary>
        public static readonly Regex MissingAttributePattern = new(@"^É necessário informar o atributo '(?<attributeName>.+?)'$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

    }
}
