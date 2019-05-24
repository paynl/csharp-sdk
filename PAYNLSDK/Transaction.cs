using PAYNLSDK.Enums;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Net;
using System;
using TransactionGetService = PAYNLSDK.API.Transaction.GetService.Request;
using TransactionInfo = PAYNLSDK.API.Transaction.Info.Request;
using TransactionRefund = PAYNLSDK.API.Transaction.Refund.Request;
using TransactionApprove = PAYNLSDK.API.Transaction.Approve.Request;
using TransactionDecline = PAYNLSDK.API.Transaction.Decline.Request;

namespace PAYNLSDK
{
    /// <summary>
    /// Generic Transaction service helper class.
    /// Makes calling PAYNL Services easier and illiminates the need to fully initiate all Request objects.
    /// </summary>
    public class Transaction : ITransaction
    {

        private readonly IClient _webClient;

        public Transaction(IClient webClient)
        {
            _webClient = webClient;
        }


        /// <summary>
        /// Checks whether a transaction has a status of PAID
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if PAID, false otherwise</returns>
        public bool IsPaid(string transactionId)
        {
            try
            {
                TransactionInfo request = new TransactionInfo();
                request.TransactionId = transactionId;
                _webClient.PerformRequest(request);
                return (request.Response.PaymentDetails.State == Enums.PaymentStatus.PAID);
            }
            catch (PayNlException e)
            {
                return false;
            }
        }


        /// <summary>
        /// Checks whether a transaction has a status of CANCELLED
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if CANCELLED, false otherwise</returns>
        public bool IsCancelled(string transactionId)
        {
            try
            {
                TransactionInfo request = new TransactionInfo();
                request.TransactionId = transactionId;
                _webClient.PerformRequest(request);
                return (request.Response.PaymentDetails.State == Enums.PaymentStatus.CANCEL);
            }
            catch (PayNlException e)
            {
                return false;
            }
        }



        /// <summary>
        /// Checks whether a transaction has a status of PENDING
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if PENDING, false otherwise</returns>
        public bool IsPending(string transactionId)
        {
            try
            {
                TransactionInfo request = new TransactionInfo();
                request.TransactionId = transactionId;

                _webClient.PerformRequest(request);
                return ((request.Response.PaymentDetails.State == Enums.PaymentStatus.PENDING_1) ||
                    (request.Response.PaymentDetails.State == Enums.PaymentStatus.PENDING_2) ||
                    (request.Response.PaymentDetails.State == Enums.PaymentStatus.PENDING_3) ||
                    (request.Response.PaymentDetails.State == Enums.PaymentStatus.VERIFY) ||
                    (request.Response.PaymentDetails.StateName == "PENDING"));
            }
            catch (PayNlException e)
            {
                return false;
            }
        }



        /// <summary>
        /// Checks whether a transaction has a status of VERIFY
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if VERIFY, false otherwise</returns>
        public bool IsVerify(string transactionId)
        {
            try
            {
                TransactionInfo request = new TransactionInfo();
                request.TransactionId = transactionId;

                _webClient.PerformRequest(request);
                return ((request.Response.PaymentDetails.State == Enums.PaymentStatus.VERIFY) ||
                    (request.Response.PaymentDetails.StateName == "VERIFY"));
            }
            catch (PayNlException e)
            {
                return false;
            }
        }



