using System;
using System.Collections.Generic;
using System.ComponentModel;
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
[XmlRoot(ElementName = SankhyaConstants.ServiceResponse)]
public sealed class ServiceResponse : IXmlSerializable
{
    /// <summary>
    /// The service.
    /// </summary>
    private ServiceName _service;

    /// <summary>
    /// The service set.
    /// </summary>
    private bool _serviceSet;

    /// <summary>
    /// The pending printing.
    /// </summary>
    private bool _pendingPrinting;

    /// <summary>
    /// The pending printing set.
    /// </summary>
    private bool _pendingPrintingSet;

    /// <summary>
    /// The transaction identifier.
    /// </summary>
    private Guid _transactionId;

    /// <summary>
    /// The transaction identifier set.
    /// </summary>
    private bool _transactionIdSet;

    /// <summary>
    /// The status.
    /// </summary>
    private ServiceResponseStatus _status;

    /// <summary>
    /// The status set.
    /// </summary>
    private bool _statusSet;

    /// <summary>
    /// The error code.
    /// </summary>
    private int _errorCode;

    /// <summary>
    /// The error code set.
    /// </summary>
    private bool _errorCodeSet;

    /// <summary>
    /// The error level.
    /// </summary>
    private int _errorLevel;

    /// <summary>
    /// The error level set.
    /// </summary>
    private bool _errorLevelSet;

    /// <summary>
    /// The status message.
    /// </summary>
    private StatusMessage _statusMessage;

    /// <summary>
    /// The status message set.
    /// </summary>
    private bool _statusMessageSet;

    /// <summary>
    /// The response body.
    /// </summary>
    private ResponseBody _responseBody;

