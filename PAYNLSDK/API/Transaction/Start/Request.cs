using System;
using Newtonsoft.Json;
using System.Collections.Specialized;
using PAYNLSDK.Utilities;
using PAYNLSDK.Objects;
using PAYNLSDK.Enums;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.Transaction.Start
{
    /// <summary>
    /// The HTTP request to request the start of a new transaction
    /// </summary>
    /// <seealso cref="T:PAYNLSDK.API.RequestBase" />
    public class Request : RequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        public Request()
        {
            TransactionData = new TransactionData();
            Enduser = new EndUser();
            SalesData = new SalesData();
            StatsData = new StatsDetails();
        }

        /// <inheritdoc />
        public override bool RequiresApiToken => true;

        /// <inheritdoc />
        public override bool RequiresServiceId => true;

        /// <summary>
        ///  	The amount to be paid should be given in cents. For example € 3.50 becomes 350.
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// The IP address of the customer
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// The URL where the customer has to be send to after the payment.
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// The payment PROFILE to be used
        /// </summary>
        public int? PaymentOptionId { get; set; }
        /// <summary>
        /// In case of an iDEAL payment this is the ID of the bank (see the paymentOptionSubList in the getService function).
        /// </summary>
        public int? PaymentOptionSubId { get; set; }
        /// <summary>
        ///  define if this is running in test or not 
        /// </summary>
        public bool TestMode { get; set; }
        /// <summary>
        /// Use transaction, merchant or alliance to change the benificiary owner of the transaction
        /// </summary>
        public string TransferType { get; set; }
        /// <summary>
        ///  	MerchantId (M-xxxx-xxxx) or orderId
        /// </summary>
        public string TransferValue { get; set; }

        /// <summary>
        /// Optional information about the transaction
        /// </summary>
        public TransactionData TransactionData { get; set; }
        public StatsDetails StatsData { get; set; }
        public EndUser Enduser { get; set; }
        public SalesData SalesData { get; set; }

        /// <inheritdoc />
        protected override int Version
        {
            get { return 5; }
        }

        /// <inheritdoc />
        protected override string Controller
        {
            get { return "Transaction"; }
        }

        protected override string Method
        {
            get { return "start"; }
        }

        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            // Basic params
            ParameterValidator.IsNotNull(Amount, "Amount");
            nvc.Add("amount", Amount.ToString());

            ParameterValidator.IsNotNull(IPAddress, "IPAddress");
            nvc.Add("ipAddress", IPAddress);

            ParameterValidator.IsNotNull(ReturnUrl, "ReturnUrl");
            nvc.Add("finishUrl", ReturnUrl);

            if (!ParameterValidator.IsNonEmptyInt(PaymentOptionId))
            {
                nvc.Add("paymentOptionId", PaymentOptionId.ToString());
            }

            if (!ParameterValidator.IsNonEmptyInt(PaymentOptionSubId))
            {
                nvc.Add("paymentOptionSubId", PaymentOptionSubId.ToString());
            }

            if (!ParameterValidator.IsEmpty(TransferValue))
            {

                if (TransferType == "transaction" || TransferType == "merchant")
                {
                    nvc.Add("transferType", TransferType);
                    nvc.Add("transferValue", TransferValue);
                }
                else
                {
                    throw new Exception("TransferValue cannot be set, without valid TransferType, please fix this.");
                }
            }

            // Transaction
            if (TransactionData != null)
            {
                if (string.IsNullOrWhiteSpace(TransactionData.Currency) == false)
                {
                    nvc.Add("transaction[currency]", TransactionData.Currency);
                }
                if (!ParameterValidator.IsNonEmptyInt(TransactionData.CostsVat))
                {
                    nvc.Add("transaction[costsVat]", TransactionData.CostsVat.ToString());
                }
                // TODO: exclude cost?
                if (!ParameterValidator.IsEmpty(TransactionData.OrderExchangeUrl))
                {
                    nvc.Add("transaction[orderExchangeUrl]", TransactionData.OrderExchangeUrl);
                }
                if (!ParameterValidator.IsNull(TransactionData.OrderNumber))
                {
                    nvc.Add("transaction[orderNumber]", TransactionData.OrderNumber);
                }
                if (!ParameterValidator.IsEmpty(TransactionData.Description))
                {
                    nvc.Add("transaction[description]", TransactionData.Description);
                }

                if (!ParameterValidator.IsNonEmptyInt(TransactionData.EnduserId))
                {
                    nvc.Add("transaction[enduserId]", TransactionData.EnduserId.ToString());
                }

                if (!ParameterValidator.IsNull(TransactionData.OrderNumber))
                {
                    nvc.Add("transaction[orderNumber]", TransactionData.OrderNumber);
                }

                if (!ParameterValidator.IsNull(TransactionData.ExpireDate))
                {
                    nvc.Add("transaction[expireDate]", ((DateTime)TransactionData.ExpireDate).ToString("dd-MM-yyyy hh:mm:ss"));
                }
                // TODO: Are these right? Shouldn't this be BOOL / INT?
                /*
                if (!ParameterValidator.IsEmpty(Transaction.SendReminderEmail))
                {
                    nvc.Add("transaction[sendReminderEmail]", Transaction.SendReminderEmail);
                }
                if (!ParameterValidator.IsEmpty(Transaction.ReminderMailTemplateId))
                {
                    nvc.Add("transaction[reminderMailTemplateId]", Transaction.ReminderMailTemplateId);
                }
                */
            }

            // StatsData
            if (StatsData != null)
            {
                if (!ParameterValidator.IsNonEmptyInt(StatsData.PromotorId))
                {
                    nvc.Add("statsData[promotorId]", StatsData.PromotorId.ToString());
                }
                if (!ParameterValidator.IsEmpty(StatsData.Info))
                {
                    nvc.Add("statsData[info]", StatsData.Info);
                }
                if (!ParameterValidator.IsEmpty(StatsData.Tool))
                {
                    nvc.Add("statsData[tool]", StatsData.Tool);
                }
                if (!ParameterValidator.IsEmpty(StatsData.Extra1))
                {
                    nvc.Add("statsData[extra1]", StatsData.Extra1);
                }
                if (!ParameterValidator.IsEmpty(StatsData.Extra2))
                {
                    nvc.Add("statsData[extra2]", StatsData.Extra2);
                }
                if (!ParameterValidator.IsEmpty(StatsData.Extra3))
                {
                    nvc.Add("statsData[extra3]", StatsData.Extra3);
                }
                //if (!ParameterValidator.IsEmpty(StatsData.TransferData))
                //{
                //    nvc.Add("statsData[transferData]", StatsData.TransferData);
                //}
            }

            // End user
            if (Enduser != null)
            {
                /*
                if (!ParameterValidator.IsEmpty(Enduser.AccessCode))
                {
                    nvc.Add("enduser[accessCode]", Enduser.AccessCode);
                }
                 * */
                if (!ParameterValidator.IsEmpty(Enduser.Language))
                {
                    nvc.Add("enduser[language]", Enduser.Language);
                }
                if (!ParameterValidator.IsEmpty(Enduser.Initials))
                {
                    nvc.Add("enduser[initials]", Enduser.Initials);
                }
                if (!ParameterValidator.IsEmpty(Enduser.Lastname))
                {
                    nvc.Add("enduser[lastName]", Enduser.Lastname);
                }
                if (!ParameterValidator.IsNull(Enduser.Gender))
                {
                    nvc.Add("enduser[gender]", EnumUtil.ToEnumString<Gender>((Gender)Enduser.Gender));
                }
                if (!ParameterValidator.IsNull(Enduser.BirthDate))
                {
                    nvc.Add("enduser[dob]", ((DateTime)Enduser.BirthDate).ToString("dd-MM-yyyy"));
                }
                if (!ParameterValidator.IsEmpty(Enduser.PhoneNumber))
                {
                    nvc.Add("enduser[phoneNumber]", Enduser.PhoneNumber);
                }
                if (!ParameterValidator.IsEmpty(Enduser.EmailAddress))
                {
                    nvc.Add("enduser[emailAddress]", Enduser.EmailAddress);
                }
                if (!ParameterValidator.IsEmpty(Enduser.BankAccount))
                {
                    nvc.Add("enduser[bankAccount]", Enduser.BankAccount);
                }
                if (!ParameterValidator.IsEmpty(Enduser.IBAN))
                {
                    nvc.Add("enduser[iban]", Enduser.IBAN);
                }
                /*
                if (!ParameterValidator.IsNull(Enduser.SendConfirmMail))
                {
                    nvc.Add("enduser[sendConfirmMail]", ((bool)Enduser.SendConfirmMail) ? "1" : "0");
                }
                if (!ParameterValidator.IsEmpty(Enduser.ConfirmMailTemplate))
                {
                    nvc.Add("enduser[confirmMailTemplate]", Enduser.ConfirmMailTemplate);
                }
                 * */
                if (!ParameterValidator.IsEmpty(Enduser.CustomerReference))
                {
                    nvc.Add("enduser[customerReference]", Enduser.CustomerReference);
                }
                // Address
                if (Enduser.Address != null)
                {
                    if (!ParameterValidator.IsEmpty(Enduser.Address.StreetName))
                    {
                        nvc.Add("enduser[address][streetName]", Enduser.Address.StreetName);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.Address.StreetNumber))
                    {
                        nvc.Add("enduser[address][streetNumber]", Enduser.Address.StreetNumber);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.Address.ZipCode))
                    {
                        nvc.Add("enduser[address][zipCode]", Enduser.Address.ZipCode);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.Address.City))
                    {
                        nvc.Add("enduser[address][city]", Enduser.Address.City);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.Address.CountryCode))
                    {
                        nvc.Add("enduser[address][countryCode]", Enduser.Address.CountryCode);
                    }
                }

                // InvoiceAddress
                if (Enduser.InvoiceAddress != null)
                {
                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.Initials))
                    {
                        nvc.Add("enduser[invoiceAddress][initials]", Enduser.InvoiceAddress.Initials);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.LastName))
                    {
                        nvc.Add("enduser[invoiceAddress][lastName]", Enduser.InvoiceAddress.LastName);
                    }
                    if (!ParameterValidator.IsNull(Enduser.InvoiceAddress.Gender))
                    {
                        string gender = EnumUtil.ToEnumString<Gender>((Gender)Enduser.InvoiceAddress.Gender);
                        nvc.Add("enduser[invoiceAddress][gender]", gender);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.StreetName))
                    {
                        nvc.Add("enduser[invoiceAddress][streetName]", Enduser.InvoiceAddress.StreetName);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.StreetNumber))
                    {
                        nvc.Add("enduser[invoiceAddress][streetNumber]", Enduser.InvoiceAddress.StreetNumber);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.ZipCode))
                    {
                        nvc.Add("enduser[invoiceAddress][zipCode]", Enduser.InvoiceAddress.ZipCode);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.City))
                    {
                        nvc.Add("enduser[invoiceAddress][city]", Enduser.InvoiceAddress.City);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.CountryCode))
                    {
                        nvc.Add("enduser[invoiceAddress][countryCode]", Enduser.InvoiceAddress.CountryCode);
                    }
                }

                //Company info
                if (Enduser.Company != null)
                {
                    if (!ParameterValidator.IsEmpty(Enduser.Company.CocNumber))
                    {
                        nvc.Add("enduser[company][cocNumber]", Enduser.Company.CocNumber);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.Company.CountryCode))
                    {
                        nvc.Add("enduser[company][countryCode]", Enduser.Company.CountryCode);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.Company.Name))
                    {
                        nvc.Add("enduser[company][name]", Enduser.Company.Name);
                    }
                    if (!ParameterValidator.IsEmpty(Enduser.Company.VatNumber))
                    {
                        nvc.Add("enduser[company][vatNumber]", Enduser.Company.VatNumber);
                    }
                }

            }

            // SaleData
            if (SalesData != null)
            {
                if (!ParameterValidator.IsNull(SalesData.DeliveryDate))
                {
                    nvc.Add("saleData[deliveryDate]", SalesData.DeliveryDate?.ToString("dd-MM-yyyy"));
                }
                if (!ParameterValidator.IsNull(SalesData.InvoiceDate))
                {
                    nvc.Add("saleData[invoiceDate]", SalesData.InvoiceDate?.ToString("dd-MM-yyyy"));
                }
                if (!ParameterValidator.IsNull(SalesData.OrderData))
                {
                    int i = 0;
                    foreach (OrderData data in SalesData.OrderData)
                    {
                        ParameterValidator.IsNotNull(data.ProductId, "SalesData.OrderData.ProductId");
                        nvc.Add(string.Format("saleData[orderData][{0}][productId]", i), data.ProductId);

                        if (!ParameterValidator.IsNull(data.Description))
                        {
                            nvc.Add(string.Format("saleData[orderData][{0}][description]", i), data.Description);
                        }

                        ParameterValidator.IsNotNull(data.Price, "SalesData.OrderData.Price");
                        nvc.Add(string.Format("saleData[orderData][{0}][price]", i), data.Price.ToString());

                        ParameterValidator.IsNotNull(data.Quantity, "SalesData.OrderData.Quantity");
                        nvc.Add(string.Format("saleData[orderData][{0}][quantity]", i), data.Quantity.ToString());

                        if (!ParameterValidator.IsNull(data.VatCode))
                        {
                            nvc.Add(string.Format("saleData[orderData][{0}][vatCode]", i), EnumUtil.ToEnumString<TaxClass>((TaxClass)data.VatCode));
                        }
                        if (!ParameterValidator.IsNull(data.ProductType))
                        {
                            nvc.Add(string.Format("saleData[orderData][{0}][productType]", i), EnumUtil.ToEnumString<ProductType>((ProductType)data.ProductType));
                        }

                        i++;
                    }
                }
            }

            // TestMode
            if (!ParameterValidator.IsNull(TestMode))
            {
                nvc.Add("testMode", (bool)TestMode ? "1" : "0");
            }

            return nvc;
        }

        public Response Response { get { return (Response)response; } }

        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
            if (!Response.Request.Result)
            {
                // toss
                throw new PayNlException(Response.Request.Code + " " + Response.Request.Message);
            }
        }
    }
}
