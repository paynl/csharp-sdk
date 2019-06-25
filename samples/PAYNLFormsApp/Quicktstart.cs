using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Extensions.Logging;
using PAYNLSDK.Enums;
using PAYNLSDK.Services;

namespace PAYNLFormsApp
{
    public class Quicktstart
    {
        public Quicktstart()
        {
            SimpleIoc.Default.Register(() => new LoggerFactory().CreateLogger(nameof(Quicktstart)));
            SimpleIoc.Default.Register<ISettingsService>(() => new SettingsService("e41f83b246b706291ea9ad798ccfd9f0fee5e0ab", "SL-3490-4320"));
            SimpleIoc.Default.Register<IWebProxy>(() => null);
            SimpleIoc.Default.Register<IClientService, ClientService>();
            SimpleIoc.Default.Register<IUtilityService, UtilityService>();
        }

        private Task<PAYNLSDK.API.Transaction.GetService.Response> GetAvailablePaymentsAsync()
        {
            //paymentMethodId: is optional
            //The ID of the payment method. Only the payment options linked to the provided payment method ID will be returned if an ID is provided.
            //If omitted, all available payment options are returned. Use the following IDs to filter the options:
            //1. SMS.
            //2. Pay fixed price.
            //3. Pay per call.
            //4. Pay per transaction
            //5. Pay per minute.
            PaymentMethodId? paymentMethodId = null;
            var transaction = new PAYNLSDK.Transaction(SimpleIoc.Default.GetInstance<IClientService>());
            return transaction.GetServiceAsync(paymentMethodId);
        }

        private Task<PAYNLSDK.API.Transaction.Start.Response> StartTransactionAsync()
        {
            var transaction = new PAYNLSDK.Transaction(SimpleIoc.Default.GetInstance<IClientService>());
            var request = transaction.CreateTransactionRequest("127.0.0.1", "http://example.org/visitor-return-after-payment");

            request.Amount = 621;

            // Optional values
            // Uncommented because not available in sdk!
            //options.store("paymentMethod", 10);
            //options.store("description", "demo payment");
            //options.store("language", "EN");

            // Transaction data
            request.Transaction = new PAYNLSDK.Objects.TransactionData
            {
                Currency = "EUR",
                CostsVat = null,
                OrderExchangeUrl = "https://example.org/exchange.php",
                Description = "TEST PAYMENT",
                ExpireDate = DateTime.Now.AddDays(14)
            };

            // Optional Stats data
            request.StatsData = new PAYNLSDK.Objects.StatsDetails
            {
                Info = "your information",
                Tool = "C#.NET",
                Extra1 = "X",
                Extra2 = "Y",
                Extra3 = "Z"
            };

            // Initialize Salesdata
            request.SalesData = new PAYNLSDK.Objects.SalesData
            {
                InvoiceDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                OrderData = new List<PAYNLSDK.Objects.OrderData>()
                {
                    // Add products
                    new PAYNLSDK.Objects.OrderData("SKU-8489", "Testproduct 1", 2995, "H", 1),
                    new PAYNLSDK.Objects.OrderData("SKU-8421", "Testproduct 2", 995, "H", 1),
                    new PAYNLSDK.Objects.OrderData("SKU-2359", "Testproduct 3", 2499, "H", 1)
                }
            };

            // enduser
            request.Enduser = new PAYNLSDK.Objects.EndUser
            {
                Language = "NL",
                Initials = "J.",
                Lastname = "Buyer",
                Gender = Gender.Male,
                BirthDate = new DateTime(1991, 1, 23, 0, 0, 0, DateTimeKind.Local),
                PhoneNumber = "0612345678",
                EmailAddress = "email@domain.com",
                BankAccount = "",
                IBAN = "NL08INGB0000000555",
                BIC = "",

                // enduser address
                Address = new PAYNLSDK.Objects.Address
                {
                    StreetName = "Streetname",
                    StreetNumber = "8",
                    ZipCode = "1234AB",
                    City = "City",
                    CountryCode = "NL"
                },

                // invoice address
                InvoiceAddress = new PAYNLSDK.Objects.Address
                {
                    Initials = "J.",
                    LastName = "Jansen",
                    Gender = Gender.Male,
                    StreetName = "InvoiceStreetname",
                    StreetNumber = "10",
                    ZipCode = "1234BC",
                    City = "City",
                    CountryCode = "NL"
                }
            };

            return transaction.StartAsync(request);
        }

        private async Task CheckIfTransactionIsPaidAsync()
        {
            var transaction = new PAYNLSDK.Transaction(SimpleIoc.Default.GetInstance<IClientService>());

            // Perform transaction to get response object. Alternately, you could work with a stored ID....
            var response = new PAYNLSDK.API.Transaction.Start.Response();

            var info = await transaction.InfoAsync(response.Transaction.TransactionId);
            var result = info.PaymentDetails.State;

            if (transaction.IsPaid(result) || transaction.IsPending(result))
            {
                // redirect user to thank you page
            }
            else
            {
                // it has not been paid yet, so redirect user back to checkout
            }
        }

        private async Task ExchangeAsync()
        {
            var transaction = new PAYNLSDK.Transaction(SimpleIoc.Default.GetInstance<IClientService>());

            // Perform transaction to get response object. Alternately, you could work with a stored ID....
            var response = new PAYNLSDK.API.Transaction.Start.Response();

            var info = await transaction.InfoAsync(response.Transaction.TransactionId);
            var result = info.PaymentDetails.State;

            if (transaction.IsPaid(result))
            {
                // process the payment
            }
            else
            {
                if (transaction.IsCancelled(result))
                {
                    // payment canceled, restock items
                }
            }

            // response.Write("TRUE| ");
            // Optionally you can send a message after TRUE|, you can view these messages in the logs.
            // https://admin.pay.nl/logs/payment_state
            // response.Write("Paid");
        }
    }
}
