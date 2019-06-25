using PAYNLSDK.Enums;
using System;
using TransactionGetService = PAYNLSDK.API.Transaction.GetService.Request;
using TransactionInfo = PAYNLSDK.API.Transaction.Info.Request;
using TransactionRefund = PAYNLSDK.API.Transaction.Refund.Request;
using TransactionApprove = PAYNLSDK.API.Transaction.Approve.Request;
using TransactionDecline = PAYNLSDK.API.Transaction.Decline.Request;
using Newtonsoft.Json;
using System.Threading.Tasks;
using PAYNLSDK.Base;
using PAYNLSDK.Services;

namespace PAYNLSDK
{
    /// <summary>
    /// Generic Transaction service helper class.
    /// Makes calling PAYNL Services easier and illiminates the need to fully initiate all Request objects.
    /// </summary>
    public class Transaction : BaseClient
    {
        public Transaction(IClientService clientService)
            : base(clientService)
        {
        }

        /// <summary>
        /// Checks whether a transaction has a status of PAID
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if PAID, false otherwise</returns>
        public async Task<bool> IsPaidAsync(string transactionId)
        {
            try
            {
                var request = new TransactionInfo
                {
                    TransactionId = transactionId
                };

                await ClientService.PerformRequestAsync(request);
                return request.Response.PaymentDetails.State == PaymentStatus.PAID;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a PAID status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if PAID, false otherwise</returns>
        public bool IsPaid(PaymentStatus status)
        {
            try
            {
                return status == PaymentStatus.PAID;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a transaction has a status of CANCELLED
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if CANCELLED, false otherwise</returns>
        public async Task<bool> IsCancelledAsync(string transactionId)
        {
            try
            {
                var request = new TransactionInfo
                {
                    TransactionId = transactionId
                };

                await ClientService.PerformRequestAsync(request);

                return request.Response.PaymentDetails.State == PaymentStatus.CANCEL;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a CANCELLED status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if CANCELLED, false otherwise</returns>
        public bool IsCancelled(PaymentStatus status)
        {
            try
            {
                return status == PaymentStatus.CANCEL;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a transaction has a status of PENDING
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if PENDING, false otherwise</returns>
        public async Task<bool> IsPendingAsync(string transactionId)
        {
            try
            {
                var request = new TransactionInfo
                {
                    TransactionId = transactionId
                };

                await ClientService.PerformRequestAsync(request);

                return (request.Response.PaymentDetails.State == PaymentStatus.PENDING_1) ||
                    (request.Response.PaymentDetails.State == PaymentStatus.PENDING_2) ||
                    (request.Response.PaymentDetails.State == PaymentStatus.PENDING_3) ||
                    (request.Response.PaymentDetails.State == PaymentStatus.VERIFY) ||
                    (request.Response.PaymentDetails.StateName == "PENDING");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a PENDING status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if PENDING, false otherwise</returns>
        public bool IsPending(PaymentStatus status)
        {
            try
            {
                return (status == PaymentStatus.PENDING_1) ||
                    (status == PaymentStatus.PENDING_2) ||
                    (status == PaymentStatus.PENDING_3) ||
                    (status == PaymentStatus.VERIFY)
                    ;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a transaction has a status of VERIFY
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if VERIFY, false otherwise</returns>
        public async Task<bool> IsVerifyAsync(string transactionId)
        {
            try
            {
                var request = new TransactionInfo
                {
                    TransactionId = transactionId
                };

                await ClientService.PerformRequestAsync(request);

                return (request.Response.PaymentDetails.State == PaymentStatus.VERIFY) ||
                    (request.Response.PaymentDetails.StateName == "VERIFY");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a VERIFY status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if VERIFY, false otherwise</returns>
        public bool IsVerify(PaymentStatus status)
        {
            try
            {
                return status == PaymentStatus.VERIFY;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a REFUND or REFUNDING status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if REFUND or REFUNDING, false otherwise</returns>
        public bool IsRefund(PaymentStatus status)
        {
            try
            {
                return (status == PaymentStatus.REFUND) || (status == PaymentStatus.REFUNDING);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a REFUNDING status, meaning a refund is currently being processed.
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if REFUNDING, false otherwise</returns>
        public bool IsRefunding(PaymentStatus status)
        {
            try
            {
                return status == PaymentStatus.REFUNDING;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Query the service for all (current status) information on a transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response object with all information available</returns>
        public async Task<API.Transaction.Info.Response> InfoAsync(string transactionId)
        {
            var request = new TransactionInfo
            {
                TransactionId = transactionId
            };

            await ClientService.PerformRequestAsync(request);
            return request.Response;
        }

        /// <summary>
        /// Return service information.
        /// This API returns merchant info and all the available payment options per country for a given service.
        /// This is an important API if you want to build your own payment screens.
        /// </summary>
        /// <param name="paymentMethodId">Paymentmethod ID</param>
        /// <returns>FUll response with all service information</returns>
        public async Task<API.Transaction.GetService.Response> GetServiceAsync(PaymentMethodId? paymentMethodId)
        {
            var request = new TransactionGetService
            {
                PaymentMethodId = paymentMethodId
            };

            await ClientService.PerformRequestAsync(request);
            return request.Response;
        }

        /// <summary>
        /// Return service information.
        /// This API returns merchant info and all the available payment options per country for a given service.
        /// This is an important API if you want to build your own payment screens.
        /// </summary>
        /// <returns>FUll response with all service information</returns>
        public Task<API.Transaction.GetService.Response> GetServiceAsync() =>
            GetServiceAsync(null);

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="description">Reason for the refund. May be null.</param>
        /// <param name="amount">Amount of the refund. If null is given, it will be the full amount of the transaction.</param>
        /// <param name="processDate">Date to process the refund. May be null.</param>
        /// <returns>Full response including the Refund ID</returns>
        public async Task<API.Transaction.Refund.Response> RefundAsync(string transactionId, string description, int? amount, DateTime? processDate)
        {
            var request = new TransactionRefund
            {
                TransactionId = transactionId,
                Description = description,
                Amount = amount,
                ProcessDate = processDate
            };

            await ClientService.PerformRequestAsync(request);
            return request.Response;
        }

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="description">Reason for the refund. May be null.</param>
        /// <param name="amount">Amount of the refund. If null is given, it will be the full amount of the transaction.</param>
        /// <returns>Full response including the Refund ID</returns>
        public Task<API.Transaction.Refund.Response> RefundAsync(string transactionId, string description, int? amount) =>
            RefundAsync(transactionId, description, amount, null);

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="description">Reason for the refund. May be null.</param>
        /// <returns>Full response including the Refund ID</returns>
        public Task<API.Transaction.Refund.Response> RefundAsync(string transactionId, string description) =>
            RefundAsync(transactionId, description, null, null);

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction.
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response including the Refund ID</returns>
        public Task<API.Transaction.Refund.Response> RefundAsync(string transactionId) =>
            RefundAsync(transactionId, null, null, null);

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="description">Reason for the refund. May be null.</param>
        /// <param name="amount">Amount of the refund. If null is given, it will be the full amount of the transaction.</param>
        /// <param name="processDate">Date to process the refund. May be null.</param>
        /// <param name="exchangeUrl">The url to send notifications to on changes in this refund.</param>
        /// <returns>Full response including the Refund ID</returns>
        public async Task<API.Transaction.Refund.Response> RefundAsync(string transactionId, string description, int? amount, DateTime? processDate, string exchangeUrl)
        {
            // Unable to reuse existing method for refunding,  since this specific case needs to be done with different Request 
            // API.Transaction.Refund.Request vs. API.Refund.Transaction.Request (already existing in code, we simply use this here)

            var request = new API.Refund.Transaction.Request(transactionId)
            {
                TransactionId = transactionId,
                Description = description,
                Amount = amount,
                ProcessDate = processDate,
                ExchangeUrl = exchangeUrl
            };

            await ClientService.PerformRequestAsync(request);
            // We will convert the response to a PAYNLSDK.API.Transaction.Refund.Response so we stay in the same, original, namespace.
            // We manage to get away with this because the API responses have the same definition.
            return JsonConvert.DeserializeObject<API.Transaction.Refund.Response>(request.RawResponse);
        }

        /// <summary>
        /// function to approve a suspicious transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response including the message about the approvement</returns>
        public async Task<API.Transaction.Approve.Response> ApproveAsync(string transactionId)
        {
            var request = new TransactionApprove
            {
                TransactionId = transactionId
            };

            await ClientService.PerformRequestAsync(request);
            return request.Response;
        }

        /// <summary>
        /// function to decline a suspicious transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response including the message about the decline</returns>
        public async Task<API.Transaction.Decline.Response> DeclineAsync(string transactionId)
        {
            var request = new TransactionDecline
            {
                TransactionId = transactionId
            };

            await ClientService.PerformRequestAsync(request);
            return request.Response;
        }

        /// <summary>
        /// Creates a transaction start request.
        /// </summary>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
        /// <param name="paymentSubOptionId">	In case of an iDEAL payment this is the ID of the bank (see the paymentOptionSubList in the getService function).</param>
        /// <param name="testMode">	Whether or not we perform this call in test mode.</param>
        /// <param name="transferType">TransferType for this transaction (merchant/transaction)</param>
        /// <param name="transferValue">TransferValue eg MerchantId (M-xxxx-xxxx) or orderId</param>
        /// <returns>Transaction Start Request</returns>
        public API.Transaction.Start.Request CreateTransactionRequest(string ipAddress, string returnUrl, int? paymentOptionId, int? paymentSubOptionId, bool? testMode, string transferType, string transferValue)
        {
            var request = new API.Transaction.Start.Request
            {
                Amount = 0,
                IPAddress = ipAddress,
                ReturnUrl = returnUrl,
                PaymentOptionId = paymentOptionId,
                PaymentOptionSubId = paymentSubOptionId,
                TestMode = testMode,
                TransferType = transferType,
                TransferValue = transferValue
            };
            return request;
        }

        /// <summary>
        /// Creates a transaction start request.
        /// </summary>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
        /// <param name="paymentSubOptionId">	In case of an iDEAL payment this is the ID of the bank (see the paymentOptionSubList in the getService function).</param>
        /// <param name="testMode">	Whether or not we perform this call in test mode.</param>
        /// <returns>Transaction Start Request</returns>
        public API.Transaction.Start.Request CreateTransactionRequest(string ipAddress, string returnUrl, int? paymentOptionId, int? paymentSubOptionId, bool? testMode)
        {
            var request = new API.Transaction.Start.Request
            {
                Amount = 0,
                IPAddress = ipAddress,
                ReturnUrl = returnUrl,
                PaymentOptionId = paymentOptionId,
                PaymentOptionSubId = paymentSubOptionId,
                TestMode = testMode
            };
            return request;
        }

        /// <summary>
        /// <para>Creates a transaction start request.</para>
        /// <para>Test Mode will be defaulted to FALSE.</para>
        /// </summary>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
        /// <param name="paymentSubOptionId">	In case of an iDEAL payment this is the ID of the bank (see the paymentOptionSubList in the getService function).</param>
        /// <returns>Transaction Start Request</returns>
        public API.Transaction.Start.Request CreateTransactionRequest(string ipAddress, string returnUrl, int? paymentOptionId, int? paymentSubOptionId)
        {
            return CreateTransactionRequest(ipAddress, returnUrl, paymentOptionId, paymentSubOptionId, false);
        }

        /// <summary>
        /// <para>Creates a transaction start request.</para>
        /// <para>Test Mode will be defaulted to FALSE.</para>
        /// </summary>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
        /// <returns>Transaction Start Request</returns>
        public API.Transaction.Start.Request CreateTransactionRequest(string ipAddress, string returnUrl, int paymentOptionId)
        {
            return CreateTransactionRequest(ipAddress, returnUrl, paymentOptionId, null, false);
        }

        /// <summary>
        /// <para>Creates a transaction start request.</para>
        /// <para>Test Mode will be defaulted to FALSE.</para>
        /// </summary>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <returns>Transaction Start Request</returns>
        public API.Transaction.Start.Request CreateTransactionRequest(string ipAddress, string returnUrl)
        {
            return CreateTransactionRequest(ipAddress, returnUrl, null, null, false);
        }

        /// <summary>
        /// Performs a request to start a transaction.
        /// </summary>
        /// <returns>Full response object including Transaction ID</returns>
        public async Task<API.Transaction.Start.Response> StartAsync(API.Transaction.Start.Request request)
        {
            await ClientService.PerformRequestAsync(request);
            return request.Response;
        }
    }
}
