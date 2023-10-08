﻿using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using CrispyWaffle.Log;
using CrispyWaffle.Serialization;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Helpers;

namespace Sankhya.Service;

/// <summary>
/// A service response.
/// </summary>
/// <seealso cref="IXmlSerializable" />
[Serializer]
[XmlRoot(ElementName = "serviceResponse")]
//TODO convert XML fields names to constants
public sealed class ServiceResponse : IXmlSerializable
{
    /// <summary>
    /// The service
    /// </summary>
    private ServiceName _service;

    /// <summary>
    /// The service set
    /// </summary>
    private bool _serviceSet;

    /// <summary>
    /// The pending printing
    /// </summary>
    private bool _pendingPrinting;

    /// <summary>
    /// The pending printing set
    /// </summary>
    private bool _pendingPrintingSet;

    /// <summary>
    /// The transaction identifier
    /// </summary>
    private Guid _transactionId;

    /// <summary>
    /// The transaction identifier set
    /// </summary>
    private bool _transactionIdSet;

    /// <summary>
    /// The status
    /// </summary>
    private ServiceResponseStatus _status;

    /// <summary>
    /// The status set
    /// </summary>
    private bool _statusSet;

    /// <summary>
    /// The error code
    /// </summary>
    private int _errorCode;

    /// <summary>
    /// The error code set
    /// </summary>
    private bool _errorCodeSet;

    /// <summary>
    /// The error level
    /// </summary>
    private int _errorLevel;

    /// <summary>
    /// The error level set
    /// </summary>
    private bool _errorLevelSet;

    /// <summary>
    /// The status message
    /// </summary>
    private StatusMessage _statusMessage;

    /// <summary>
    /// The status message set
    /// </summary>
    private bool _statusMessageSet;

    /// <summary>
    /// The response body
    /// </summary>
    private ResponseBody _responseBody;

    /// <summary>
    /// The response body set
    /// </summary>
    private bool _responseBodySet;

