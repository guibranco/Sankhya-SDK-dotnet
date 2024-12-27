using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CrispyWaffle.Composition;
using CrispyWaffle.Extensions;
using CrispyWaffle.Log;
using CrispyWaffle.Serialization;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Helpers;
using Sankhya.Properties;
using Sankhya.Service;
using Sankhya.Transport;
using Sankhya.ValueObjects;

namespace Sankhya.RequestWrappers;

public static class KnowServicesRequestWrapper
{
    private static readonly SankhyaContext Context = ServiceLocator.Resolve<SankhyaContext>();

    private static readonly Guid SessionToken = Context.AcquireNewSession(
        ServiceRequestType.KnowServices
    );

    private static DateTime _lastTimeMessageReceived;

    public static IEnumerable<Session> GetSessions()
    {
        var request = new ServiceRequest(ServiceName.SessionGetAll);
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        return response.ResponseBody.Sessions.Sessions;
    }

    public static void KillSession(string sessionId)
    {
        var request = new ServiceRequest(ServiceName.SessionKill)
        {
            RequestBody = new() { Session = new() { Id = sessionId } },
        };
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    public static void SendWarning(
        [Localizable(false)] string title,
        [Localizable(false)] string description,
        [Localizable(false)] string tip,
        SankhyaWarningLevel level,
        ICollection<SystemWarningRecipient> recipients = null
    )
    {
        var request = new ServiceRequest(ServiceName.WarningSend)
        {
            RequestBody = new()
            {
                SystemWarning = new()
                {
                    Description = description,
                    Importance = level,
                    Title = title,
                },
            },
        };
        if (!string.IsNullOrWhiteSpace(tip))
        {
            request.RequestBody.SystemWarning.Tip = tip;
        }

        if (recipients != null && recipients.Any())
        {
            request.RequestBody.SystemWarning.Recipients = recipients.ToArray();
        }

        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_SendWarning_SendingWarningWithLevel,
            level.GetHumanReadableValue(),
            title,
            recipients == null || !recipients.Any()
                ? Resources.All
                : string.Concat(recipients.Count, Resources.UsersOrGroups)
        );
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    public static void SendMessage(
        [Localizable(false)] string content,
        ICollection<SystemWarningRecipient> recipients = null
    )
    {
        var request = new ServiceRequest(ServiceName.MessageSend)
        {
            RequestBody = { SystemMessage = new() { Content = content } },
        };
        if (recipients != null && recipients.Any())
        {
            request.RequestBody.SystemMessage.Recipients = recipients.ToArray();
        }

        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_SendMessage_SendingMessage,
            recipients?.Count.ToString() ?? Resources.All
        );
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    public static string ReceiveMessages()
    {
        var request = new ServiceRequest(ServiceName.WarningReceive)
        {
            RequestBody =
            {
                NotificationElem = new() { LastNotification = _lastTimeMessageReceived },
            },
        };
        LogConsumer.Info(Resources.KnowServicesRequestWrapper_ReceiveMessages_ReceivingMessages);
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        _lastTimeMessageReceived = DateTime.Now;
        return (string)response.GetSerializer();
    }

    public static int CreateInvoice(
        InvoiceHeader invoiceHeader,
        IEnumerable<InvoiceItem> invoiceItems = null
    )
    {
        if (invoiceHeader == null)
        {
            throw new ArgumentNullException(nameof(invoiceHeader));
        }

        var request = new ServiceRequest(ServiceName.InvoiceInclude)
        {
            RequestBody = { Invoice = new() { Header = invoiceHeader } },
        };
        var itemsCount = 0;
        if (invoiceItems != null)
        {
            var items = invoiceItems as InvoiceItem[] ?? invoiceItems.ToArray();
            itemsCount = items.Length;
            if (items.Any())
            {
                request.RequestBody.Invoice.Items = new() { Items = items };
            }
        }

        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_CreateInvoice,
            invoiceHeader.OperationType,
            itemsCount,
            itemsCount == 1 ? @"m" : Resources.ItemPluralSufix
        );
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        string singleNumber = response.ResponseBody.PrimaryKey.NUNOTA.ToString();
        return singleNumber.ToInt32();
    }

