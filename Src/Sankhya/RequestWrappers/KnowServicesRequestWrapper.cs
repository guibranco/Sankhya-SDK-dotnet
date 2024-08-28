using System.ComponentModel;
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
    /// <summary>
    /// The Sankhya context.
    /// </summary>
    private static readonly SankhyaContext Context = ServiceLocator.Resolve<SankhyaContext>();

    /// <summary>
    /// The session token.
    /// </summary>
    private static readonly Guid SessionToken = Context.AcquireNewSession(
        ServiceRequestType.KnowServices
    );

    /// <summary>
    /// The last time message received.
    /// </summary>
    private static DateTime _lastTimeMessageReceived;

    /// <summary>
    /// Gets the sessions.
    /// </summary>
    /// <returns>IEnumerable&lt;Session&gt;.</returns>
    public static IEnumerable<Session> GetSessions()
    {
        var request = new ServiceRequest(ServiceName.SessionGetAll);
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        return response.ResponseBody.Sessions.Sessions;
    }

    /// <summary>
    /// Terminates a user session identified by the specified session ID.
    /// </summary>
    /// <param name="sessionId">The unique identifier of the session to be terminated.</param>
    /// <remarks>
    /// This method creates a service request to kill a session using the provided <paramref name="sessionId"/>.
    /// It constructs a new instance of <see cref="ServiceRequest"/> with the service name set to <see cref="ServiceName.SessionKill"/>.
    /// The request body is populated with the session information, specifically the session ID.
    /// Finally, it invokes the service using the <see cref="SankhyaContext.ServiceInvoker"/> method, passing in the constructed request and the current session token.
    /// This operation is typically used to log out a user or to invalidate a session for security purposes.
    /// </remarks>
    public static void KillSession(string sessionId)
    {
        var request = new ServiceRequest(ServiceName.SessionKill)
        {
            RequestBody = new() { Session = new() { Id = sessionId } },
        };
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    /// <summary>
    /// Sends a warning message to specified recipients with a given title, description, and tip.
    /// </summary>
    /// <param name="title">The title of the warning message.</param>
    /// <param name="description">The detailed description of the warning.</param>
    /// <param name="tip">An optional tip or advice related to the warning.</param>
    /// <param name="level">The importance level of the warning.</param>
    /// <param name="recipients">An optional collection of recipients to whom the warning will be sent. If null, the warning will be sent to all users.</param>
    /// <remarks>
    /// This method constructs a service request to send a warning message using the specified parameters.
    /// The warning includes a title, description, and an optional tip that provides additional context or advice.
    /// The importance level of the warning is also specified, which can help recipients prioritize their response.
    /// If a collection of recipients is provided, the warning will be sent only to those individuals; otherwise, it will be sent to all users.
    /// The method logs the action of sending the warning for informational purposes and invokes the service to process the request.
    /// </remarks>
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

    /// <summary>
    /// Sends a message to a collection of system warning recipients.
    /// </summary>
    /// <param name="content">The content of the message to be sent.</param>
    /// <param name="recipients">An optional collection of recipients to whom the message will be sent. If null or empty, the message will be sent without specific recipients.</param>
    /// <remarks>
    /// This method constructs a service request to send a message with the specified content.
    /// If a collection of recipients is provided and contains any elements, those recipients will be included in the message request.
    /// The method logs the action of sending the message, indicating the number of recipients involved or specifying that the message is sent to all if no specific recipients are provided.
    /// Finally, it invokes the service to send the message using the specified session token.
    /// </remarks>
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

    /// <summary>
    /// Receives messages from a service and returns the response as a string.
    /// </summary>
    /// <remarks>
    /// This method constructs a service request to receive warning messages. It initializes the request with the last notification time
    /// and logs the action of receiving messages. The request is then sent to the service using the service invoker, and the last
    /// time a message was received is updated to the current time. Finally, the method retrieves and returns the serialized response
    /// from the service.
    /// </remarks>
    /// <exception cref="ServiceException">Thrown when there is an issue with the service request or response.</exception>
    /// <returns>A string representing the serialized response from the service.</returns>
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

    /// <summary>
    /// Creates an invoice with the specified header and optional items.
    /// </summary>
    /// <param name="invoiceHeader">The header information for the invoice. This parameter cannot be null.</param>
    /// <param name="invoiceItems">An optional collection of items to be included in the invoice. If not provided, the invoice will be created without items.</param>
    /// <returns>The primary key of the created invoice as an integer.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="invoiceHeader"/> is null.</exception>
    /// <remarks>
    /// This method constructs a service request to create an invoice using the provided <paramref name="invoiceHeader"/>
    /// and an optional list of <paramref name="invoiceItems"/>. If the <paramref name="invoiceItems"/> parameter is
    /// provided, it will be added to the invoice request. The method logs the request details, including the operation
    /// type and the number of items included in the invoice. After sending the request to the service, it retrieves
    /// the response and returns the primary key of the newly created invoice. This primary key can be used for further
    /// operations related to the invoice.
    /// </remarks>
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

    /// <summary>
    /// Removes an invoice based on the provided single number.
    /// </summary>
    /// <param name="singleNumber">The unique identifier of the invoice to be removed.</param>
    /// <remarks>
    /// This method constructs a service request to remove an invoice from the system using the specified single number.
    /// It initializes a new instance of <see cref="ServiceRequest"/> with the service name <see cref="ServiceName.InvoiceRemove"/>
    /// and sets the request body to include the invoice details. The method logs the request for informational purposes
    /// and then invokes the service using <see cref="SankhyaContext.ServiceInvoker"/> with the current session token.
    /// This operation does not return any value and is intended to modify the state of the invoice in the system.
    /// </remarks>
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

    /// <summary>
    /// Adds invoice items to an existing invoice identified by a single number.
    /// </summary>
    /// <param name="singleNumber">The unique identifier for the invoice to which items will be added.</param>
    /// <param name="invoiceItems">A collection of <see cref="InvoiceItem"/> objects that represent the items to be added to the invoice.</param>
    /// <returns>The primary key sequence number of the updated invoice if successful; otherwise, returns 0.</returns>
    /// <remarks>
    /// This method constructs a service request to add the specified invoice items to an existing invoice.
    /// It first converts the provided <paramref name="invoiceItems"/> collection into an array if it is not already an array.
    /// A service request is then created with the necessary details, including the single number for the invoice and the items to be added.
    /// The method logs the action of adding items to the invoice, including the count of items being added.
    /// After sending the request to the service, it attempts to retrieve the primary key sequence from the response.
    /// If successful, it returns this sequence as an integer. If an exception occurs during this process, it is logged,
    /// and the method returns 0 to indicate failure.
    /// </remarks>
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

    /// <summary>
    /// Removes a collection of invoice items from the invoice.
    /// </summary>
    /// <param name="invoiceItems">An enumerable collection of <see cref="InvoiceItem"/> to be removed.</param>
    /// <remarks>
    /// This method first checks if all the invoice items belong to the same invoice by comparing their
    /// <see cref="InvoiceItem.SingleNumber"/> property. If any item does not match the first item's
    /// <see cref="SingleNumber"/>, an <see cref="InvalidOperationException"/> is thrown, indicating that
    /// all items must be from the same invoice.
    ///
    /// If the validation passes, a service request is created to remove the specified items from the
    /// invoice. The request is then sent to the service invoker for processing. Additionally, logging
    /// information is generated to track the deletion of items, including the number of items being
    /// deleted and their associated invoice number.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown when not all invoice items belong to the same invoice.
    /// </exception>
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

    /// <summary>
    /// Processes a billing operation and returns the resulting invoice value.
    /// </summary>
    /// <param name="singleNumber">The amount to be billed in the invoice.</param>
    /// <param name="codeOperationType">The type of operation to be performed on the billing.</param>
    /// <param name="type">The billing type that specifies how the invoice should be processed.</param>
    /// <param name="responseEvents">An output parameter that will contain the client events related to the billing operation.</param>
    /// <param name="series">An optional parameter that specifies the series for the billing type. If not provided, defaults to null.</param>
    /// <param name="requestEvents">An optional parameter that contains any client events to be included in the request.</param>
    /// <returns>The value of the generated invoice, or -1 if the operation failed or no invoice value is returned.</returns>
    /// <remarks>
    /// This method constructs a service request to process a billing operation using the specified parameters.
    /// It initializes a request with details such as the billing type, operation code, and invoice amount.
    /// If provided, it includes any client events from the request and handles optional series information.
    /// The method logs the request details for tracking purposes and invokes a service to process the billing.
    /// Upon receiving a response, it checks for any client events and populates the output parameter accordingly.
    /// Finally, it returns the invoice value if available, or -1 if there was an error in processing.
    /// </remarks>
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

    /// <summary>
    /// Confirms an invoice based on the provided single number.
    /// </summary>
    /// <param name="singleNumber">The unique identifier for the invoice to be confirmed.</param>
    /// <remarks>
    /// This method creates a service request to confirm an invoice. It sets up the request body with the necessary parameters, including
    /// confirmation flags and the single number for the invoice. The method logs the confirmation attempt and invokes the service
    /// to process the request. If an exception occurs during the service invocation, it checks the exception message to determine
    /// the type of error. If the error indicates that there are no items to confirm, it throws a <see cref="NoItemsConfirmInvoiceException"/>.
    /// If the invoice has already been confirmed, it does not throw an exception. For any other exceptions, it throws a
    /// <see cref="ConfirmInvoiceException"/>.
    /// </remarks>
    /// <exception cref="NoItemsConfirmInvoiceException">Thrown when attempting to confirm an invoice that has no associated products or services.</exception>
    /// <exception cref="ConfirmInvoiceException">Thrown when an error occurs during the confirmation of the invoice that is not related to prior confirmation.</exception>
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

    /// <summary>
    /// Flags a collection of invoice numbers as not pending.
    /// </summary>
    /// <param name="singleNumbers">An enumerable collection of invoice numbers to be flagged.</param>
    /// <remarks>
    /// This method takes an enumerable collection of integers representing invoice numbers and converts it into an array.
    /// It then creates a service request to flag these invoices as not pending by setting the request body with the provided invoice numbers.
    /// The method logs the request details, including the number of invoices being processed and their respective identifiers.
    /// Finally, it invokes the service to process the request using the provided session token.
    /// This operation is typically used to update the status of invoices in a financial system.
    /// </remarks>
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

    /// <summary>
    /// Retrieves a collection of invoice accompaniments based on the provided single numbers.
    /// </summary>
    /// <param name="singleNumbers">An enumerable collection of integers representing single numbers associated with invoices.</param>
    /// <returns>An enumerable collection of <see cref="Invoice"/> objects that correspond to the provided single numbers.</returns>
    /// <remarks>
    /// This method first converts the input enumerable of integers into an array for processing.
    /// It then creates a service request to fetch invoice accompaniments from a service,
    /// populating the request body with the single numbers.
    /// The method logs the request details, including the number of single numbers provided and their values.
    /// Finally, it invokes the service and returns the list of invoice accompaniments received in the response.
    /// This method assumes that the service being called is properly configured and that valid session tokens are available.
    /// </remarks>
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

    /// <summary>
    /// Cancels a list of invoices based on the provided single numbers and justification.
    /// </summary>
    /// <param name="singleNumbers">An enumerable collection of invoice numbers to be cancelled.</param>
    /// <param name="justification">A justification for cancelling the invoices.</param>
    /// <param name="singleNumbersNotCancelled">An output parameter that will contain the invoice numbers that were not cancelled.</param>
    /// <returns>The total number of invoices that were successfully cancelled.</returns>
    /// <remarks>
    /// This method constructs a service request to cancel invoices using the provided single numbers and justification.
    /// It logs the cancellation request details, including the number of invoices being cancelled and their respective numbers.
    /// After invoking the service, it processes the response to determine how many invoices were cancelled and which ones were not.
    /// The method returns the count of successfully cancelled invoices, while also providing an output parameter that lists any invoice numbers that could not be cancelled.
    /// This is useful for tracking and handling cases where certain invoices may not have been eligible for cancellation.
    /// </remarks>
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

    /// <summary>
    /// Binds an invoice with an order using the provided parameters.
    /// </summary>
    /// <param name="singleNumber">The unique identifier for the invoice.</param>
    /// <param name="codePartner">The code representing the partner associated with the invoice.</param>
    /// <param name="movementType">The type of movement associated with the invoice binding.</param>
    /// <remarks>
    /// This method creates a service request to bind an invoice with an order by populating the request body with the specified parameters.
    /// It logs the request details for tracking purposes and then invokes the service using the provided session token.
    /// The parameters include a unique single number for the invoice, a partner code, and a movement type that describes the nature of the transaction.
    /// This operation is essential for ensuring that invoices are correctly associated with their corresponding orders in the system.
    /// </remarks>
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

    /// <summary>
    /// Duplicates an invoice based on the provided parameters and returns the new invoice number.
    /// </summary>
    /// <param name="singleNumber">The single number of the invoice to be duplicated.</param>
    /// <param name="codeOperationType">The type of operation for the duplication process.</param>
    /// <param name="series">An optional series number for the duplicated invoice.</param>
    /// <param name="dateExit">An optional date indicating when the duplication should take effect.</param>
    /// <param name="shouldUpdatePrice">A boolean indicating whether to update the price during duplication.</param>
    /// <returns>The single number of the newly duplicated invoice.</returns>
    /// <remarks>
    /// This method creates a service request to duplicate an existing invoice identified by <paramref name="singleNumber"/>.
    /// It allows for optional parameters such as <paramref name="series"/> and <paramref name="dateExit"/> to customize the duplication process.
    /// The <paramref name="shouldUpdatePrice"/> parameter determines if the price of the duplicated invoice should be updated.
    /// The method logs the request and response details for tracking purposes, including information about the original and duplicated invoice numbers.
    /// If the duplication is successful, it returns the single number of the newly created invoice.
    /// </remarks>
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

    /// <summary>
    /// Sends a request to get fiscal invoice authorization for a collection of single invoice numbers.
    /// </summary>
    /// <param name="singleNumbers">An enumerable collection of integer invoice numbers for which authorization is requested.</param>
    /// <remarks>
    /// This method converts the input enumerable of invoice numbers into an array and constructs a service request to obtain authorization for the specified invoices.
    /// It logs the request details, including the number of invoices and their respective identifiers, before invoking the service to process the request.
    /// The service request is sent to the Sankhya context using the provided session token.
    /// This method does not return any value and is primarily used for its side effects of logging and invoking the service.
    /// </remarks>
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

    /// <summary>
    /// Generates a lot of invoices based on the provided single numbers.
    /// </summary>
    /// <param name="singleNumbers">An enumerable collection of integers representing single invoice numbers.</param>
    /// <remarks>
    /// This method takes a collection of single invoice numbers and prepares a service request to generate a lot of invoices.
    /// It first converts the input collection into an array for processing. Then, it creates a new instance of the
    /// <see cref="ServiceRequest"/> class, specifying the service name for generating lots. The request body is populated
    /// with the invoice details, including whether to return disapproved invoices and the list of single numbers.
    /// The method logs the request information, including the count of single numbers and their values, before invoking
    /// the service through the <see cref="SankhyaContext.ServiceInvoker"/> method. This operation does not return any value
    /// and is intended to perform an action based on the provided input.
    /// </remarks>
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

    /// <summary>
    /// Flags the specified financial numbers as payments paid for a given account code.
    /// </summary>
    /// <param name="financialNumbers">A collection of financial numbers to be flagged as paid.</param>
    /// <param name="codeAccount">The account code associated with the payments.</param>
    /// <remarks>
    /// This method constructs a service request to flag the provided financial numbers as payments paid.
    /// It first converts the input collection of financial numbers into a list for processing.
    /// The request is populated with various parameters, including the financial numbers list and account details.
    /// After logging the request information, it invokes the service to process the request.
    /// If an error occurs during the service invocation, a custom exception is thrown, encapsulating the original exception and relevant data.
    /// This method is essential for updating payment statuses in the system and ensuring accurate financial records.
    /// </remarks>
    /// <exception cref="MarkAsPaymentPaidException">
    /// Thrown when there is an error during the service invocation, providing details about the financial numbers and request.
    /// </exception>
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

    /// <summary>
    /// Reverses financial payments based on the provided financial numbers.
    /// </summary>
    /// <param name="financialNumbers">A collection of financial numbers to be reversed.</param>
    /// <remarks>
    /// This method takes an enumerable collection of financial numbers and processes each number to create a service request for reversing payments.
    /// It converts the input collection into a list if it is not already a list, ensuring that it can be iterated multiple times without performance issues.
    /// For each financial number, a new <see cref="ServiceRequest"/> is created with the service name set to <see cref="ServiceName.FinancialReversal"/>.
    /// The request body is populated with parameters including the financial number and other predefined values for recompose and revert all anticipation.
    /// The method logs the request information using <see cref="LogConsumer.Info"/> and invokes the service using <see cref="SankhyaContext.ServiceInvoker"/>.
    /// This process is repeated for each financial number in the collection.
    /// </remarks>
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

    /// <summary>
    /// Unlinks shipping information associated with a specified financial number.
    /// </summary>
    /// <param name="financialNumber">The financial number for which the shipping information should be unlinked.</param>
    /// <remarks>
    /// This method creates a service request to unlink shipping information for a given financial number.
    /// It logs the request for tracking purposes and invokes the service using the provided session token.
    /// If an error occurs during the service invocation, it catches the exception and throws a custom
    /// <see cref="UnlinkShippingException"/> that includes the financial number, the request details,
    /// and the original exception for further analysis.
    /// </remarks>
    /// <exception cref="UnlinkShippingException">
    /// Thrown when there is an error during the service invocation to unlink shipping information.
    /// </exception>
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

    /// <summary>
    /// Opens a file specified by the given path and returns a unique key associated with the file.
    /// </summary>
    /// <param name="path">The path of the file to be opened.</param>
    /// <returns>A string representing the unique key associated with the opened file.</returns>
    /// <remarks>
    /// This method creates a service request to open a file using the specified path. It constructs a request object with the necessary configuration,
    /// including the file path, and invokes a service to process the request. The response from the service contains a key that uniquely identifies
    /// the opened file, which is then returned by this method. This functionality is typically used in applications that require file handling
    /// operations through a service-oriented architecture.
    /// </remarks>
    public static string OpenFile(string path)
    {
        var request = new ServiceRequest(ServiceName.FileOpen)
        {
            RequestBody = { Config = new() { Path = path } },
        };
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        return response.ResponseBody.Key.Value;
    }

    /// <summary>
    /// Deletes files specified by the given paths.
    /// </summary>
    /// <param name="paths">An enumerable collection of file paths to be deleted.</param>
    /// <remarks>
    /// This method takes a collection of file paths and constructs a service request to delete the specified files.
    /// It first converts the enumerable collection into an array for processing.
    /// A service request is then created with the necessary parameters, including the paths to be deleted and client event information.
    /// The method logs the number of files being requested for deletion and invokes the service to perform the deletion operation.
    /// It is important to ensure that the provided paths are valid and accessible by the service.
    /// </remarks>
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

    /// <summary>
    /// Gets the file.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>ServiceFile.</returns>
    public static ServiceFile GetFile(string key) => SankhyaContext.GetFile(key, SessionToken);

    /// <summary>
    /// Gets the f ile.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>Task&lt;ServiceFile&gt;.</returns>
    public static Task<ServiceFile> GetFileAsync(string key) =>
        SankhyaContext.GetFileAsync(key, SessionToken);

    /// <summary>
    /// Gets the image of an item (entity) based on item keys.
    /// </summary>
    /// <typeparam name="T">The type parameter.</typeparam>
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
    /// <typeparam name="T">The type parameter.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>ServiceImage.</returns>
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
