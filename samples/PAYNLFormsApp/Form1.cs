using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PAYNLFormsApp.Fixtures;
using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Windows.Forms;

namespace PAYNLFormsApp
{
    public partial class Form1 : Form
    {
        public IClientService ClientService { get; }
        public IUtilityService UtilityService { get; }
        public ILogger Logger { get; }

        public LastRequests LastRequests { get; set; }
        public StartTransaction StartTransaction { get; set; }

        public Form1(IClientService clientService, IUtilityService utilityService, ILogger logger)
        {
            InitializeComponent();

            ClientService = clientService;
            UtilityService = utilityService;
            Logger = logger;

            LastRequests = new LastRequests();
            StartTransaction = new StartTransaction(clientService);
        }

        private void PayNLAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form2(ClientService);
            form.ShowDialog();
        }

        private void ValidationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ValidationForm(UtilityService).ShowDialog();
        }

        private async void DumpPaymentmethodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DebugForm(ClientService, Logger);
            await form.DumpPaymentmethodsAsync();
            form.ShowDialog();
        }

        private void ClearDebug()
        {
            tbDebug.Text = "";
        }

        private void AddDebug(string value)
        {
            if (tbDebug.Text.Length == 0)
                tbDebug.Text = value;
            else
                tbDebug.AppendText(Environment.NewLine + value);

            Logger.LogDebug(value);
        }

        private void InitRequestDebug(RequestBase request)
        {
            request.ApiToken = ClientService.Settings.ApiToken;
            request.ServiceId = ClientService.Settings.ServiceId;

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

        private async void DumpTransactionGetServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DebugForm(ClientService, Logger);
            await form.DumpTransactionGetServiceAsync();
            form.ShowDialog();
        }

        private async void DumpTransactionGetLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DebugForm(ClientService, Logger);
            await form.DumpTransactionGetLastAsync();
            form.ShowDialog();
        }

        private async void Txinfo(string id)
        {
            //619204633Xc4027e
            ClearDebug();
            var request = new PAYNLSDK.API.Transaction.Info.Request
            {
                TransactionId = id
            };
            InitRequestDebug(request);
            await ClientService.PerformRequestAsync(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }

        private void Xc4027ePAIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Txinfo("619204633Xc4027e");
        }

        private void Xc5b75dPAIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Txinfo("611642851Xc5b75d");
        }

        private void Xd83303CANCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Txinfo("618847570Xd83303");
        }

        private void TransActionStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDebug();
            var fixture = new TransactionStart(ClientService).GetFixture();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            AddDebug(fixture.ToQueryString());
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void TransactionStartproductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDebug();
            var fixture = new TransactionStart(ClientService).GetFixtureNoProductLines();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            var qs = fixture.ToQueryString();
            AddDebug(qs);
            var nvc = HttpUtility.ParseQueryString(qs);
            var json = JsonConvert.SerializeObject(NvcToDictionary(nvc, true));
            AddDebug("-----");
            AddDebug("PARAMS AS JSON");
            AddDebug(json);
            DumpNvc(nvc);
            AddDebug("-----");
            AddDebug("DONE");
        }

        void DumpNvc(NameValueCollection nvc)
        {
            foreach (string key in nvc.Keys)
            {
                var values = nvc.GetValues(key);
                foreach (var value in nvc.GetValues(key))
                {
                    AddDebug(string.Format("'{0}' : '{1}'", key, value));
                }
            }
        }

        private Dictionary<string, object> NvcToDictionary(NameValueCollection nvc, bool handleMultipleValuesPerKey)
        {
            var result = new Dictionary<string, object>();
            foreach (string key in nvc.Keys)
            {
                if (handleMultipleValuesPerKey)
                {
                    var values = nvc.GetValues(key);
                    if (values.Length == 1)
                    {
                        result.Add(key, values[0]);
                    }
                    else
                    {
                        result.Add(key, values);
                    }
                }
                else
                {
                    result.Add(key, nvc[key]);
                }
            }

            return result;
        }

        private async void StartuseFixtureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDebug();
                var fixture = new TransactionStart(ClientService).GetFixtureNoProductLines();
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                await ClientService.PerformRequestAsync(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();

                var url = fixture.Response.Transaction.PaymentURL;
                System.Diagnostics.Process.Start(url);
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        private void StartuseFixtureEditableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new StartTransaction(ClientService);
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
        }

        private async void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (!StartTransaction.OK)
                {
                    ClearDebug();
                    AddDebug("CANCELLED!");
                    return;
                }
                ClearDebug();
                var fixture = LastRequests.LastTransactionStart;
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                await ClientService.PerformRequestAsync(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();

                var url = fixture.Response.Transaction.PaymentURL;
                System.Diagnostics.Process.Start(url);
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            AddDebug(PAYNLSDK.Enums.Util.ToEnumString<PAYNLSDK.Enums.TaxClass>(PAYNLSDK.Enums.TaxClass.High));
            AddDebug(PAYNLSDK.Enums.Util.ToEnumString(PAYNLSDK.Enums.TaxClass.High, typeof(PAYNLSDK.Enums.TaxClass)));

            string ser = @"{'gender':'m'}";
            X x = JsonConvert.DeserializeObject<X>(ser);
            AddDebug(JsonConvert.SerializeObject(x));
            */
        }

        private async void PaymentProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDebug();
                var fixture = new PAYNLSDK.API.PaymentProfile.GetAll.Request();
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                await ClientService.PerformRequestAsync(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        private async void ServiceCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDebug();
                var fixture = new PAYNLSDK.API.Service.GetCategories.Request();
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                await ClientService.PerformRequestAsync(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        private void ApproveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ApproveDecline(ClientService, Logger);
            form.ShowDialog();
        }

        private void DeclineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ApproveDecline(ClientService, Logger);
            form.ShowDialog();
        }

        private void RefundAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RefundAdd(ClientService, Logger);
            form.ShowDialog();
        }

        private void RefundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TransactionRefund(ClientService, Logger);
            form.ShowDialog();
        }

        private void TestDateTimeConversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] ymdtests = {
                                 // YMD
                                 @"{dt: '2018-1-1'}",
                                 @"{dt: '2018-5-10'}",
                                 @"{dt: '2018-12-11'}",
                                 @"{dt: '2018-12-1'}",
                                 @"{dt: '2018/1/1'}",
                                 @"{dt: '2018/5/10'}",
                                 @"{dt: '2018/12/11'}",
                                 @"{dt: '2018/12/1'}"
                                };
            string[] dmytests = {
                                 // DMY
                                 @"{dt: '1-1-2-2018'}",
                                 @"{dt: '10-5-2018'}",
                                 @"{dt: '11-23-2018'}",
                                 @"{dt: '1-12-2018'}",
                                 @"{dt: '1/1/2/2018'}",
                                 @"{dt: '10/5/2018'}",
                                 @"{dt: '11/23/2018'}",
                                 @"{dt: '1/12/2018'}"
                                };
            string[] ymdhistests = {
                                 // YMDHIS
                                 @"{dt: '2018-1-1 12:11'}",
                                 @"{dt: '2018-1-1 9:11'}",
                                 @"{dt: '2018-1-1 11:9'}",
                                 @"{dt: '2018-5-10 12:11:01'}",
                                 @"{dt: '2018-12-11 9:9:1'}",
                                 @"{dt: '2018-12-1 9:9:10'}",
                                 @"{dt: '2018-12-1 09:9:10'}",
                                 @"{dt: '2018-12-1 9:09:10'}",
                                 @"{dt: '2018/1/1 12:11'}",
                                 @"{dt: '2018/1/1 9:11'}",
                                 @"{dt: '2018/1/1 11:9'}",
                                 @"{dt: '2018/5/10 12:11:01'}",
                                 @"{dt: '2018/12/11 9:9:1'}",
                                 @"{dt: '2018/12/1 9:9:10'}",
                                 @"{dt: '2018/12/1 09:9:10'}",
                                 @"{dt: '2018/12/1 9:09:10'}"
                            };

            foreach (var dateString in ymdtests)
            {
                try
                {
                    var testObj = JsonConvert.DeserializeObject<TestYMD>(dateString);
                    AddDebug(string.Format("Converted '{0}' to {1}.", dateString, testObj.DT.ToString()));
                }
                catch (Exception e0)
                {
                    AddDebug(string.Format("Error converting '{0}' using YMD.", dateString));
                    AddDebug(e0.Message);
                }
            }
            foreach (var dateString in dmytests)
            {
                try
                {
                    var testObj = JsonConvert.DeserializeObject<TestDMY>(dateString);
                    AddDebug(string.Format("Converted '{0}' to {1}.", dateString, testObj.DT.ToString()));
                }
                catch (Exception e1)
                {
                    AddDebug(string.Format("Error converting '{0}' using YMD.", dateString));
                    AddDebug(e1.Message);
                }
            }
            foreach (var dateString in ymdhistests)
            {
                try
                {
                    var testObj = JsonConvert.DeserializeObject<TestYMDHIS>(dateString);
                    AddDebug(string.Format("Converted '{0}' to {1}.", dateString, testObj.DT.ToString()));
                }
                catch (Exception e2)
                {
                    AddDebug(string.Format("Error converting '{0}' using YMD.", dateString));
                    AddDebug(e2.Message);
                }
            }
        }

        private void RefundtransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDebug();
            var fixture = RefundTransaction.GetFixtureNoProductLines();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            var qs = fixture.ToQueryString();
            AddDebug(qs);
            var nvc = HttpUtility.ParseQueryString(qs);
            var json = JsonConvert.SerializeObject(NvcToDictionary(nvc, true));
            AddDebug("-----");
            AddDebug("PARAMS AS JSON");
            AddDebug(json);
            DumpNvc(nvc);
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void RefundTrasactionProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDebug();
            var fixture = RefundTransaction.GetFixture();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            var qs = fixture.ToQueryString();
            AddDebug(qs);
            var nvc = HttpUtility.ParseQueryString(qs);
            var json = JsonConvert.SerializeObject(NvcToDictionary(nvc, true));
            AddDebug("-----");
            AddDebug("PARAMS AS JSON");
            AddDebug(json);
            DumpNvc(nvc);
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void TransactionRefundInofromJsonFixtureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDebug();
            var json = TransactionRefundInfo.GetJsonFixture();
            var fixture = TransactionRefundInfo.GetRefundInfoFixture();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(json);
            AddDebug("-----");
            AddDebug(fixture.ToString());
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void RefundInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RefundInfo(ClientService, Logger);
            form.ShowDialog();
        }
        /*
        class X
        {
            [JsonProperty("gender"), JsonConverter(typeof(PAYNLSDK.Converters.GenderConverter))]
            public PAYNLSDK.Enums.Gender Gender { get; set; }

        }
         */
    }

    public class TestYMD
    {
        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonProperty("dt"), JsonConverter(typeof(PAYNLSDK.Converters.YMDConverter))]
        public DateTime? DT { get; set; }
    }
    public class TestDMY
    {
        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonProperty("dt"), JsonConverter(typeof(PAYNLSDK.Converters.DMYConverter))]
        public DateTime? DT { get; set; }
    }
    public class TestYMDHIS
    {
        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonProperty("dt"), JsonConverter(typeof(PAYNLSDK.Converters.YMDHISConverter))]
        public DateTime? DT { get; set; }
    }
}