    public static void RemoveInvoice(int singleNumber)
    {
        var request = new ServiceRequest(ServiceName.InvoiceRemove)
        {
            RequestBody =
            {
                Invoices = new() { Invoice = new() { SingleNumberDuplication = singleNumber } },
            },
        };

        LogConsumer.Info(Resources.KnowServicesRequestWrapper_RemoveInvoice, singleNumber);
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    public static int AddInvoiceItems(int singleNumber, IEnumerable<InvoiceItem> invoiceItems)
    {
        var items = invoiceItems as InvoiceItem[] ?? invoiceItems.ToArray();
        var request = new ServiceRequest(ServiceName.InvoiceItemInclude)
        {
            RequestBody =
            {
                Invoice = new()
                {
                    SingleNumberDuplication = singleNumber,
                    Items = new()
                    {
                        Items = items,
                        InformPrice = true,
                        OnlineUpdate = true,
                    },
                },
            },
        };

        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_AddInvoiceItems_AddingItemsToInvoice,
            items.Length,
            singleNumber,
            items.Length == 1 ? @"m" : Resources.ItemPluralSufix
        );

        var response = SankhyaContext.ServiceInvoker(request, SessionToken);

        try
        {
            string sequence = response.ResponseBody.PrimaryKey.SEQUENCIA.ToString();

            return sequence.ToInt32();
        }
        catch (Exception e)
        {
            LogConsumer.Handle(e);
        }

        return 0;
    }

    public static void RemoveInvoiceItems(IEnumerable<InvoiceItem> invoiceItems)
    {
        var items = invoiceItems as InvoiceItem[] ?? invoiceItems.ToArray();
        var first = items[0];
        if (
            !items.All(item =>
                item.SingleNumber.HasValue && item.SingleNumber == first.SingleNumber
            )
        )
        {
            throw new InvalidOperationException(
                Resources.KnowServicesRequestWrapper_RemoveInvoiceItems_AllItemsMustBeFromTheSameInvoice
            );
        }

        var request = new ServiceRequest(ServiceName.InvoiceItemRemove)
        {
            RequestBody =
            {
                Invoice = new()
                {
                    Items = new() { Items = items, OnlineUpdate = true },
                },
            },
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_RemoveInvoiceItems_DeletingItemsFromInvoice,
            items.Length,
            first.SingleNumber ?? 0,
            items.Length == 1 ? @"m" : Resources.ItemPluralSufix
        );
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    public static int Bill(
        int singleNumber,
        int codeOperationType,
        BillingType type,
        out ClientEvent[] responseEvents,
        int? series = null,
        ClientEvent[] requestEvents = null
    )
    {
        var request = new ServiceRequest(ServiceName.InvoiceBill)
        {
            RequestBody =
            {
                Invoices = new()
                {
                    BillingType = type,
                    CodeOperationType = codeOperationType,
                    DateBillingNullable = null,
                    DateExitNullable = null,
                    TimeExitNullable = null,
                    IsDateValidated = true,
                    InvoicesWithCurrency = new() { CurrencyValue = @"undefined" },
                    Invoice = new() { Value = singleNumber },
                    OneInvoiceForEach = true,
                },
            },
        };
        if (requestEvents != null)
        {
            request.RequestBody.ClientEvents = requestEvents;
        }

        if (series.HasValue)
        {
            request.RequestBody.Invoices.BillingType = BillingType.Direct;
            request.RequestBody.Invoices.Series = series.Value;
        }

        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_Bill_BillingInvoiceToTOP,
            singleNumber,
            codeOperationType,
            request.RequestBody.Invoices.BillingType.GetHumanReadableValue(),
            series?.ToString() ?? Resources.Uninformed
        );
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        responseEvents = null;
        if (response?.ResponseBody == null)
        {
            return -1;
        }

        if (response.ResponseBody.ClientEvents?.ClientEvent != null)
        {
            responseEvents = response.ResponseBody.ClientEvents.ClientEvent;
        }

        return response.ResponseBody.Invoices?.Invoice?.Value == null
            ? -1
            : response.ResponseBody.Invoices.Invoice.Value;
    }

