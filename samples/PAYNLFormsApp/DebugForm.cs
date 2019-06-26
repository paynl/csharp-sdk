using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PAYNLFormsApp.Objects;
using PAYNLSDK;
using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Services;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAYNLFormsApp
{
    public partial class DebugForm : Form
    {
        private IClientService ClientService { get; }
        private ILogger Logger { get; }
        private AppSettings Settings { get; }

        public DebugForm(IClientService clientService, IOptions<AppSettings> settings, ILogger<DebugForm> logger)
        {
            InitializeComponent();
            ClientService = clientService;
            Settings = settings.Value;
            Logger = logger;
        }

        public async Task DumpPaymentmethodsAsync()
        {
            ClearDebug();
            var request = new PAYNLSDK.API.PaymentMethod.GetAll.Request();
            InitRequestDebug(request);
            await ClientService.PerformPostRequestAsync(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }

        public async Task DumpTransactionGetServiceAsync()
        {
            ClearDebug();
            var request = new PAYNLSDK.API.Transaction.GetService.Request();
            InitRequestDebug(request);
            await ClientService.PerformPostRequestAsync(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
         }

        public async Task DumpTransactionGetLastAsync()
        {
            ClearDebug();
            var request = new PAYNLSDK.API.Transaction.GetLastTransactions.Request();
            InitRequestDebug(request);
            await ClientService.PerformPostRequestAsync(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }

        public async Task ApproveAsync(string transactionID)
        {
            try
            {
                ClearDebug();

                if (transactionID == "")
                {
                    AddDebug("foutieve invoer");
                    AddDebug("transactionID mag niet leeg zijn");
                }
                else
                {
                    var request = new PAYNLSDK.API.Transaction.Approve.Request
                    {
                        TransactionId = transactionID
                    };

                    InitRequestDebug(request);

                    await ClientService.PerformPostRequestAsync(request);
                    DebugRawResponse(request);
                    tbMain.Text = request.Response.Message.ToString();
                }
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        public async Task DeclineAsync(string transactionID)
        {
            try
            {
                ClearDebug();

                if (transactionID == "")
                {
                    AddDebug("foutieve invoer");
                    AddDebug("transactionID mag niet leeg zijn");
                }
                else
                {
                    var request = new PAYNLSDK.API.Transaction.Decline.Request
                    {
                        TransactionId = transactionID
                    };

                    InitRequestDebug(request);

                    await ClientService.PerformPostRequestAsync(request);
                    DebugRawResponse(request);

                    tbMain.Text = request.Response.Message.ToString();
                }
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        public async Task TransactionRefundAsync(string transactionID, string amount, string exchangeUrl)
        {
            try
            {
                ClearDebug();

                var parsed = int.TryParse(amount, out var numValue);

                if (!parsed || transactionID == "")
                {
                    if (!parsed)
                    {
                        AddDebug("foutieve invoer");
                        AddDebug("amount: only numbers. 3,40 must be filled in as 350");
                    }
                    AddDebug("foutieve invoer");
                    AddDebug("transactionID mag niet leeg zijn");
                }
                else if (exchangeUrl != "")
                {
                    AddDebug("-----");
                    AddDebug("Working with modified version of call");

                    var response = await new Transaction(ClientService)
                        .RefundAsync(transactionID, null, numValue, null, exchangeUrl);

                    tbMain.Text = response.RefundId;
                }
                else
                {
                    var request = new PAYNLSDK.API.Transaction.Refund.Request
                    {
                        Amount = numValue,
                        TransactionId = transactionID
                    };

                    InitRequestDebug(request);

                    await ClientService.PerformPostRequestAsync(request);
                    DebugRawResponse(request);

                    tbMain.Text = request.Response.RefundId;
                }
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        public async Task RefundAddAsync(string bankAccountName, string bankAccountNumber, string amount)
        {
            try
            {
                ClearDebug();

                var parsed = int.TryParse(amount, out var numValue);

                if (!parsed)
                {
                    AddDebug("foutieve invoer");
                    AddDebug("amount: numbers. 3,40 must be filled in as 350");
                }
                else
                {
                    var request = new PAYNLSDK.API.Refund.Add.Request(numValue, bankAccountName, bankAccountNumber, "");
                    InitRequestDebug(request);

                    await ClientService.PerformPostRequestAsync(request);
                    DebugRawResponse(request);

                    tbMain.Text = request.Response.RefundId;
                }
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        public async Task TransactionRefundInfoAsync(string refundID)
        {
            try
            {
                ClearDebug();

                var request = new PAYNLSDK.API.Refund.Info.Request(refundID);
                InitRequestDebug(request);

                await ClientService.PerformPostRequestAsync(request);
                DebugRawResponse(request);

                tbMain.Text = request.Response.ToString();
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        // help function
        private void ClearDebug()
        {
            tbDebug.Text = "";
        }

        private void AddDebug(string value)
        {
            if (tbDebug.Text.Length == 0)
                tbDebug.Text = value;
            else
                tbDebug.AppendText(System.Environment.NewLine + value);

            Logger.LogDebug(value);
        }

        private void InitRequestDebug(RequestBase request)
        {
            request.ApiToken = Settings.ApiToken;
            request.ServiceId = Settings.ServiceId;

            AddDebug(string.Format("Calling API {0} / {1}", request.Controller, request.Method));
            AddDebug(string.Format("Requires TOKEN? {0}", request.RequiresApiToken));
            AddDebug(string.Format("Requires SERVICEID? {0}", request.RequiresServiceId));
            AddDebug("-----");
            AddDebug("Initializing...");
            AddDebug(string.Format("URL    : {0}", request.Url));
            AddDebug(string.Format("PARAMS : {0}", request.ToQueryString()));
            AddDebug("-----");
        }
        private void DebugRawResponse(RequestBase request)
        {
            AddDebug("RAW Result from PAYNL");
            AddDebug(request.RawResponse);
        }
    }
}
