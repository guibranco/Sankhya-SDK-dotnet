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

/// <summary>
/// Class KnowServicesRequestWrapper.
/// </summary>
public static class KnowServicesRequestWrapper
{
    #region Private Members

    /// <summary>
    /// The Sankhya context.
    /// </summary>
    private static readonly SankhyaContext Context;

    /// <summary>
    /// The session token
    /// </summary>
    private static readonly Guid SessionToken;

    /// <summary>
    /// The last time message received
    /// </summary>
    private static DateTime _lastTimeMessageReceived;

    #endregion

    #region  ~Ctor

    /// <summary>
    /// Initializes static members of the <see cref="KnowServicesRequestWrapper" /> class.
    /// </summary>
    static KnowServicesRequestWrapper()
    {
        Context = ServiceLocator.Resolve<SankhyaContext>();
        SessionToken = Context.AcquireNewSession(ServiceRequestType.KnowServices);
    }

    #endregion

    #region Session Methods

    /// <summary>
    /// Gets the sessions.
    /// </summary>
    /// <returns>IEnumerable&lt;Session&gt;.</returns>
    public static IEnumerable<Session> GetSessions()
    {
        var request = new ServiceRequest(ServiceName.SessionGetAll);
        var response = Context.ServiceInvoker(request, SessionToken);
        return response.ResponseBody.Sessions.Sessions;
    }

    /// <summary>
    /// Kills the session.
    /// </summary>
    /// <param name="sessionId">The session identifier.</param>
    public static void KillSession(string sessionId)
    {
        var request = new ServiceRequest(ServiceName.SessionKill)
        {
            RequestBody = new() { Session = new() { Id = sessionId } }
        };
        Context.ServiceInvoker(request, SessionToken);
    }

    #endregion

    #region Communications Methods