    /// <summary>
    /// Gets or sets the service.
    /// </summary>
    /// <value>The service.</value>
    [XmlIgnore]
    public ServiceName Service
    {
        get => _service;
        set
        {
            _service = value;
            _serviceSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the service internal.
    /// </summary>
    /// <value>The service internal.</value>
    [XmlAttribute("serviceName")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ServiceInternal
    {
        get => _service.GetInternalValue();
        set
        {
            _service = EnumExtensions.GetEnumByInternalValueAttribute<ServiceName>(value);
            _serviceSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the pending printing.
    /// </summary>
    /// <value>The pending printing.</value>
    [XmlIgnore]
    public bool PendingPrinting
    {
        get => _pendingPrinting;
        set
        {
            _pendingPrinting = value;
            _pendingPrintingSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the pending printing internal.
    /// </summary>
    /// <value>The pending printing internal.</value>
    [XmlAttribute("pendingPrinting")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string PendingPrintingInternal
    {
        get => _pendingPrinting.ToString().ToLower();
        set
        {
            _pendingPrinting = value.ToBoolean(@"true|false");
            _pendingPrintingSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the transaction identifier.
    /// </summary>
    /// <value>The transaction identifier.</value>
    [XmlAttribute("transactionId")]
    public Guid TransactionId
    {
        get => _transactionId;
        set
        {
            _transactionId = value;
            _transactionIdSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the status.
    /// </summary>
    /// <value>The status.</value>
    [XmlAttribute("status")]
    public ServiceResponseStatus Status
    {
        get => _status;
        set
        {
            _status = value;
            _statusSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    /// <value>The error code.</value>
    [XmlAttribute("errorCode")]
    public int ErrorCode
    {
        get => _errorCode;
        set
        {
            _errorCode = value;
            _errorCodeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the error level.
    /// </summary>
    /// <value>The error level.</value>
    [XmlAttribute("errorLevel")]
    public int ErrorLevel
    {
        get => _errorLevel;
        set
        {
            _errorLevel = value;
            _errorLevelSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the status message.
    /// </summary>
    /// <value>The status message.</value>
    [XmlElement("statusMessage")]
    public StatusMessage StatusMessage
    {
        get => _statusMessage;
        set
        {
            _statusMessage = value;
            _statusMessageSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the response body.
    /// </summary>
    /// <value>The response body.</value>
    [XmlElement(ElementName = "responseBody")]
    public ResponseBody ResponseBody
    {
        get => _responseBody;
        set
        {
            _responseBody = value;
            _responseBodySet = true;
        }
    }

    /// <summary>
    /// Should the serialize service internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeServiceInternal() => _serviceSet;

    /// <summary>
    /// Should the serialize pending printing internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePendingPrintingInternal() => _pendingPrintingSet;

    /// <summary>
    /// Should the serialize transaction identifier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTransactionId() => _transactionIdSet;

    /// <summary>
    /// Should the serialize status.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStatus() => _statusSet;

    /// <summary>
    /// Should the serialize error code.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeErrorCode() => _errorCodeSet;

    /// <summary>
    /// Should the serialize error level.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeErrorLevel() => _errorLevelSet;

    /// <summary>
    /// Should the serialize status message.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStatusMessage() => _statusMessageSet;

    /// <summary>
    /// Should the serialize response body.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeResponseBody() => _responseBodySet;

    /// <summary>
    /// Gets the entities.
    /// </summary>
    /// <value>The entities.</value>
    public EntityDynamicSerialization[] Entities =>
        ResponseBody.CrudServiceEntities != null
            ? ResponseBody.CrudServiceEntities.Entities as EntityDynamicSerialization[]
            : ResponseBody.CrudServiceProviderEntities?.Entities as EntityDynamicSerialization[];

    /// <summary>
    /// Parse entity.
    /// </summary>
    /// <param name="node">The node.</param>
    /// <returns>A DynamicSerialization.</returns>
    private static EntityDynamicSerialization ReadDynamic(XmlReader node)
    {
        var ds = new EntityDynamicSerialization();

        node.Read();
        while (true)
        {
            var elementName = node.LocalName;
            if (elementName == @"_rmd")
            {
                node.ReadOuterXml();
                continue;
            }

            if (
                node.NodeType.Equals(XmlNodeType.EndElement)
                && (elementName == @"entidade" || elementName == @"entity" || elementName == @"pk")
            )
            {
                node.Read();
                break;
            }

            if (node.NodeType.Equals(XmlNodeType.Element) && node.IsEmptyElement)
            {
                ds.SetMember(node.Name, null);
                node.Read();
                continue;
            }

            if (node.NodeType.Equals(XmlNodeType.Element))
            {
                ds.SetMember(elementName, node.ReadElementContentAsString());
            }
        }

        return ds;
    }

    /// <summary>
    /// Writes a dynamic.
    /// </summary>
    /// <param name="writer">The <see cref="System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
    /// <param name="dynamic">The dynamic.</param>
    private static void WriteDynamic(XmlWriter writer, EntityDynamicSerialization dynamic)
    {
        foreach (var kvp in dynamic.GetDictionary())
        {
            writer.WriteStartElement(kvp.Key);

            var itemXml = new StringBuilder();
            using (var itemWriter = XmlWriter.Create(itemXml))
            {
                var itemType = kvp.Value?.GetType() ?? typeof(string);
                var xmlSer = new XmlSerializer(itemType);
                xmlSer.Serialize(itemWriter, kvp.Value ?? string.Empty);
                var doc = new XmlDocument();
                doc.LoadXml(itemXml.ToString());
                if (doc.DocumentElement != null)
                {
                    writer.WriteRaw(doc.DocumentElement.OuterXml);
                }
            }

            writer.WriteEndElement();
        }
    }

    /// <summary>
    /// This method is reserved and should not be used.When implementing the IXmlSerializable
    /// interface, you should return null (Nothing in Visual Basic) from this method, and instead,
    /// if specifying a custom schema is required, apply the
    /// <see cref="XmlSchemaProviderAttribute" /> to the class.
    /// </summary>
    /// <returns>An <see cref="XmlSchema" /> that describes the XML representation of
    /// the object that is produced by the
    /// <see cref="WriteXml(XmlWriter)" />
    /// method and consumed by the
    /// <see cref="ReadXml(XmlReader)" />
    /// method.</returns>
    public XmlSchema GetSchema() => null;

    /// <summary>
    /// Generates an object from its XML representation.
    /// </summary>
    /// <param name="reader">The <see cref="System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
    public void ReadXml(XmlReader reader)
    {
        reader.DuplicateReaders(out var clonedReader, out var log);
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        try
        {
            if (
                clonedReader.MoveToContent() != XmlNodeType.Element
                || clonedReader.LocalName != SankhyaConstants.ServiceResponse
            )
            {
                return;
            }

            ParseAttributes(clonedReader);

            clonedReader.Read();
            if (
                !clonedReader.IsStartElement()
                || (
                    clonedReader.LocalName != SankhyaConstants.StatusMessage
                    && clonedReader.LocalName != SankhyaConstants.ResponseBody
                )
            )
            {
                return;
            }

            if (clonedReader.LocalName == SankhyaConstants.StatusMessage)
            {
                StatusMessage = new() { ValueInternal = clonedReader.ReadElementContentAsString() };
            }

            ParseResponseBody(clonedReader);
        }
        catch (Exception e)
        {
            var document = new XmlDocument();
            document.Load(log);
            LogConsumer.Handle(new ServiceRequestInvalidOperationException(document, e));
            throw;
        }
        finally
        {
            stopwatch.Stop();
            var diagnostics =
                $@"ServiceResponse->{Service.GetHumanReadableValue()}.ReadXml(): {stopwatch.Elapsed}";
            LogConsumer.Debug(diagnostics);
            clonedReader?.Dispose();
            log?.Dispose();
        }
    }

    /// <summary>
    /// Parses the response body.
    /// </summary>
    /// <param name="reader">The reader.</param>
    private void ParseResponseBody(XmlReader reader)
    {
        ResponseBody = new();

        while (!reader.EOF)
        {
            if (reader.LocalName == "responseBody" || reader.LocalName == "serviceResponse")
            {
                reader.Read();
            }

            if (!reader.IsStartElement())
            {
                reader.Read();
                continue;
            }

            if (ParseResponseBodyElements(reader))
            {
                return;
            }
        }
    }

    /// <summary>
    /// Parses the response body elements.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>Boolean.</returns>
    private bool ParseResponseBodyElements(XmlReader reader)
    {
        var entities = new List<EntityDynamicSerialization>();

        switch (reader.LocalName)
        {
            case SankhyaConstants.EntitiesPtBr:
                return ProcessCrudServiceEntities(reader, entities);

            case SankhyaConstants.EntitiesEn:
                return ProcessCrudServiceProviderEntities(reader, entities);

            case SankhyaConstants.InvoiceAccompaniments:
                ResponseBody.InvoiceAccompaniments =
                    (SerializerConverter<InvoiceAccompaniments>)ParseComplexType(reader);
                return false;

            case SankhyaConstants.Users:
                ResponseBody.Users = (SerializerConverter<Users>)ParseComplexType(reader);
                return false;

            case SankhyaConstants.Warnings:
                ResponseBody.Warnings = (SerializerConverter<Warnings>)ParseComplexType(reader);
                return false;

            case SankhyaConstants.Messages:
                ResponseBody.Messages = (SerializerConverter<Messages>)ParseComplexType(reader);
                return false;

            case SankhyaConstants.Releases:
                ResponseBody.Releases = (SerializerConverter<Releases>)ParseComplexType(reader);
                return false;

            case SankhyaConstants.Sessions:
                ResponseBody.Sessions =
                    (SerializerConverter<SessionsResponse>)ParseComplexType(reader);
                return false;

            case SankhyaConstants.Invoices:
                ResponseBody.Invoices = (SerializerConverter<Invoices>)ParseComplexType(reader);
                return false;

            case SankhyaConstants.ClientEvents:
                ResponseBody.ClientEvents =
                    (SerializerConverter<ClientEvents>)ParseComplexType(reader);
                return false;

            case SankhyaConstants.CancellationResult:
                ResponseBody.CancellationResult =
                    (SerializerConverter<CancellationResult>)ParseComplexType(reader);
                return false;

            case SankhyaConstants.Key:
                ResponseBody.Key = (SerializerConverter<Key>)ParseSimpleType(reader);
                return false;

            case SankhyaConstants.PrimaryKey:
                ResponseBody.PrimaryKey = ReadDynamic(reader);
                return false;

            case SankhyaConstants.JSessionId:
                ResponseBody.JSessionId = reader.ReadElementContentAsString();
                return false;

            case SankhyaConstants.CallId:
                ResponseBody.CallId = reader.ReadElementContentAsString();
                return false;

            case SankhyaConstants.CodeUser:
                ResponseBody.CodeUserInternal = reader.ReadElementContentAsString().Trim();
                return false;

            case SankhyaConstants.CodeUserLoggedId:
                ResponseBody.CodeUserLoggedIn = reader.ReadElementContentAsInt();
                return false;

            case SankhyaConstants.MessageUnlinkShipping:
                ResponseBody.MessageUnlinkShipping =
                    (SerializerConverter<MessageUnlinkShipping>)ParseSimpleType(reader);
                return false;

            default:
                LogConsumer.Handle(
                    new ServiceResponseUnexpectedElementException(
                        reader.LocalName,
                        _service.GetHumanReadableValue(),
                        this
                    )
                );
                new XmlDocument().Load(reader);
                return false;
        }
    }

    /// <summary>
    /// Processes the crud service provider entities.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="entities">The entities.</param>
    /// <returns>Trie of processed.</returns>
    private bool ProcessCrudServiceProviderEntities(
        XmlReader reader,
        List<EntityDynamicSerialization> entities
    )
    {
        ResponseBody.CrudServiceProviderEntities = new()
        {
            PagerId = reader.GetAttribute(SankhyaConstants.PagerId),
            Total = reader.GetAttribute(SankhyaConstants.Total).ToInt32(),
            TotalPages = reader.GetAttribute(SankhyaConstants.TotalPages).ToInt32()
        };
        reader.Read();
        if (
            reader.MoveToContent() == XmlNodeType.Element
            && reader.LocalName == SankhyaConstants.Metadata
        )
        {
            var metadata = new XmlDocument();
            metadata.LoadXml(reader.ReadOuterXml());

            ResponseBody.CrudServiceProviderEntities.Metadata =
                (SerializerConverter<Metadata>)metadata;
        }

        while (
            reader.MoveToContent() == XmlNodeType.Element
            && reader.LocalName == SankhyaConstants.EntityEn
        )
        {
            var entity = ReadDynamic(reader);
            if (ResponseBody.CrudServiceProviderEntities.Metadata != null)
            {
                entity.ChangeKeys(ResponseBody.CrudServiceProviderEntities.Metadata);
            }

            entities.Add(entity);
        }

        // ReSharper disable once CoVariantArrayConversion
        ResponseBody.CrudServiceProviderEntities.Entities = entities.ToArray();
        return false;
    }

    /// <summary>
    /// Processes the crud service entities.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="entities">The entities.</param>
    /// <returns>True if processed.</returns>
    private bool ProcessCrudServiceEntities(
        XmlReader reader,
        List<EntityDynamicSerialization> entities
    )
    {
        ResponseBody.CrudServiceEntities = new()
        {
            Name = reader.GetAttribute(SankhyaConstants.Name)
        };
        if (!reader.ReadToDescendant(SankhyaConstants.EntityPtBr))
        {
            return true;
        }

        while (
            reader.MoveToContent() == XmlNodeType.Element
            && reader.LocalName == SankhyaConstants.EntityPtBr
        )
        {
            entities.Add(ReadDynamic(reader));
        }

        // ReSharper disable once CoVariantArrayConversion
        ResponseBody.CrudServiceEntities.Entities = entities.ToArray();
        return false;
    }

    /// <summary>
    /// Parses the attributes.
    /// </summary>
    /// <param name="reader">The reader.</param>
    private void ParseAttributes(XmlReader reader)
    {
        ServiceInternal = reader.GetAttribute("serviceName");
        Status = (ServiceResponseStatus)reader.GetAttribute("status").ToInt32();
        if (reader.GetAttribute("pendingPrinting") != null)
        {
            PendingPrintingInternal = reader.GetAttribute("pendingPrinting");
        }

        if (reader.GetAttribute("errorCode") != null)
        {
            ErrorCode = reader.GetAttribute("errorCode").ToInt32();
        }

        if (reader.GetAttribute("errorLevel") != null)
        {
            ErrorLevel = reader.GetAttribute("errorLevel").ToInt32();
        }

        var transactionId = reader.GetAttribute("transactionId");
        if (
            !string.IsNullOrWhiteSpace(transactionId)
            && Guid.TryParse(transactionId, out var transactionIdGuid)
        )
        {
            TransactionId = transactionIdGuid;
        }
    }

    /// <summary>
    /// Parses the type of the complex.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>XmlDocument.</returns>
    private static XmlDocument ParseComplexType(XmlReader reader)
    {
        var document = new XmlDocument();
        var rootName = reader.LocalName;
        var root = document.CreateElement(rootName);
        document.AppendChild(root);
        reader.ReadStartElement(rootName);
        while (
            reader.NodeType != XmlNodeType.EndElement
            && reader.Name != rootName
            && document.ReadNode(reader) is { } currentNode
        )
        {
            root.AppendChild(currentNode);
        }

        return document;
    }

    /// <summary>
    /// Parses the type of the simple.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>XmlDocument.</returns>
    private static XmlDocument ParseSimpleType(XmlReader reader)
    {
        var document = new XmlDocument();
        document.Load(reader);
        return document;
    }

    /// <summary>
    /// Converts an object into its XML representation.
    /// </summary>
    /// <param name="writer">The <see cref="System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
    public void WriteXml(XmlWriter writer)
    {
        if (writer == null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        try
        {
            WriteAttributes(writer);

            if (StatusMessage != null)
            {
                writer.WriteStartElement(SankhyaConstants.StatusMessage);
                writer.WriteString(StatusMessage.Value.RemoveExcessSpaces());
                writer.WriteEndElement();
            }

            if (ResponseBody == null)
            {
                return;
            }

            writer.WriteStartElement(SankhyaConstants.ResponseBody);
            WriteResponseBodyElements(writer);
            writer.WriteEndElement();
        }
        finally
        {
            stopwatch.Stop();
            var diagnostics =
                $@"ServiceResponse->{Service.GetHumanReadableValue()}.WriteXml(): {stopwatch.Elapsed}";
            LogConsumer.Debug(diagnostics);
        }
    }

    /// <summary>
    /// Writes the response body elements to the writer.
    /// </summary>
    /// <param name="writer"><see cref="XmlWriter" />The XML writer.</param>
    private void WriteResponseBodyElements(XmlWriter writer)
    {
        ProcessCrudServiceEntity(writer);
        ProcessCrudServiceProviderEntity(writer);
        ProcessInvoiceAccompaniments(writer);
        ProcessUsers(writer);
        ProcessWarnings(writer);
        ProcessMessages(writer);
        ProcessReleases(writer);
        ProcessSessions(writer);
        ProcessInvoices(writer);
        ProcessClientEvents(writer);
        ProcessCancellationResult(writer);
        ProcessKey(writer);
        ProcessPrimaryKey(writer);
        ProcessSessionId(writer);
        ProcessCallId(writer);
        ProcessCodeUser(writer);
        ProcessCodeUserLoggedIn(writer);
    }

    /// <summary>
    /// Processes the code user logged in.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessCodeUserLoggedIn(XmlWriter writer)
    {
        if (!ResponseBody.ShouldSerializeCodeUserLoggedIn())
        {
            return;
        }

        writer.WriteStartElement("codUsuLogado");
        writer.WriteValue(ResponseBody.CodeUserLoggedIn);
        writer.WriteEndElement();
    }

    /// <summary>
    /// Processes the code user.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessCodeUser(XmlWriter writer)
    {
        if (!ResponseBody.ShouldSerializeCodeUserInternal())
        {
            return;
        }

        writer.WriteStartElement("idusu");
        writer.WriteValue(ResponseBody.CodeUserInternal);
        writer.WriteEndElement();
    }

    /// <summary>
    /// Processes the call identifier.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessCallId(XmlWriter writer)
    {
        if (!ResponseBody.ShouldSerializeCallId())
        {
            return;
        }

        writer.WriteStartElement("callID");
        writer.WriteValue(ResponseBody.CallId);
        writer.WriteEndElement();
    }

    /// <summary>
    /// Processes the session identifier.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessSessionId(XmlWriter writer)
    {
        if (!ResponseBody.ShouldSerializeJSessionId())
        {
            return;
        }

        writer.WriteStartElement("jsessionId");
        writer.WriteValue(ResponseBody.JSessionId);
        writer.WriteEndElement();
    }

    /// <summary>
    /// Processes the primary key.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessPrimaryKey(XmlWriter writer)
    {
        if (ResponseBody.PrimaryKey == null)
        {
            return;
        }

        writer.WriteStartElement("pk");
        WriteDynamic(writer, ResponseBody.PrimaryKey);
        writer.WriteEndElement();
    }

    /// <summary>
    /// Processes the key.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessKey(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Key?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    /// <summary>
    /// Processes the cancellation result.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessCancellationResult(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.CancellationResult?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    /// <summary>
    /// Processes the client events.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessClientEvents(XmlWriter writer)
    {
        if (ResponseBody.ClientEvents == null)
        {
            return;
        }

        writer.WriteStartElement("clientEvents");
        XmlDocument xml = ResponseBody.ClientEvents.GetSerializer();
        if (xml.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }

        writer.WriteEndElement();
    }

    /// <summary>
    /// Processes the invoices.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessInvoices(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Invoices?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    /// <summary>
    /// Processes the sessions.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessSessions(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Sessions?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    /// <summary>
    /// Processes the releases.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessReleases(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Releases?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    /// <summary>
    /// Processes the messages.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessMessages(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Messages?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    /// <summary>
    /// Processes the warnings.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessWarnings(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Warnings?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    /// <summary>
    /// Processes the users.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessUsers(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Users?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    /// <summary>
    /// Processes the invoice accompaniments.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessInvoiceAccompaniments(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.InvoiceAccompaniments?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    /// <summary>
    /// Processes the crud service provider entity.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessCrudServiceProviderEntity(XmlWriter writer)
    {
        if (ResponseBody.CrudServiceProviderEntities == null)
        {
            return;
        }

        writer.WriteStartElement(SankhyaConstants.EntitiesEn);
        if (!string.IsNullOrWhiteSpace(ResponseBody.CrudServiceProviderEntities.PagerId))
        {
            writer.WriteAttributeString(
                SankhyaConstants.PagerId,
                ResponseBody.CrudServiceProviderEntities.PagerId
            );
        }

        if (ResponseBody.CrudServiceProviderEntities.TotalPages > 0)
        {
            writer.WriteAttributeString(
                SankhyaConstants.TotalPages,
                ResponseBody.CrudServiceProviderEntities.TotalPages.ToString(
                    CultureInfo.InvariantCulture
                )
            );
        }

        writer.WriteAttributeString(
            SankhyaConstants.Total,
            ResponseBody.CrudServiceProviderEntities.Total.ToString(CultureInfo.InvariantCulture)
        );

        XmlDocument xml = ResponseBody.CrudServiceProviderEntities.Metadata?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }

        foreach (EntityDynamicSerialization ds in ResponseBody.CrudServiceProviderEntities.Entities)
        {
            writer.WriteStartElement(SankhyaConstants.EntityEn);

            WriteDynamic(writer, ds);

            writer.WriteEndElement();
        }

        writer.WriteEndElement();
    }

    /// <summary>
    /// Processes the crud service entity.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void ProcessCrudServiceEntity(XmlWriter writer)
    {
        if (ResponseBody.CrudServiceEntities?.Entities == null)
        {
            return;
        }

        writer.WriteStartElement(SankhyaConstants.EntitiesPtBr);
        writer.WriteAttributeString(SankhyaConstants.Name, ResponseBody.CrudServiceEntities.Name);
        foreach (var ds in ResponseBody.CrudServiceEntities.Entities)
        {
            writer.WriteStartElement(SankhyaConstants.EntityPtBr);
            WriteDynamic(writer, (EntityDynamicSerialization)ds);
            writer.WriteEndElement();
        }

        writer.WriteEndElement();
    }

    /// <summary>
    /// Writes the attributes.
    /// </summary>
    /// <param name="writer">The writer.</param>
    private void WriteAttributes(XmlWriter writer)
    {
        writer.WriteAttributeString(SankhyaConstants.ServiceName, ServiceInternal);
        writer.WriteAttributeString(SankhyaConstants.Status, Status.ToString());
        if (_pendingPrintingSet)
        {
            writer.WriteAttributeString("pendingPrinting", PendingPrintingInternal);
        }

        if (_transactionIdSet)
        {
            writer.WriteAttributeString("transactionId", TransactionId.ToString());
        }

        if (_errorCodeSet)
        {
            writer.WriteAttributeString(
                "errorCode",
                ErrorCode.ToString(CultureInfo.InvariantCulture)
            );
        }

        if (_errorLevelSet)
        {
            writer.WriteAttributeString(
                "errorLevel",
                ErrorLevel.ToString(CultureInfo.InvariantCulture)
            );
        }
    }
}
