using System;
using PAYNLSDK.API.Transaction.Approve;
using PAYNLSDK.API.Transaction.Decline;
using PAYNLSDK.API.Transaction.GetService;
using PAYNLSDK.API.Transaction.Info;
using PAYNLSDK.API.Transaction.Refund;
using PAYNLSDK.API.Transaction.Start;
using PAYNLSDK.Enums;

namespace PAYNLSDK
{
    public interface ITransaction
    {
        API.Transaction.Approve.Response Approve(string transactionId);
        API.Transaction.Decline.Response Decline(string transactionId);
        API.Transaction.GetService.Response GetService();
        API.Transaction.GetService.Response GetService(PaymentMethodId? paymentMethodId);
        API.Transaction.Info.Response Info(string transactionId);
        bool IsCancelled(string transactionId);
        bool IsPaid(string transactionId);
        bool IsPending(string transactionId);
        bool IsVerify(string transactionId);
        API.Transaction.Refund.Response Refund(string transactionId);
        API.Transaction.Refund.Response Refund(string transactionId, string description);
        API.Transaction.Refund.Response Refund(string transactionId, string description, int? amount);
        API.Transaction.Refund.Response Refund(string transactionId, string description, int? amount, DateTime? processDate);
        API.Transaction.Start.Response Start(API.Transaction.Start.Request request);
    }
}