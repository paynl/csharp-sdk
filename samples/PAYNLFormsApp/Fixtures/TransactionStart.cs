using System;
using PAYNLSDK.API.Transaction.Start;
using PAYNLSDK;
using PAYNLSDK.Enums;

namespace PAYNLFormsApp.Fixtures
{
    public class TransactionStart
    {
        public Request GetFixture()
        {
            var request = GetFixtureNoProductLines();

            request.Enduser.InvoiceAddress = new PAYNLSDK.Objects.Address
            {
                Initials = "J.",
                LastName = "Jansen",
                Gender = Gender.Male,
                StreetName = "Dam Bustersstraat",
                StreetNumber = "8",
                ZipCode = "4651SJ",
                City = "Steenbergen",
                CountryCode = "NL"
            };

            // Sale data
            request.SalesData = new PAYNLSDK.Objects.SalesData
            {
                InvoiceDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                OrderData = new System.Collections.Generic.List<PAYNLSDK.Objects.OrderData>()
            };
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-8489", 2995));
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-8421", 995));
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-2359", 2499));

            return request;
        }

        public Request GetFixtureNoProductLines()
        {
            var request = new Transaction().CreateTransactionRequest("37.143.38.31", "https://pay.nl/return.php", 10, 0, true);
            request.Amount = 6489;

            // transaction
            request.Transaction = new PAYNLSDK.Objects.TransactionData
            {
                Currency = "EUR",
                CostsVat = null,
                OrderExchangeUrl = "https://pay.nl/exchange.php",
                Description = "TEST PAYMENT FIXTURE",
                ExpireDate = DateTime.Now.AddDays(14)
            };
            //request.Transaction.EnduserId = null;
            //request.Transaction.ExcludeCosts = null;
            //request.Transaction.SendReminderEmail = null;
            //request.Transaction.ReminderMailTemplateId = null;

            // statsdata
            request.StatsData = new PAYNLSDK.Objects.StatsDetails
            {
                PromotorId = null,
                Info = "c-12345",
                Tool = "C#.NET",
                Extra1 = "X-ref-1234",
                Extra2 = "X-stat-9817",
                Extra3 = "X-pid-924"
            };
            //request.StatsData.TransferData = "XtransId nj35g890hef8ybh9871g35rgh";

            // enduser
            request.Enduser = new PAYNLSDK.Objects.EndUser
            {
                Language = "NL",
                Initials = "J.",
                Lastname = "Jansen",
                Gender = PAYNLSDK.Enums.Gender.Male,
                BirthDate = new DateTime(1991, 1, 23, 0, 0, 0, DateTimeKind.Local),
                PhoneNumber = "0612345678",
                EmailAddress = "support@pay.nl",
                BankAccount = "",
                IBAN = "NL08INGB0000000555",
                BIC = "",
                //request.Enduser.AccessCode = "ab12345";
                //request.Enduser.SendConfirmMail = false;
                //request.Enduser.ConfirmMailTemplate = "";

                Address = new PAYNLSDK.Objects.Address
                {
                    StreetName = "Dam Bustersstraat",
                    StreetNumber = "8",
                    ZipCode = "4651SJ",
                    City = "Steenbergen",
                    CountryCode = "NL"
                }
            };

            return request;
        }

    }
}