    public static void ConfirmInvoice(int singleNumber)
    {
        var request = new ServiceRequest(ServiceName.InvoiceConfirm)
        {
            RequestBody =
            {
                Invoice = new()
                {
                    ConfirmationCentralInvoices = true,
                    IsWebOrder = false,
                    UpdatePriceItemPurchaseOrder = false,
                    SingleNumberConfirmation = singleNumber,
                    Props = new[]
                    {
                        new Prop { Name = @"br.com.utiliza.dtneg.servidor", Value = @"false" },
                    },
                },
            },
        };

        try
        {
            LogConsumer.Info(
                Resources.KnowServicesRequestWrapper_ConfirmInvoice_Confirming,
                singleNumber
            );
            SankhyaContext.ServiceInvoker(request, SessionToken);
        }
        catch (Exception e)
        {
            if (
                e.Message.IndexOf(
                    @"confirmar sem produtos/serviços/mat.prima",
                    StringComparison.OrdinalIgnoreCase
                ) != -1
            )
            {
                throw new NoItemsConfirmInvoiceException(singleNumber, null, e);
            }

            if (e.Message.IndexOf(@"já foi confirmada", StringComparison.OrdinalIgnoreCase) == -1)
            {
                throw new ConfirmInvoiceException(singleNumber, null, e);
            }
        }
    }

