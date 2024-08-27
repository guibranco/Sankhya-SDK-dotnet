using System.Text.RegularExpressions;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Service;
using Sankhya.Validations;

namespace Sankhya.Helpers;

/// <summary>
/// The status message helper class.
/// This class handle the status message and throw the appropriated exception.
/// </summary>
internal static class StatusMessageHelper
{
    /// <summary>
    /// The common messages.
    /// </summary>
    private static readonly Dictionary<
        string,
        Func<string, ServiceName, ServiceRequest, ServiceResponse, Exception>
    > CommonMessages =
        new()
        {
            {
                @"Delimitador ''' desbalanceado",
                (_, _, request, _) => new ServiceRequestUnbalancedDelimiterException(request)
            },
            {
                @"situação de concorrência",
                (_, _, request, response) =>
                    new ServiceRequestCompetitionException(request, response)
            },
            {
                @"log de acessos",
                (_, _, request, response) =>
                    new ServiceRequestCompetitionException(request, response)
            },
            {
                @"violação da restrição primary key 'PK_TSIRLG'",
                (_, _, request, response) =>
                    new ServiceRequestCompetitionException(request, response)
            },
            {
                @"deadlock",
                (message, _, request, response) =>
                    new ServiceRequestDeadlockException(message, request, response)
            },
            {
                @"não autorizado",
                (_, _, _, _) => new ServiceRequestInvalidAuthorizationException()
            },
            {
                @"tempo limite da consulta",
                (_, service, request, _) => new ServiceRequestTimeoutException(service, request)
            },
            {
                @"resultset object is closed",
                (_, service, request, response) =>
                    new ServiceRequestUnavailableException(service, request, response)
            },
            {
                @"objeto de acesso a dados",
                (_, service, request, response) =>
                    new ServiceRequestUnavailableException(service, request, response)
            },
            {
                @"the connection object is closed",
                (_, service, request, response) =>
                    new ServiceRequestUnavailableException(service, request, response)
            },
            {
                @"I/O error",
                (_, service, request, response) =>
                    new ServiceRequestUnavailableException(service, request, response)
            },
            {
                @"TDS protocol error",
                (_, service, request, response) =>
                    new ServiceRequestUnavailableException(service, request, response)
            },
            {
                @"STP_SET_SESSION",
                (_, service, request, response) =>
                    new ServiceRequestUnavailableException(service, request, response)
            },
            {
                @"java.lang.NullPointerException",
                (_, service, request, response) =>
                    new ServiceRequestUnavailableException(service, request, response)
            },
            {
                @"erro interno (NPE)",
                (_, service, request, response) =>
                    new ServiceRequestExternalException(service, request, response)
            },
            {
                @"Expressão inválida",
                (_, _, request, response) =>
                    new ServiceRequestInvalidExpressionException(request, response)
            },
            {
                @"Usuário/Senha inválido",
                (_, _, _, _) => new ServiceRequestInvalidCredentialsException()
            },
            {
                @"Usuário expirou",
                (_, _, _, _) => new ServiceRequestExpiredAuthenticationException()
            },
            {
                @"A consulta foi cancelada",
                (message, _, request, _) =>
                    new ServiceRequestCanceledQueryException(message, request)
            },
            {
                @"Arquivo/Diretório não foi encontrado no repositório",
                (_, _, request, _) => new ServiceRequestFileNotFoundException(request)
            },
            {
                @"O sistema não pode encontrar o arquivo especificado",
                (_, _, request, _) => new ServiceRequestPaginationException(request)
            },
            {
                @"Na ausência da Inscrição Estadual, apenas a Classificação ICMS",
                (_, _, request, _) =>
                    new ServiceRequestPartnerFiscalClassificationException(request)
            },
            {
                @"Insira a palavra ISENTO para este tipo de inscrição estadual",
                (_, _, request, _) => new ServiceRequestPartnerStateInscriptionException(request)
            },
            {
                @"Tamanho do CNPJ/CPF inválido para pessoa Física!",
                (_, _, request, _) =>
                    new ServiceRequestPartnerInvalidDocumentLengthException(request)
            },
            {
                @"A subconsulta retornou mais de 1 valor",
                (_, _, request, _) => new ServiceRequestInvalidSubQueryException(request)
            },
        };