        /// <summary>
        /// Checks whether a status is a REFUND or REFUNDING status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if REFUND or REFUNDING, false otherwise</returns>
        static public bool IsRefund(Enums.PaymentStatus status)
        {
            try
            {
                return ((status == Enums.PaymentStatus.REFUND) || (status == Enums.PaymentStatus.REFUNDING));
            }
            catch (ErrorException e)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a REFUNDING status, meaning a refund is currently being processed.
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if REFUNDING, false otherwise</returns>
        static public bool IsRefunding(Enums.PaymentStatus status)
        {
            try
            {
                return ((status == Enums.PaymentStatus.REFUNDING));
            }
            catch (ErrorException e)
            {
                return false;
            }
        }

        /// <summary>
        /// Query the service for all (current status) information on a transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response object with all information available</returns>
        public PAYNLSDK.API.Transaction.Info.Response Info(string transactionId)
        {
            TransactionInfo request = new TransactionInfo { TransactionId = transactionId };

            _webClient.PerformRequest(request);
            return request.Response;
        }

        /// <summary>
        /// Return service information.
        /// This API returns merchant info and all the available payment options per country for a given service.
        /// This is an important API if you want to build your own payment screens.
        /// </summary>
        /// <param name="paymentMethodId">Paymentmethod ID</param>
        /// <returns>FUll response with all service information</returns>
        public PAYNLSDK.API.Transaction.GetService.Response GetService(PaymentMethodId? paymentMethodId)
        {
            TransactionGetService request = new TransactionGetService();
            request.PaymentMethodId = paymentMethodId;

            _webClient.PerformRequest(request);
            return request.Response;
        }

        /// <summary>
        /// Return service information.
        /// This API returns merchant info and all the available payment options per country for a given service.
        /// This is an important API if you want to build your own payment screens.
        /// </summary>
        /// <returns>FUll response with all service information</returns>
        public PAYNLSDK.API.Transaction.GetService.Response GetService()
        {
            return GetService(null);
        }

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="description">Reason for the refund. May be null.</param>
        /// <param name="amount">Amount of the refund. If null is given, it will be the full amount of the transaction.</param>
        /// <param name="processDate">Date to process the refund. May be null.</param>
        /// <returns>Full response including the Refund ID</returns>
        public PAYNLSDK.API.Transaction.Refund.Response Refund(string transactionId, string description, int? amount, DateTime? processDate)
        {
            TransactionRefund request = new TransactionRefund();
            request.TransactionId = transactionId;
            request.Description = description;
            request.Amount = amount;
            request.ProcessDate = processDate;

            _webClient.PerformRequest(request);
            return request.Response;
        }

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="description">Reason for the refund. May be null.</param>
        /// <param name="amount">Amount of the refund. If null is given, it will be the full amount of the transaction.</param>
        /// <returns>Full response including the Refund ID</returns>
        public PAYNLSDK.API.Transaction.Refund.Response Refund(string transactionId, string description, int? amount)
        {
            return Refund(transactionId, description, amount, null);
        }

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="description">Reason for the refund. May be null.</param>
        /// <returns>Full response including the Refund ID</returns>
        public PAYNLSDK.API.Transaction.Refund.Response Refund(string transactionId, string description)
        {
            return Refund(transactionId, description, null, null);
        }

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction.
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response including the Refund ID</returns>
        public PAYNLSDK.API.Transaction.Refund.Response Refund(string transactionId)
        {
            return Refund(transactionId, null, null, null);
        }

        /// <summary>
        /// function to approve a suspicious transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response including the message about the approvement</returns>
        public PAYNLSDK.API.Transaction.Approve.Response Approve(string transactionId)
        {
            TransactionApprove request = new TransactionApprove();
            request.TransactionId = transactionId;

            _webClient.PerformRequest(request);
            return request.Response;
        }

        /// <summary>
        /// function to decline a suspicious transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response including the message about the decline</returns>
        public PAYNLSDK.API.Transaction.Decline.Response Decline(string transactionId)
        {
            TransactionDecline request = new TransactionDecline();
            request.TransactionId = transactionId;

            _webClient.PerformRequest(request);
            return request.Response;
        }


        /// <summary>
        /// Creates a transaction start request model
        /// </summary>
        /// <param name="amount">The amount.  Will be rounded at 2 digits after comma.</param>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
        /// <param name="paymentSubOptionId">	In case of an iDEAL payment this is the ID of the bank (see the paymentOptionSubList in the getService function).</param>
        /// <param name="testMode">	Whether or not we perform this call in test mode.</param>
        /// <param name="transferType">TransferType for this transaction (merchant/transaction)</param>
        /// <param name="transferValue">TransferValue eg MerchantId (M-xxxx-xxxx) or orderId</param>
        /// <returns>Transaction Start Request</returns>
        public static PAYNLSDK.API.Transaction.Start.Request CreateTransactionRequest(decimal amount, string ipAddress, string returnUrl, int? paymentOptionId = null, int? paymentSubOptionId = null, bool testMode = false, string transferType = null, string transferValue = null)
        {
            var request = new API.Transaction.Start.Request
            {
                Amount = (int)Math.Round(amount * 100),
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
        /// Performs a request to start a transaction.
        /// </summary>
        /// <returns>Full response object including Transaction ID</returns>
        public PAYNLSDK.API.Transaction.Start.Response Start(PAYNLSDK.API.Transaction.Start.Request request)
        {

            _webClient.PerformRequest(request);
            return request.Response;
        }
    }
}