    /// <summary>
    /// The response body set.
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
    [XmlAttribute(SankhyaConstants.ServiceName)]
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
    /// Gets or sets a value indicating whether [pending printing].
    /// </summary>
    /// <value><c>true</c> if [pending printing]; otherwise, <c>false</c>.</value>
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
    [XmlAttribute(SankhyaConstants.PendingPrinting)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string PendingPrintingInternal
    {
        get => _pendingPrinting.ToString().ToLowerInvariant();
        set
        {
            _pendingPrinting = value.ToBoolean(SankhyaConstants.TrueOrFalse);
            _pendingPrintingSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the transaction identifier.
    /// </summary>
    /// <value>The transaction identifier.</value>
    [XmlAttribute(SankhyaConstants.TransactionId)]
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
    [XmlAttribute(SankhyaConstants.Status)]
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
    [XmlAttribute(SankhyaConstants.ErrorCode)]
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
    [XmlAttribute(SankhyaConstants.ErrorLevel)]
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
    [XmlElement(SankhyaConstants.StatusMessage)]
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
    [XmlElement(ElementName = SankhyaConstants.ResponseBody)]
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
            if (!ParseDynamic(node, ds))
            {
                break;
            }
        }

        return ds;
    }

    private static bool ParseDynamic(XmlReader node, EntityDynamicSerialization ds)
    {
        var elementName = node.LocalName;
        if (elementName == SankhyaConstants.Rmd)
        {
            node.ReadOuterXml();
            return true;
        }

        switch (node.NodeType)
        {
            case XmlNodeType.EndElement
                when elementName
                    is SankhyaConstants.EntityPtBr
                        or SankhyaConstants.EntityEn
                        or SankhyaConstants.PrimaryKey:
                node.Read();
                return false;
            case XmlNodeType.Element when node.IsEmptyElement:
                ds.SetMember(node.Name, null);
                node.Read();
                return true;
            case XmlNodeType.Element:
                ds.SetMember(elementName, node.ReadElementContentAsString());
                return true;
        }

        return false;
    }

    /// <summary>
    /// Writes a dynamic.
    /// </summary>
    /// <param name="writer">The <see cref="XmlWriter" /> stream to which the object is serialized.</param>
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
    /// <param name="reader">The <see cref="XmlReader" /> stream from which the object is deserialized.</param>
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
            if (
                reader.LocalName == SankhyaConstants.ResponseBody
                || reader.LocalName == SankhyaConstants.ServiceResponse
            )
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
    /// Processes CRUD service provider entities from an XML reader and populates the response body.
    /// </summary>
    /// <param name="reader">The XML reader containing the data to be processed.</param>
    /// <param name="entities">A list to store the dynamically read entities.</param>
    /// <remarks>
    /// This method reads attributes related to pagination such as PagerId, Total, and TotalPages from the XML reader
    /// and initializes the <see cref="ResponseBody.CrudServiceProviderEntities"/> object with these values.
    /// It then checks for the presence of metadata in the XML and, if found, loads it into the response body.
    /// The method continues to read through the XML, looking for elements that represent individual entities,
    /// which are then read and added to the provided list of entities. If metadata is present, it is used to change
    /// the keys of the entities being read. Finally, the list of entities is converted to an array and assigned
    /// to the response body.
    /// </remarks>
    /// <returns>Returns false indicating that processing is complete but does not signify any errors.</returns>
    private bool ProcessCrudServiceProviderEntities(
        XmlReader reader,
        List<EntityDynamicSerialization> entities
    )
    {
        ResponseBody.CrudServiceProviderEntities = new()
        {
            PagerId = reader.GetAttribute(SankhyaConstants.PagerId),
            Total = reader.GetAttribute(SankhyaConstants.Total).ToInt32(),
            TotalPages = reader.GetAttribute(SankhyaConstants.TotalPages).ToInt32(),
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
    /// Processes CRUD service entities from an XML reader and populates a list of dynamic entities.
    /// </summary>
    /// <param name="reader">The XML reader used to read the CRUD service entities.</param>
    /// <param name="entities">A list that will be populated with dynamic entities read from the XML.</param>
    /// <returns>Returns <c>true</c> if no entities were found, otherwise returns <c>false</c>.</returns>
    /// <remarks>
    /// This method initializes the <see cref="ResponseBody.CrudServiceEntities"/> with the name attribute from the XML reader.
    /// It then checks for the presence of the entity element defined by <see cref="SankhyaConstants.EntityPtBr"/>.
    /// If found, it reads each entity and adds it to the provided list of entities.
    /// The method continues to read until there are no more elements of the specified type.
    /// Finally, it converts the list of entities to an array and assigns it to <see cref="CrudServiceEntities.Entities"/>.
    /// This method is primarily used for deserializing dynamic entities from an XML structure into a manageable format.
    /// </remarks>
    private bool ProcessCrudServiceEntities(
        XmlReader reader,
        List<EntityDynamicSerialization> entities
    )
    {
        ResponseBody.CrudServiceEntities = new()
        {
            Name = reader.GetAttribute(SankhyaConstants.Name),
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
        ServiceInternal = reader.GetAttribute(SankhyaConstants.ServiceName);
        Status = (ServiceResponseStatus)reader.GetAttribute(SankhyaConstants.Status).ToInt32();
        if (reader.GetAttribute(SankhyaConstants.PendingPrinting) != null)
        {
            PendingPrintingInternal = reader.GetAttribute(SankhyaConstants.PendingPrinting);
        }

        if (reader.GetAttribute(SankhyaConstants.ErrorCode) != null)
        {
            ErrorCode = reader.GetAttribute(SankhyaConstants.ErrorCode).ToInt32();
        }

        if (reader.GetAttribute(SankhyaConstants.ErrorLevel) != null)
        {
            ErrorLevel = reader.GetAttribute(SankhyaConstants.ErrorLevel).ToInt32();
        }

        var transactionId = reader.GetAttribute(SankhyaConstants.TransactionId);
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
    /// <param name="writer">The <see cref="XmlWriter" /> stream to which the object is serialized.</param>
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

        writer.WriteStartElement(SankhyaConstants.CodeUserLoggedId);
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

        writer.WriteStartElement(SankhyaConstants.CodeUser);
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

        writer.WriteStartElement(SankhyaConstants.CallId);
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

        writer.WriteStartElement(SankhyaConstants.JSessionId);
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

        writer.WriteStartElement(SankhyaConstants.PrimaryKey);
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

        writer.WriteStartElement(SankhyaConstants.ClientEvents);
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

#pragma warning disable S3217
        foreach (EntityDynamicSerialization ds in ResponseBody.CrudServiceProviderEntities.Entities)
#pragma warning restore S3217
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
            writer.WriteAttributeString(SankhyaConstants.PendingPrinting, PendingPrintingInternal);
        }

        if (_transactionIdSet)
        {
            writer.WriteAttributeString(SankhyaConstants.TransactionId, TransactionId.ToString());
        }

        if (_errorCodeSet)
        {
            writer.WriteAttributeString(
                SankhyaConstants.ErrorCode,
                ErrorCode.ToString(CultureInfo.InvariantCulture)
            );
        }

        if (_errorLevelSet)
        {
            writer.WriteAttributeString(
                SankhyaConstants.ErrorLevel,
                ErrorLevel.ToString(CultureInfo.InvariantCulture)
            );
        }
    }
}
