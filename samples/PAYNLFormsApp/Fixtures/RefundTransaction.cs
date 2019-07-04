using System;
using PAYNLSDK.API.Refund.Transaction;

namespace PAYNLFormsApp.Fixtures
{
    public class RefundTransaction
    {
        static public Request GetFixture()
        {
            var request = GetFixtureNoProductLines();
            request.AddProduct("SKU-8489", 1);
            request.AddProduct("SKU-8421", 2);
            request.AddProduct("SKU-2359", 3);

            return request;
        }

        static public Request GetFixtureNoProductLines()
        {
            var request = new Request("abcedef")
            {
                Amount = 6489,
                Description = "Transaction refund test description",
                ProcessDate = new DateTime(2018, 07, 15, 0, 0, 0, DateTimeKind.Local),
                ExchangeUrl = "https://www.example.com/callbacktransactionrefund"
            };

            return request;
        }
    }
}