    /// <summary>
    /// Processes the status message.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="request">The request.</param>
    /// <param name="response">The response.</param>
    /// <exception cref="ServiceRequestPropertyValueException">Invalid property value.</exception>
    /// <exception cref="ServiceRequestPropertyNameException">Invalid property name.</exception>
    /// <exception cref="ServiceRequestInvalidRelationException">Invalid relation.</exception>
    /// <exception cref="ServiceRequestForeignKeyException">Invalid foreign key.</exception>
    /// <exception cref="ServiceRequestDuplicatedDocumentException">Duplicated document found.</exception>
    /// <exception cref="ServiceRequestBusinessRuleRestrictionException">Business rule restriction.</exception>
    /// <exception cref="ServiceRequestFullTransactionLogsException">Transaction log is full.</exception>
    /// <exception cref="ServiceRequestAttributeException">Invalid request attribute.</exception>
    /// <exception cref="ServiceRequestUnexpectedResultException">Unexpected result.</exception>
    /// <exception cref="ServiceRequestPropertyWidthException">Invalid property width.</exception>
    public static void ProcessStatusMessage(
        ServiceName service,
        ServiceRequest request,
        ServiceResponse response
    )
    {
        Match match;
        var statusMessage = response.StatusMessage.Value;

        var kvp = CommonMessages.FirstOrDefault(item =>
            statusMessage.IndexOf(item.Key, StringComparison.OrdinalIgnoreCase) != -1
        );

        if (kvp.Value != null)
        {
            throw kvp.Value(statusMessage, service, request, response);
        }

        if (EntityValidation.PropertyValueErrorPattern.IsMatch(statusMessage))
        {
            throw new ServiceRequestPropertyValueException(
                EntityValidation
                    .PropertyValueErrorPattern.Match(statusMessage)
                    .Groups[@"propertyName"]
                    .Value,
                request
            );
        }

        if (EntityValidation.PropertyNameErrorPattern.IsMatch(statusMessage))
        {
            throw new ServiceRequestPropertyNameException(
                EntityValidation
                    .PropertyNameErrorPattern.Match(statusMessage)
                    .Groups[@"propertyName"]
                    .Value,
                request
            );
        }

        if (EntityValidation.PropertyNameInvalidErrorPattern.IsMatch(statusMessage))
        {
            throw new ServiceRequestPropertyNameException(
                EntityValidation
                    .PropertyNameInvalidErrorPattern.Match(statusMessage)
                    .Groups[@"propertyName"]
                    .Value,
                request
            );
        }

        if (EntityValidation.PropertyNameAssociationErrorPattern.IsMatch(statusMessage))
        {
            match = EntityValidation.PropertyNameAssociationErrorPattern.Match(statusMessage);
            throw new ServiceRequestPropertyNameException(
                match.Groups[@"propertyName"].Value,
                match.Groups[@"entity"].Value,
                request
            );
        }

        if (EntityValidation.PropertyNotFoundPattern.IsMatch(statusMessage))
        {
            match = EntityValidation.PropertyNotFoundPattern.Match(statusMessage);
            throw new ServiceRequestPropertyNameException(
                match.Groups[@"propertyName"].Value,
                match.Groups[@"entity"].Value,
                request
            );
        }

        if (EntityValidation.MissingRelationPattern.IsMatch(statusMessage))
        {
            match = EntityValidation.MissingRelationPattern.Match(statusMessage);
            throw new ServiceRequestInvalidRelationException(
                match.Groups[@"missingRelation"].Value,
                match.Groups[@"entity"].Value,
                request
            );
        }

        if (EntityValidation.PropertyForeignKeyRestrictionPattern.IsMatch(statusMessage))
        {
            match = EntityValidation.PropertyForeignKeyRestrictionPattern.Match(statusMessage);
            throw new ServiceRequestForeignKeyException(
                match.Groups[@"table"].Value,
                match.Groups[@"column"].Value,
                request,
                response
            );
        }

        if (EntityValidation.DuplicatedDocumentPattern.IsMatch(statusMessage))
        {
            match = EntityValidation.DuplicatedDocumentPattern.Match(statusMessage);
            throw new ServiceRequestDuplicatedDocumentException(
                match.Groups[@"name"].Value,
                request,
                response
            );
        }

        if (EntityValidation.BusinessRuleRestrictionPattern.IsMatch(statusMessage))
        {
            match = EntityValidation.BusinessRuleRestrictionPattern.Match(statusMessage);
            throw new ServiceRequestBusinessRuleRestrictionException(
                match.Groups[@"ruleName"].Value,
                match.Groups[@"errorMessage"].Value,
                request,
                response
            );
        }

        if (EntityValidation.FullTransactionLogsPattern.IsMatch(statusMessage))
        {
            match = EntityValidation.FullTransactionLogsPattern.Match(statusMessage);
            throw new ServiceRequestFullTransactionLogsException(
                match.Groups[@"database"].Value,
                request,
                response
            );
        }

        if (EntityValidation.MissingAttributePattern.IsMatch(statusMessage))
        {
            match = EntityValidation.MissingAttributePattern.Match(statusMessage);
            throw new ServiceRequestAttributeException(
                match.Groups[@"attributeName"].Value,
                service,
                request
            );
        }

        if (!EntityValidation.PropertyWidthErrorPattern.IsMatch(statusMessage))
        {
            throw new ServiceRequestUnexpectedResultException(statusMessage, request, response);
        }

        match = EntityValidation.PropertyWidthErrorPattern.Match(statusMessage);
        throw new ServiceRequestPropertyWidthException(
            match.Groups[@"propertyName"].Value,
            request,
            match.Groups[@"widthAllowed"].Value.ToInt32(),
            match.Groups[@"currentWidth"].Value.ToInt32()
        );
    }
}
