using System;
using PAYNLSDK.API.Transaction.Start;
using PAYNLSDK;
using PAYNLSDK.Enums;

namespace PAYNLFormsApp.Fixtures
{
    public class TransactionStart
    {
        static public Request GetFixture()
        {
            Request request = GetFixtureNoProductLines();

            request.Enduser.InvoiceAddress = new PAYNLSDK.Objects.Address();
            request.Enduser.InvoiceAddress.Initials = "J.";
            request.Enduser.InvoiceAddress.LastName = "Jansen";
            request.Enduser.InvoiceAddress.Gender = Gender.Male;
            request.Enduser.InvoiceAddress.StreetName = "Dam Bustersstraat";
            request.Enduser.InvoiceAddress.StreetNumber = "8";
            request.Enduser.InvoiceAddress.ZipCode = "4651SJ";
            request.Enduser.InvoiceAddress.City = "Steenbergen";
            request.Enduser.InvoiceAddress.CountryCode = "NL";

            // Sale data
            request.SalesData = new PAYNLSDK.Objects.SalesData();
            request.SalesData.InvoiceDate = DateTime.Now;
            request.SalesData.DeliveryDate = DateTime.Now;
            request.SalesData.OrderData = new System.Collections.Generic.List<PAYNLSDK.Objects.OrderData>();
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-8489", 2995));
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-8421", 995));
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-2359", 2499));

            return request;
        }

        static public Request GetFixtureNoProductLines()
        {
            Request request = Transaction.CreateTransactionRequest("37.143.38.31", "https://pay.nl/return.php", 10, 0, true);
            request.Amount = 6489;

            // transaction
            request.TransactionData = new PAYNLSDK.Objects.TransactionData();
            request.TransactionData.Currency = "EUR";
            request.TransactionData.CostsVat = null;
            request.TransactionData.OrderExchangeUrl = "https://pay.nl/exchange.php";
            request.TransactionData.Description = "TEST PAYMENT FIXTURE";
            request.TransactionData.ExpireDate = DateTime.Now.AddDays(14);
            //request.Transaction.EnduserId = null;
            //request.Transaction.ExcludeCosts = null;
            //request.Transaction.SendReminderEmail = null;
            //request.Transaction.ReminderMailTemplateId = null;

            // statsdata
            request.StatsData = new PAYNLSDK.Objects.StatsDetails();
            request.StatsData.PromotorId = null;
            request.StatsData.Info = "c-12345";
            request.StatsData.Tool = "C#.NET";
            request.StatsData.Extra1 = "X-ref-1234";
            request.StatsData.Extra2 = "X-stat-9817";
            request.StatsData.Extra3 = "X-pid-924";
            //request.StatsData.TransferData = "XtransId nj35g890hef8ybh9871g35rgh";

            // enduser
            request.Enduser = new PAYNLSDK.Objects.EndUser();
            request.Enduser.Language = "NL";
            request.Enduser.Initials = "J.";
            request.Enduser.Lastname = "Jansen";
            request.Enduser.Gender = PAYNLSDK.Enums.Gender.Male;
            request.Enduser.BirthDate = new DateTime(1991, 1, 23, 0, 0, 0, DateTimeKind.Local);
            request.Enduser.PhoneNumber = "0612345678";
            request.Enduser.EmailAddress = "support@pay.nl";
            request.Enduser.BankAccount = "";
            request.Enduser.IBAN = "NL08INGB0000000555";
            request.Enduser.BIC = "";
            //request.Enduser.AccessCode = "ab12345";
            //request.Enduser.SendConfirmMail = false;
            //request.Enduser.ConfirmMailTemplate = "";

            request.Enduser.Address = new PAYNLSDK.Objects.Address();
            request.Enduser.Address.StreetName = "Dam Bustersstraat";
            request.Enduser.Address.StreetNumber = "8";
            request.Enduser.Address.ZipCode = "4651SJ";
            request.Enduser.Address.City = "Steenbergen";
            request.Enduser.Address.CountryCode = "NL";

            return request;
        }

    }
}
