using Sankhya.Validations;
using Xunit;

namespace Sankhya.Tests.Validations;

public class EntityValidationTests
{
    [Theory]
    [InlineData("Entity_Field", "Entity", "Field")]
    [InlineData("ENTITY_FIELD", "ENTITY", "FIELD")]
    public void ReferenceFieldsFirstLevelPattern_ShouldMatch(
        string input,
        string expectedEntity,
        string expectedField
    )
    {
        // Act
        var match = EntityValidation.ReferenceFieldsFirstLevelPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedEntity, match.Groups["entity"].Value);
        Assert.Equal(expectedField, match.Groups["field"].Value);
    }

    [Theory]
    [InlineData("ParentEntity_Entity_Field", "ParentEntity", "Entity", "Field")]
    [InlineData("PARENTENTITY_ENTITY_FIELD", "PARENTENTITY", "ENTITY", "FIELD")]
    public void ReferenceFieldsSecondLevelPattern_ShouldMatch(
        string input,
        string expectedParentEntity,
        string expectedEntity,
        string expectedField
    )
    {
        // Act
        var match = EntityValidation.ReferenceFieldsSecondLevelPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedParentEntity, match.Groups["parentEntity"].Value);
        Assert.Equal(expectedEntity, match.Groups["entity"].Value);
        Assert.Equal(expectedField, match.Groups["field"].Value);
    }

    [Theory]
    [InlineData("erro ao obter valor da propriedade 'PROPERTY->NAME'", "PROPERTY->NAME")]
    public void PropertyValueErrorPattern_ShouldMatch(string input, string expectedPropertyName)
    {
        // Act
        var match = EntityValidation.PropertyValueErrorPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedPropertyName, match.Groups["propertyName"].Value);
    }

    [Theory]
    [InlineData("Descritor do campo 'PROPERTY' inválido", "PROPERTY")]
    public void PropertyNameErrorPattern_ShouldMatch(string input, string expectedPropertyName)
    {
        // Act
        var match = EntityValidation.PropertyNameErrorPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedPropertyName, match.Groups["propertyName"].Value);
    }

    [Theory]
    [InlineData(
        "O identificador de várias partes \"ENTITY.PROPERTY\" não pôde ser associado",
        "ENTITY",
        "PROPERTY"
    )]
    public void PropertyNameAssociationErrorPattern_ShouldMatch(
        string input,
        string expectedEntity,
        string expectedPropertyName
    )
    {
        // Act
        var match = EntityValidation.PropertyNameAssociationErrorPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedEntity, match.Groups["entity"].Value);
        Assert.Equal(expectedPropertyName, match.Groups["propertyName"].Value);
    }

    [Theory]
    [InlineData("Campo não existe: ENTITY->PROPERTY", "ENTITY", "PROPERTY")]
    public void PropertyNotFoundPattern_ShouldMatch(
        string input,
        string expectedEntity,
        string expectedPropertyName
    )
    {
        // Act
        var match = EntityValidation.PropertyNotFoundPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedEntity, match.Groups["entity"].Value);
        Assert.Equal(expectedPropertyName, match.Groups["propertyName"].Value);
    }

    [Theory]
    [InlineData("Nome de coluna 'COLUMN-NAME' inválido", "COLUMN-NAME")]
    public void PropertyNameInvalidErrorPattern_ShouldMatch(
        string input,
        string expectedPropertyName
    )
    {
        // Act
        var match = EntityValidation.PropertyNameInvalidErrorPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedPropertyName, match.Groups["propertyName"].Value);
    }

    [Theory]
    [InlineData(
        "Propriedade 'PROPERTY-NAME' com largura acima do limite: (150 > 100)",
        "PROPERTY-NAME",
        150,
        100
    )]
    public void PropertyWidthErrorPattern_ShouldMatch(
        string input,
        string expectedPropertyName,
        int expectedCurrentWidth,
        int expectedWidthAllowed
    )
    {
        // Act
        var match = EntityValidation.PropertyWidthErrorPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedPropertyName, match.Groups["propertyName"].Value);
        Assert.Equal(expectedCurrentWidth.ToString(), match.Groups["currentWidth"].Value);
        Assert.Equal(expectedWidthAllowed.ToString(), match.Groups["widthAllowed"].Value);
    }

    [Theory]
    [InlineData(
        "conflitou com a restrição do FOREIGN KEY \"FK_NAME\". O conflito ocorreu no bando de dados \"DB_NAME\", tabela \"TABLE_NAME\", column 'COLUMN_NAME'",
        "FK_NAME",
        "DB_NAME",
        "TABLE_NAME",
        "COLUMN_NAME"
    )]
    public void PropertyForeignKeyRestrictionPattern_ShouldMatch(
        string input,
        string expectedForeignKey,
        string expectedDatabase,
        string expectedTable,
        string expectedColumn
    )
    {
        // Act
        var match = EntityValidation.PropertyForeignKeyRestrictionPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedForeignKey, match.Groups["foreignKey"].Value);
        Assert.Equal(expectedDatabase, match.Groups["dataBase"].Value);
        Assert.Equal(expectedTable, match.Groups["table"].Value);
        Assert.Equal(expectedColumn, match.Groups["column"].Value);
    }

    [Theory]
    [InlineData("CNPJ/CPF já existente para o parceiro: 'PARTNER->NAME'", "PARTNER->NAME")]
    public void DuplicatedDocumentPattern_ShouldMatch(string input, string expectedName)
    {
        // Act
        var match = EntityValidation.DuplicatedDocumentPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedName, match.Groups["name"].Value);
    }

    [Theory]
    [InlineData(
        "A regra \"RULE-NAME\" não permitiu a operação.\nError message",
        "RULE-NAME",
        "Error message"
    )]
    public void BusinessRuleRestrictionPattern_ShouldMatch(
        string input,
        string expectedRuleName,
        string expectedErrorMessage
    )
    {
        // Act
        var match = EntityValidation.BusinessRuleRestrictionPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedRuleName, match.Groups["ruleName"].Value);
        Assert.Equal(expectedErrorMessage, match.Groups["errorMessage"].Value);
    }

    [Theory]
    [InlineData(" Log de transações do banco de dados 'DB_NAME' cheio", "DB_NAME")]
    public void FullTransactionLogsPattern_ShouldMatch(string input, string expectedDatabase)
    {
        // Act
        var match = EntityValidation.FullTransactionLogsPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedDatabase, match.Groups["database"].Value);
    }

    [Theory]
    [InlineData("Relacionamento: 'RELATION' não encontrado em: 'ENTITY'", "RELATION", "ENTITY")]
    public void MissingRelationPattern_ShouldMatch(
        string input,
        string expectedMissingRelation,
        string expectedEntity
    )
    {
        // Act
        var match = EntityValidation.MissingRelationPattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedMissingRelation, match.Groups["missingRelation"].Value);
        Assert.Equal(expectedEntity, match.Groups["entity"].Value);
    }

    [Theory]
    [InlineData("É necessário informar o atributo 'ATTRIBUTE-NAME'", "ATTRIBUTE-NAME")]
    public void MissingAttributePattern_ShouldMatch(string input, string expectedAttributeName)
    {
        // Act
        var match = EntityValidation.MissingAttributePattern.Match(input);

        // Assert
        Assert.True(match.Success);
        Assert.Equal(expectedAttributeName, match.Groups["attributeName"].Value);
    }
}
