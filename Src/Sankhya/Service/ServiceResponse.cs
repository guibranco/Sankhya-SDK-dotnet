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

[Serializer]
[XmlRoot(ElementName = SankhyaConstants.ServiceResponse)]
public sealed class ServiceResponse : IXmlSerializable
{
    private ServiceName _service;

    private bool _serviceSet;

    private bool _pendingPrinting;

    private bool _pendingPrintingSet;

    private Guid _transactionId;

    private bool _transactionIdSet;

    private ServiceResponseStatus _status;

    private bool _statusSet;

    private int _errorCode;

    private bool _errorCodeSet;

    private int _errorLevel;

    private bool _errorLevelSet;

    private StatusMessage _statusMessage;

    private bool _statusMessageSet;

    private ResponseBody _responseBody;

    private bool _responseBodySet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeServiceInternal() => _serviceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePendingPrintingInternal() => _pendingPrintingSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTransactionId() => _transactionIdSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStatus() => _statusSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeErrorCode() => _errorCodeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeErrorLevel() => _errorLevelSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStatusMessage() => _statusMessageSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeResponseBody() => _responseBodySet;

    public EntityDynamicSerialization[] Entities =>
        ResponseBody.CrudServiceEntities != null
            ? ResponseBody.CrudServiceEntities.Entities as EntityDynamicSerialization[]
            : ResponseBody.CrudServiceProviderEntities?.Entities as EntityDynamicSerialization[];

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

    public XmlSchema GetSchema() => null;

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

#pragma warning disable IDE0305 // Simplify collection initialization
        // ReSharper disable once CoVariantArrayConversion
        ResponseBody.CrudServiceProviderEntities.Entities = entities.ToArray();
#pragma warning restore IDE0305 // Simplify collection initialization
        return false;
    }

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

#pragma warning disable IDE0305 // Simplify collection initialization
        // ReSharper disable once CoVariantArrayConversion
        ResponseBody.CrudServiceEntities.Entities = entities.ToArray();
#pragma warning restore IDE0305 // Simplify collection initialization
        return false;
    }

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

    private static XmlDocument ParseSimpleType(XmlReader reader)
    {
        var document = new XmlDocument();
        document.Load(reader);
        return document;
    }

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

    private void ProcessKey(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Key?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    private void ProcessCancellationResult(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.CancellationResult?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

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

    private void ProcessInvoices(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Invoices?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    private void ProcessSessions(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Sessions?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    private void ProcessReleases(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Releases?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    private void ProcessMessages(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Messages?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    private void ProcessWarnings(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Warnings?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    private void ProcessUsers(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.Users?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

    private void ProcessInvoiceAccompaniments(XmlWriter writer)
    {
        XmlDocument xml = ResponseBody.InvoiceAccompaniments?.GetSerializer();
        if (xml?.DocumentElement != null)
        {
            writer.WriteRaw(xml.DocumentElement.OuterXml);
        }
    }

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
