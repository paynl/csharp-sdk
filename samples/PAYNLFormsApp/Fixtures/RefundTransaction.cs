using System;
using PAYNLSDK.API.Refund.Transaction;
using PAYNLSDK;
using PAYNLSDK.Enums;

namespace PAYNLFormsApp.Fixtures
{
    public class RefundTransaction
    {
        static public Request GetFixture()
        {
            Request request = GetFixtureNoProductLines();
            request.AddProduct("SKU-8489", 1);
            request.AddProduct("SKU-8421", 2);
            request.AddProduct("SKU-2359", 3);

            return request;
        }

        static public Request GetFixtureNoProductLines()
        {
            Request request = new Request("abcedef");
            request.Amount = 6489;
            request.Description = "Transaction refund test description";
            request.ProcessDate = new DateTime(2018, 07, 15, 0, 0, 0, DateTimeKind.Local);
            request.ExchangeUrl = "https://www.example.com/callbacktransactionrefund";

            return request;
        }

    }
}
