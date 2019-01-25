[![paynl MyGet Build Status](https://www.myget.org/BuildSource/Badge/paynl?identifier=5abead8d-3d3f-417b-9a84-1e8af5953014)](https://www.myget.org/)
[![NuGet release](https://img.shields.io/nuget/v/RoodFluweel.PAYNLSDK.svg)](https://www.nuget.org/packages/RoodFluweel.PAYNLSDK/)
[![Build status](https://ci.appveyor.com/api/projects/status/tf7nerddjixwumn1?svg=true)](https://ci.appveyor.com/project/dampee/csharp-sdk)

# Pay.nl C# SDK

With this SDK you will be able to start transactions and retrieve transactions with
their status for the Pay.nl payment service provider.

## Installation

You can use this package as a nuget package: 

From nuget:
```shell
Install-Package RoodFluweel.PAYNLSDK
```

Or if you want bleeding edge:
```
PM> Install-Package RoodFluweel.PAYNLSDK -Source https://www.myget.org/F/paynl/api/v3/index.json
``` 

## Configuration

Setting the configuration:
```c#
var config = new PayNlConfiguration("e4test6b70code9adreplacef0fee5e0ab", "SL-1234-1234");
var client = new Client(payNlConfig);
```

## Usage of the GetService

Getting a list of available payment methods, use the Getservice.
```c#
var response = PAYNLSDK.Transaction.GetService(paymentMethodId);
//paymentMethodId: is optional
//The ID of the payment method. Only the payment options linked to the provided payment method ID will be returned if an ID is provided.
//If omitted, all available payment options are returned. Use the following IDs to filter the options:
//1. SMS.
//2. Pay fixed price.
//3. Pay per call.
//4. Pay per transaction
//5. Pay per minute.
```

## Starting a transaction

```c#

PAYNLSDK.API.Transaction.Start.Request request = PAYNLSDK.Transaction.CreateTransactionRequest("127.0.0.1", "http://example.org/visitor-return-after-payment");
request.Amount = 621;

// Optional values
options.store("paymentMethod", 10;
options.store("description", "demo payment";
options.store("language","EN";

// Transaction data
request.Transaction = new PAYNLSDK.Objects.TransactionData();
request.Transaction.Currency = "EUR";
request.Transaction.CostsVat = null;
request.Transaction.OrderExchangeUrl = "https://example.org/exchange.php";
request.Transaction.Description = "TEST PAYMENT";
request.Transaction.ExpireDate = DateTime.Now.AddDays(14);

// Optional Stats data
request.StatsData = new PAYNLSDK.Objects.StatsDetails();
request.StatsData.Info = "your information";
request.StatsData.Tool = "C#.NET";
request.StatsData.Extra1 = "X";
request.StatsData.Extra2 = "Y";
request.StatsData.Extra3 = "Z";

// Initialize Salesdata
request.SalesData = new PAYNLSDK.Objects.SalesData();
request.SalesData.InvoiceDate = DateTime.Now;
request.SalesData.DeliveryDate = DateTime.Now;
request.SalesData.OrderData = new System.Collections.Generic.List<PAYNLSDK.Objects.OrderData>();

// Add products
request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-8489", "Testproduct 1", 2995, "H", 1));
request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-8421", "Testproduct 2", 995, "H", 1));
request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-2359", "Testproduct 3", 2499, "H", 1));

// enduser
request.Enduser = new PAYNLSDK.Objects.EndUser();
request.Enduser.Language = "NL";
request.Enduser.Initials = "J.";
request.Enduser.Lastname = "Buyer";
request.Enduser.Gender = PAYNLSDK.Enums.Gender.Male;
request.Enduser.BirthDate = new DateTime(1991, 1, 23, 0, 0, 0, DateTimeKind.Local);
request.Enduser.PhoneNumber = "0612345678";
request.Enduser.EmailAddress = "email@domain.com";
request.Enduser.BankAccount = "";
request.Enduser.IBAN = "NL08INGB0000000555";
request.Enduser.BIC = "";

// enduser address
request.Enduser.Address = new PAYNLSDK.Objects.Address();
request.Enduser.Address.StreetName = "Streetname";
request.Enduser.Address.StreetNumber = "8";
request.Enduser.Address.ZipCode = "1234AB";
request.Enduser.Address.City = "City";
request.Enduser.Address.CountryCode = "NL";

// invoice address
request.Enduser.InvoiceAddress = new PAYNLSDK.Objects.Address();
request.Enduser.InvoiceAddress.Initials = "J.";
request.Enduser.InvoiceAddress.LastName = "Jansen";
request.Enduser.InvoiceAddress.Gender = PAYLSDK.Enums.Gender.Male;
request.Enduser.InvoiceAddress.StreetName = "InvoiceStreetname";
request.Enduser.InvoiceAddress.StreetNumber = "10";
request.Enduser.InvoiceAddress.ZipCode = "1234BC";
request.Enduser.InvoiceAddress.City = "City";
request.Enduser.InvoiceAddress.CountryCode = "NL";

// Do the call
var transaction = new PAYNLSDK.Transaction(client).Start(request);

// do whatever you need to do
var transactionId = transaction.Transaction.TransactionId;
var redirectToUrl = transaction.Transaction.PaymentURL;
```

To determine if a transaction has been paid, you can use:
```c#
var transactionInfo = new PAYNLSDK.Transaction(client).Info(transactionId);
var paid = transactionInfo.PaymentDetails.State == PaymentStatus.PAID;

// or use the extentionmethods by adding "using PAYNLSDK.API.Transaction.Info;" at the top of your file

if (transactionInfo.IsPaid() || transactionInfo.IsPending())
{
    // redirect user to thank you page
}
else
{
    // it has not been paid yet, so redirect user back to checkout
}
```

### Exchange scripts

When implementing the exchange script (where you should process the order in your backend):
```c#
var info = PAYNLSDK.Transaction.Info(response.transactionId);
PAYNLSDK.Enums.PaymentStatus result = info.PaymentDetails.State;

if (PAYNLSDK.Transaction.IsPaid(result))
{
    // process the payment
}
else 
{
 if(PAYNLSDK.Transaction.IsCancelled(result)){
    // payment canceled, restock items
 }
}

response.Write("TRUE| ");
// Optionally you can send a message after TRUE|, you can view these messages in the logs.
// https://admin.pay.nl/logs/payment_state
response.Write("Paid");
```

## Alliance

The following Alliance methods are available:

- getMerchant
- addMerchant
- addInvoice

## Statistics

The following statistics methods are available:

- statistics/GetManagement

## Contributing

Feel free to do pull requests and create issues when you please. 

## License

This project is available as open source under the terms of the [MIT License](http://opensource.org/licenses/MIT).