    /// <summary>
    /// Sends the warning.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="description">The description.</param>
    /// <param name="tip">The tip.</param>
    /// <param name="level">The level.</param>
    /// <param name="recipients">The recipients.</param>
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
                    Title = title
                }
            }
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
        Context.ServiceInvoker(request, SessionToken);
    }

    /// <summary>
    /// Sends the message.
    /// </summary>
    /// <param name="content">The content.</param>
    /// <param name="recipients">The recipients.</param>
    public static void SendMessage(
        [Localizable(false)] string content,
        ICollection<SystemWarningRecipient> recipients = null
    )
    {
        var request = new ServiceRequest(ServiceName.MessageSend)
        {
            RequestBody = { SystemMessage = new() { Content = content } }
        };
        if (recipients != null && recipients.Any())
        {
            request.RequestBody.SystemMessage.Recipients = recipients.ToArray();
        }

        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_SendMessage_SendingMessage,
            recipients?.Count.ToString() ?? Resources.All
        );
        Context.ServiceInvoker(request, SessionToken);
    }

    /// <summary>
    /// Receives the messages pending reading.
    /// </summary>
    /// <returns>String.</returns>
    public static string ReceiveMessages()
    {
        var request = new ServiceRequest(ServiceName.WarningReceive)
        {
            RequestBody =
            {
                NotificationElem = new() { LastNotification = _lastTimeMessageReceived }
            }
        };
        LogConsumer.Info(Resources.KnowServicesRequestWrapper_ReceiveMessages_ReceivingMessages);
        var response = Context.ServiceInvoker(request, SessionToken);
        _lastTimeMessageReceived = DateTime.Now;
        return (string)response.GetSerializer();
    }

    #endregion

    #region Invoice

    /// <summary>
    /// Creates the invoice header.
    /// </summary>
    /// <param name="invoiceHeader">The invoice header.</param>
    /// <param name="invoiceItems">(Optional) The invoice items.</param>
    /// <returns>Int32.</returns>
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
            RequestBody = { Invoice = new() { Header = invoiceHeader } }
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
        var response = Context.ServiceInvoker(request, SessionToken);
        string singleNumber = response.ResponseBody.PrimaryKey.NUNOTA.ToString();
        return singleNumber.ToInt32();
    }

    /// <summary>
    /// Removes the invoice by it's single number.
    /// </summary>
    /// <param name="singleNumber">The single number.</param>
    public static void RemoveInvoice(int singleNumber)
    {
        var request = new ServiceRequest(ServiceName.InvoiceRemove)
        {
            RequestBody =
            {
                Invoices = new() { Invoice = new() { SingleNumberDuplication = singleNumber } }
            }
        };

        LogConsumer.Info(Resources.KnowServicesRequestWrapper_RemoveInvoice, singleNumber);
        Context.ServiceInvoker(request, SessionToken);
    }

    /// <summary>
    /// Adds the invoice items to a specific invoice by it's single number.
    /// </summary>
    /// <param name="singleNumber">The single number.</param>
    /// <param name="invoiceItems">The items.</param>
    /// <returns>Int32.</returns>
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
                        OnlineUpdate = true
                    }
                }
            }
        };

        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_AddInvoiceItems_AddingItemsToInvoice,
            items.Length,
            singleNumber,
            items.Length == 1 ? @"m" : Resources.ItemPluralSufix
        );

        var response = Context.ServiceInvoker(request, SessionToken);

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

    /// <summary>
    /// Removes the invoice items.
    /// </summary>
    /// <param name="invoiceItems">The invoice items.</param>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="InvalidOperationException">All items must be from the same invoice</exception>
    public static void RemoveInvoiceItems(IEnumerable<InvoiceItem> invoiceItems)
    {
        var items = invoiceItems as InvoiceItem[] ?? invoiceItems.ToArray();
        var first = items.First();
        if (
            !items.All(
                item => item.SingleNumber.HasValue && item.SingleNumber == first.SingleNumber
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
                    Items = new() { Items = items, OnlineUpdate = true }
                }
            }
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_RemoveInvoiceItems_DeletingItemsFromInvoice,
            items.Length,
            first.SingleNumber ?? 0,
            items.Length == 1 ? @"m" : Resources.ItemPluralSufix
        );
        Context.ServiceInvoker(request, SessionToken);
    }

    #endregion

    #region Invoice Operations

    /// <summary>
    /// Bills the specified single number.
    /// </summary>
    /// <param name="singleNumber">The single number.</param>
    /// <param name="codeOperationType">Type of the code operation.</param>
    /// <param name="type">The type.</param>
    /// <param name="responseEvents">The response events.</param>
    /// <param name="series">The serie.</param>
    /// <param name="requestEvents">The request events.</param>
    /// <returns>Int32.</returns>
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
                    OneInvoiceForEach = true
                }
            }
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
        var response = Context.ServiceInvoker(request, SessionToken);
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

    /// <summary>
    /// Confirms the invoice.
    /// </summary>
    /// <param name="singleNumber">The single number.</param>
    /// <exception cref="NoItemsConfirmInvoiceException">null</exception>
    /// <exception cref="ConfirmInvoiceException">null</exception>
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
                        new Prop { Name = @"br.com.utiliza.dtneg.servidor", Value = @"false" }
                    }
                }
            }
        };

        try
        {
            LogConsumer.Info(
                Resources.KnowServicesRequestWrapper_ConfirmInvoice_Confirming,
                singleNumber
            );
            Context.ServiceInvoker(request, SessionToken);
        }
        catch (Exception e)
        {
            if (
                e.Message.IndexOf(
                    @"confirmar sem produtos/serviços/mat.prima",
                    StringComparison.InvariantCultureIgnoreCase
                ) != -1
            )
            {
                throw new NoItemsConfirmInvoiceException(singleNumber, null, e);
            }

            if (
                e.Message.IndexOf(@"já foi confirmada", StringComparison.InvariantCultureIgnoreCase)
                == -1
            )
            {
                throw new ConfirmInvoiceException(singleNumber, null, e);
            }
        }
    }

    /// <summary>
    /// Flag invoices as not pending by it's single numbers
    /// </summary>
    /// <param name="singleNumbers">The single number of invoices to flag</param>
    public static void FlagInvoicesAsNotPending(IEnumerable<int> singleNumbers)
    {
        var singleNumbersArray = singleNumbers as int[] ?? singleNumbers.ToArray();
        var request = new ServiceRequest(ServiceName.InvoiceFlagAsNotPending)
        {
            RequestBody = { SingleNumbers = singleNumbersArray }
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_FlagInvoicesAsNotPending,
            singleNumbersArray.Length,
            singleNumbersArray.Length == 1 ? string.Empty : @"s",
            string.Join(@",", singleNumbersArray)
        );
        Context.ServiceInvoker(request, SessionToken);
    }

    /// <summary>
    /// Gets the invoice accompaniments.
    /// </summary>
    /// <param name="singleNumbers">The single numbers.</param>
    /// <returns>IEnumerable&lt;InvoiceAccompaniment&gt;.</returns>
    public static IEnumerable<Invoice> GetInvoiceAccompaniments(IEnumerable<int> singleNumbers)
    {
        var singleNumbersList = singleNumbers as int[] ?? singleNumbers.ToArray();
        var request = new ServiceRequest(ServiceName.InvoiceAccompaniments)
        {
            RequestBody = { Invoices = new() { SingleNumbers = singleNumbersList } }
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_GetInvoiceAccompaniments,
            singleNumbersList.Length,
            singleNumbersList.Length == 1 ? string.Empty : @"s",
            string.Join(@",", singleNumbersList)
        );
        var response = Context.ServiceInvoker(request, SessionToken);
        return response.ResponseBody.InvoiceAccompaniments.Invoices;
    }

    /// <summary>
    /// Cancels the invoices.
    /// </summary>
    /// <param name="singleNumbers">The single numbers.</param>
    /// <param name="justification">The justification.</param>
    /// <param name="singleNumbersNotCancelled">The single numbers that cannot be cancelled.</param>
    /// <returns>The quantity of invoices cancelled.</returns>
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
                    SingleNumbers = singleNumbersList
                }
            }
        };

        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_CancelInvoices_Canceling,
            singleNumbersList.Length,
            singleNumbersList.Length == 1 ? string.Empty : @"s",
            string.Join(@",", singleNumbersList)
        );
        var response = Context.ServiceInvoker(request, SessionToken);
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

    /// <summary>
    /// Binds the invoice with order.
    /// </summary>
    /// <param name="singleNumber">The single number.</param>
    /// <param name="codePartner">The code partner.</param>
    /// <param name="movementType">Type of the movement.</param>
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
                    MovementType = movementType
                }
            }
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_BindInvoiceWithOrder,
            singleNumber,
            codePartner,
            movementType.GetHumanReadableValue()
        );
        Context.ServiceInvoker(request, SessionToken);
    }

    /// <summary>
    /// Duplicates a invoice.
    /// </summary>
    /// <param name="singleNumber">The invoice single number to be duplicated.</param>
    /// <param name="codeOperationType">The code operation type of duplication.</param>
    /// <param name="series">(Optional) The invoice series of the duplication invoice.</param>
    /// <param name="dateExit">(Optional) The date of exit of the duplication invoice.</param>
    /// <param name="shouldUpdatePrice">(Optional) If should update the products prices in the duplication invoice.</param>
    /// <returns>Int32.</returns>
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
                    Invoice = new() { SingleNumberDuplication = singleNumber }
                }
            }
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
        var response = Context.ServiceInvoker(request, SessionToken);
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_DuplicateInvoice_Duplicated,
            response.ResponseBody.Invoices.Invoice.SingleNumberDuplicationSource,
            response.ResponseBody.Invoices.Invoice.SingleNumberDuplicationDestiny
        );
        return response.ResponseBody.Invoices.Invoice.SingleNumberDuplicationDestiny;
    }

    #endregion

    #region Fiscal Invoice Operations

    /// <summary>
    /// Gets the fiscal invoice authorization.
    /// </summary>
    /// <param name="singleNumbers">The single numbers.</param>
    public static void GetFiscalInvoiceAuthorization(IEnumerable<int> singleNumbers)
    {
        var singleNumbersLists = singleNumbers as int[] ?? singleNumbers.ToArray();
        var request = new ServiceRequest(ServiceName.NfeGetAuthorization)
        {
            RequestBody = { Invoices = new() { SingleNumbers = singleNumbersLists } }
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_GetFiscalInvoiceAuthorization,
            singleNumbersLists.Length,
            singleNumbersLists.Length == 1 ? string.Empty : @"s",
            string.Join(@",", singleNumbersLists)
        );
        Context.ServiceInvoker(request, SessionToken);
    }

    /// <summary>
    /// Generates the fiscal invoice lot.
    /// </summary>
    /// <param name="singleNumbers">The single numbers.</param>
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
                    SingleNumbers = singleNumbersLists
                }
            }
        };
        LogConsumer.Info(
            Resources.KnowServicesRequestWrapper_GenerateLot,
            singleNumbersLists.Length,
            singleNumbersLists.Length == 1 ? string.Empty : @"s",
            string.Join(@",", singleNumbersLists)
        );
        Context.ServiceInvoker(request, SessionToken);
    }

    #endregion

    #region Financial

    /// <summary>
    /// Flag as payment paid
    /// </summary>
    /// <param name="financialNumbers">The financial numbers.</param>
    /// <param name="codeAccount">The code account.</param>
    /// <exception cref="MarkAsPaymentPaidException"></exception>
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
                    //CorDespesa = @"16711680",
                    //CorReceita = @"255",
                    ChkUsaVenc = @"S",
                    ChkSubInf = @"S",
                    TipLancRec = @"24",
                    TopBaixaRec = @"801",
                    TipLancDesp = @"1",
                    TopBaixaDesp = @"800",
                    TemFiltroAntecipacaoBx = @"N",
                    ParamImprimeBoleto = @"false"
                }
            }
        };
        try
        {
            LogConsumer.Info(
                Resources.KnowServicesRequestWrapper_FlagAsPaymentsPaid,
                financialNumbersList.Count == 1 ? string.Empty : @"s",
                string.Join(@",", financialNumbersList)
            );
            Context.ServiceInvoker(request, SessionToken);
        }
        catch (Exception e)
        {
            throw new MarkAsPaymentPaidException(financialNumbersList, request, e);
        }
    }

    /// <summary>
    /// Reverses the payments.
    /// </summary>
    /// <param name="financialNumbers">The financial numbers.</param>
    public static void ReversePayments(IEnumerable<int> financialNumbers)
    {
        var financialNumbersList = financialNumbers as List<int> ?? financialNumbers.ToList();
        foreach (
            var request in financialNumbersList.Select(
                financialNumber =>
                    new ServiceRequest(ServiceName.FinancialReversal)
                    {
                        RequestBody =
                        {
                            Param = new()
                            {
                                FinancialNumber = financialNumber,
                                Recompose = @"undefined",
                                RevertAllAnticipation = @"undefined"
                            }
                        }
                    }
            )
        )
        {
            LogConsumer.Info(
                Resources.KnowServicesRequestWrapper_ReversePayments,
                request.RequestBody.Param.FinancialNumber
            );
            Context.ServiceInvoker(request, SessionToken);
        }
    }

    /// <summary>
    /// Unlink the shipping.
    /// </summary>
    /// <param name="financialNumber">The financial number.</param>
    /// <exception cref="UnlinkShippingException"></exception>
    public static void UnlinkShipping(int financialNumber)
    {
        var request = new ServiceRequest(ServiceName.UnlinkShipping)
        {
            RequestBody = { Param = new() { FinancialNumberUpperCase = financialNumber } }
        };

        try
        {
            LogConsumer.Info(Resources.KnowServicesRequestWrapper_UnlinkShipping, financialNumber);
            Context.ServiceInvoker(request, SessionToken);
        }
        catch (Exception e)
        {
            throw new UnlinkShippingException(financialNumber, request, e);
        }
    }

    #endregion

    #region Files

    /// <summary>
    /// Get a file on file repository based on it's path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>The key of the file</returns>
    public static string OpenFile(string path)
    {
        var request = new ServiceRequest(ServiceName.FileOpen)
        {
            RequestBody = { Config = new() { Path = path } }
        };
        var response = Context.ServiceInvoker(request, SessionToken);
        return response.ResponseBody.Key.Value;
    }

    /// <summary>
    /// Deletes files on file repository based on it's path.
    /// </summary>
    /// <param name="paths">The path to the file</param>
    public static void DeleteFiles(IEnumerable<string> paths)
    {
        var pathsArray = paths as string[] ?? paths.ToArray();
        var request = new ServiceRequest(ServiceName.FileDelete)
        {
            RequestBody =
            {
                Paths = pathsArray.Select(path => new Path { Value = path }).ToArray(),
                ClientEvents = new[]
                {
                    new ClientEvent { Text = @"br.com.sankhya.actionbutton.clientconfirm" }
                }
            }
        };
        LogConsumer.Info(Resources.KnowServicesRequestWrapper_DeleteFiles, pathsArray.Length);
        Context.ServiceInvoker(request, SessionToken);
    }

    /// <summary>
    /// Gets the file.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>ServiceFile.</returns>
    public static ServiceFile GetFile(string key) => Context.GetFile(key, SessionToken);

    /// <summary>
    /// Gets the f ile.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>Task&lt;ServiceFile&gt;.</returns>
    public static async Task<ServiceFile> GetFileAsync(string key) =>
        await Context.GetFileAsync(key, SessionToken).ConfigureAwait(false);

    #endregion

    #region Image

    /// <summary>
    /// Gets the image of an item (entity) based on item keys.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>ServiceImage.</returns>
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

    /// <summary>
    /// Gets the image of an item (entity) based on item keys.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>ServiceImage.</returns>
    public static async Task<ServiceFile> GetImageAsync<T>(this T entity)
        where T : class, IEntity, new()
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var result = entity.ExtractKeys();
        return await Context
            .GetImageAsync(result.Name, result.Keys.ToDictionary(k => k.Name, k => (object)k.Value))
            .ConfigureAwait(false);
    }

    #endregion
}