    public static void FlagInvoicesAsNotPending(IEnumerable<int> singleNumbers)
    {
        var singleNumbersArray = singleNumbers as int[] ?? singleNumbers.ToArray();
        var request = new ServiceRequest(ServiceName.InvoiceFlagAsNotPending)
        {
            RequestBody = { SingleNumbers = singleNumbersArray },
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_FlagInvoicesAsNotPending,
            singleNumbersArray.Length,
            singleNumbersArray.Length == 1 ? string.Empty : @"s",
            string.Join(@",", singleNumbersArray)
        );
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    public static IEnumerable<Invoice> GetInvoiceAccompaniments(IEnumerable<int> singleNumbers)
    {
        var singleNumbersList = singleNumbers as int[] ?? singleNumbers.ToArray();
        var request = new ServiceRequest(ServiceName.InvoiceAccompaniments)
        {
            RequestBody = { Invoices = new() { SingleNumbers = singleNumbersList } },
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_GetInvoiceAccompaniments,
            singleNumbersList.Length,
            singleNumbersList.Length == 1 ? string.Empty : @"s",
            string.Join(@",", singleNumbersList)
        );
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        return response.ResponseBody.InvoiceAccompaniments.Invoices;
    }

    public static int CancelInvoices(
        IEnumerable<int> singleNumbers,
        string justification,
        out IEnumerable<int> singleNumbersNotCancelled
    )
    {
        var singleNumbersList = singleNumbers as int[] ?? singleNumbers.ToArray();
        var request = new ServiceRequest(ServiceName.InvoiceCancel)
        {
            RequestBody =
            {
                CancelledInvoices = new()
                {
                    Justification = justification,
                    SingleNumbers = singleNumbersList,
                },
            },
        };

        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_CancelInvoices_Canceling,
            singleNumbersList.Length,
            singleNumbersList.Length == 1 ? string.Empty : @"s",
            string.Join(@",", singleNumbersList)
        );
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        var cancelled = response.ResponseBody.CancellationResult.TotalCancelledInvoices;
        singleNumbersNotCancelled =
            response.ResponseBody.CancellationResult.SingleNumbers ?? Array.Empty<int>();
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_CancelInvoices_Canceled,
            cancelled,
            cancelled == 1 ? string.Empty : @"s"
        );
        return cancelled;
    }

    public static void BindInvoiceWithOrder(
        int singleNumber,
        int codePartner,
        MovementType movementType
    )
    {
        var request = new ServiceRequest(ServiceName.InvoiceBindWithOrder)
        {
            RequestBody =
            {
                Params = new()
                {
                    SingleNumber = singleNumber,
                    CodePartner = codePartner,
                    MovementType = movementType,
                },
            },
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_BindInvoiceWithOrder,
            singleNumber,
            codePartner,
            movementType.GetHumanReadableValue()
        );
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    public static int DuplicateInvoice(
        int singleNumber,
        int codeOperationType,
        int? series = null,
        DateTime? dateExit = null,
        bool shouldUpdatePrice = false
    )
    {
        var request = new ServiceRequest(ServiceName.InvoiceDuplicate)
        {
            RequestBody =
            {
                Invoices = new()
                {
                    CodeOperationTypeDuplication = codeOperationType,
                    DateExitDuplicationNullable = dateExit,
                    ShouldUpdatePrice = shouldUpdatePrice,
                    ShouldDuplicateAllItems = true,
                    Invoice = new() { SingleNumberDuplication = singleNumber },
                },
            },
        };

        if (series.HasValue)
        {
            request.RequestBody.Invoices.Series = series.Value;
        }

        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_DuplicateInvoice_Duplicating,
            singleNumber,
            series?.ToString() ?? Resources.Uninformed,
            codeOperationType,
            dateExit?.ToString(@"dd/MM/yyyy") ?? Resources.Uninformed,
            shouldUpdatePrice.ToString(Resources.Yes, Resources.No)
        );
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_DuplicateInvoice_Duplicated,
            response.ResponseBody.Invoices.Invoice.SingleNumberDuplicationSource,
            response.ResponseBody.Invoices.Invoice.SingleNumberDuplicationDestiny
        );
        return response.ResponseBody.Invoices.Invoice.SingleNumberDuplicationDestiny;
    }

    public static void GetFiscalInvoiceAuthorization(IEnumerable<int> singleNumbers)
    {
        var singleNumbersLists = singleNumbers as int[] ?? singleNumbers.ToArray();
        var request = new ServiceRequest(ServiceName.NfeGetAuthorization)
        {
            RequestBody = { Invoices = new() { SingleNumbers = singleNumbersLists } },
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_GetFiscalInvoiceAuthorization,
            singleNumbersLists.Length,
            singleNumbersLists.Length == 1 ? string.Empty : @"s",
            string.Join(@",", singleNumbersLists)
        );
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    public static void GenerateLot(IEnumerable<int> singleNumbers)
    {
        var singleNumbersLists = singleNumbers as int[] ?? singleNumbers.ToArray();
        var request = new ServiceRequest(ServiceName.NfeGenerateLot)
        {
            RequestBody =
            {
                Invoices = new()
                {
                    ReturnDisapprovedInvoices = false,
                    SingleNumbers = singleNumbersLists,
                },
            },
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_GenerateLot,
            singleNumbersLists.Length,
            singleNumbersLists.Length == 1 ? string.Empty : @"s",
            string.Join(@",", singleNumbersLists)
        );
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    public static void FlagAsPaymentsPaid(IEnumerable<int> financialNumbers, int codeAccount)
    {
        var financialNumbersList = financialNumbers as List<int> ?? financialNumbers.ToList();
        var request = new ServiceRequest(ServiceName.InvoiceAutomaticLow)
        {
            RequestBody =
            {
                LowData = new()
                {
                    FinancialNumbersList = string.Join(@",", financialNumbersList),
                    Empresa = @"1",
                    ContaBco = codeAccount.ToString(),
                    ChkReceita = @"S",
                    ChkDespesa = @"S",
                    ChkBaixaSeparada = @"S",
                    ChkUsarHist = @"N",
                    ChkNossoNum = @"N",
                    ChkVlrLiqZero = @"N",
                    RbdConcatSobreporHistFin = @"1",
                    ChkUsaVenc = @"S",
                    ChkSubInf = @"S",
                    TipLancRec = @"24",
                    TopBaixaRec = @"801",
                    TipLancDesp = @"1",
                    TopBaixaDesp = @"800",
                    TemFiltroAntecipacaoBx = @"N",
                    ParamImprimeBoleto = @"false",
                },
            },
        };
        try
        {
            LogConsumer.Info(
                Resources.KnowServicesRequestWrapper_FlagAsPaymentsPaid,
                financialNumbersList.Count == 1 ? string.Empty : @"s",
                string.Join(@",", financialNumbersList)
            );
            SankhyaContext.ServiceInvoker(request, SessionToken);
        }
        catch (Exception e)
        {
            throw new MarkAsPaymentPaidException(financialNumbersList, request, e);
        }
    }

    public static void ReversePayments(IEnumerable<int> financialNumbers)
    {
        var financialNumbersList = financialNumbers as List<int> ?? financialNumbers.ToList();
        foreach (
            var request in financialNumbersList.Select(financialNumber => new ServiceRequest(
                ServiceName.FinancialReversal
            )
            {
                RequestBody =
                {
                    Param = new()
                    {
                        FinancialNumber = financialNumber,
                        Recompose = @"undefined",
                        RevertAllAnticipation = @"undefined",
                    },
                },
            })
        )
        {
            LogConsumer.Info(
                Resources.KnowServicesRequestWrapper_ReversePayments,
                request.RequestBody.Param.FinancialNumber
            );
            SankhyaContext.ServiceInvoker(request, SessionToken);
        }
    }

    public static void UnlinkShipping(int financialNumber)
    {
        var request = new ServiceRequest(ServiceName.UnlinkShipping)
        {
            RequestBody = { Param = new() { FinancialNumberUpperCase = financialNumber } },
        };

        try
        {
            LogConsumer.Info(Resources.KnowServicesRequestWrapper_UnlinkShipping, financialNumber);
            SankhyaContext.ServiceInvoker(request, SessionToken);
        }
        catch (Exception e)
        {
            throw new UnlinkShippingException(financialNumber, request, e);
        }
    }

    public static string OpenFile(string path)
    {
        var request = new ServiceRequest(ServiceName.FileOpen)
        {
            RequestBody = { Config = new() { Path = path } },
        };
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        return response.ResponseBody.Key.Value;
    }

    public static void DeleteFiles(IEnumerable<string> paths)
    {
        var pathsArray = paths as string[] ?? paths.ToArray();
        var request = new ServiceRequest(ServiceName.FileDelete)
        {
            RequestBody =
            {
                Paths = pathsArray.Select(path => new Service.Path { Value = path }).ToArray(),
                ClientEvents = new[]
                {
                    new ClientEvent { Text = @"br.com.sankhya.actionbutton.clientconfirm" },
                },
            },
        };
        LogConsumer.Info(Resources.KnowServicesRequestWrapper_DeleteFiles, pathsArray.Length);
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    public static ServiceFile GetFile(string key) => SankhyaContext.GetFile(key, SessionToken);

    public static Task<ServiceFile> GetFileAsync(string key) =>
        SankhyaContext.GetFileAsync(key, SessionToken);

    public static ServiceFile GetImage<T>(this T entity)
        where T : class, IEntity, new()
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var result = entity.ExtractKeys();
        return Context.GetImage(
            result.Name,
            result.Keys.ToDictionary(k => k.Name, k => (object)k.Value)
        );
    }

    public static Task<ServiceFile> GetImageAsync<T>(this T entity)
        where T : class, IEntity, new()
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var result = entity.ExtractKeys();
        return Context.GetImageAsync(
            result.Name,
            result.Keys.ToDictionary(k => k.Name, k => (object)k.Value)
        );
    }
}
