using Newtonsoft.Json;
using PAYNLFormsApp.Fixtures;
using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Windows.Forms;

namespace PAYNLFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void payNLAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void validationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ValidationForm()).ShowDialog();
        }

        private void dumpPaymentmethodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugForm form = new DebugForm();
            form.dumpPaymentmethods();
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
                tbDebug.AppendText(System.Environment.NewLine + value);
        }
        private void InitRequestDebug(RequestBase request)
        {
            AddDebug(string.Format("Calling API {0} / {1}", request.Controller, request.Method));
            AddDebug(string.Format("Requires TOKEN? {0}", request.RequiresApiToken));
            AddDebug(string.Format("Requires SERVICEID? {0}", request.RequiresServiceId));
            AddDebug("-----");
            AddDebug("Initializing...");
            AddDebug(string.Format("URL    : {0}", request.Url));
            //AddDebug(string.Format("PARAMS : {0}", request.ToQueryString()));
            AddDebug("-----");
        }
        private void DebugRawResponse(RequestBase request)
        {
            AddDebug("RAW Result from PAYNL");
            AddDebug(request.RawResponse);
        }

        private void dumpTransactionGetServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugForm form = new DebugForm();
            form.dumpTransactionGetService();
            form.ShowDialog();
        }

        private void dumpTransactionGetLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugForm form = new DebugForm();
            form.DumpTransactionGetLast();
            form.ShowDialog();
        }

        private void txinfo(string id)
        {
            //619204633Xc4027e
            
            ClearDebug();
            PAYNLSDK.API.Transaction.Info.Request request = new PAYNLSDK.API.Transaction.Info.Request();
            request.TransactionId = id;
            InitRequestDebug(request);
            MyStaticPayNlClient.Client.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }

        private void xc4027ePAIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txinfo("619204633Xc4027e");
        }

        private void xc5b75dPAIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txinfo("611642851Xc5b75d");
        }

        private void xd83303CANCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txinfo("618847570Xd83303");
        }

        private void transActionStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ClearDebug();
            PAYNLSDK.API.Transaction.Start.Request fixture = TransactionStart.GetFixture();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            //AddDebug("PARAMS:");
            //AddDebug(fixture.ToQueryString());
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void transactionStartproductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ClearDebug();
            PAYNLSDK.API.Transaction.Start.Request fixture = TransactionStart.GetFixtureNoProductLines();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            //AddDebug("PARAMS:");
            //string qs = fixture.ToQueryString();
            //AddDebug(qs);
            //NameValueCollection nvc = HttpUtility.ParseQueryString(qs);
            //string json = JsonConvert.SerializeObject(NvcToDictionary(nvc, true));
            AddDebug("-----");
            //DumpNvc(nvc);
            AddDebug("-----");
            AddDebug("DONE");
        }

        void DumpNvc(NameValueCollection nvc)
        {
            foreach (string key in nvc.Keys)
            {
                string[] values = nvc.GetValues(key);
                foreach (string value in nvc.GetValues(key))
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
                    string[] values = nvc.GetValues(key);
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

        private void startuseFixtureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                ClearDebug();
                PAYNLSDK.API.Transaction.Start.Request fixture = TransactionStart.GetFixtureNoProductLines();
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                MyStaticPayNlClient.Client.PerformRequest(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();

                string url = fixture.Response.Transaction.PaymentUrl;
                System.Diagnostics.Process.Start(url);
            }
            catch (PayNlException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }

        }

        private void startuseFixtureEditableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTransaction frm = new StartTransaction();
            frm.FormClosed += frm_FormClosed;
            frm.ShowDialog();
        }



        private void frm_FormClosed(object sender, FormClosedEventArgs e)
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
                PAYNLSDK.API.Transaction.Start.Request fixture = LastRequests.LastTransactionStart;
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                MyStaticPayNlClient.Client.PerformRequest(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();

                string url = fixture.Response.Transaction.PaymentUrl;
                System.Diagnostics.Process.Start(url);
            }
            catch (PayNlException ee)
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

        private void paymentProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                ClearDebug();
                PAYNLSDK.API.PaymentProfile.GetAll.Request fixture = new PAYNLSDK.API.PaymentProfile.GetAll.Request();
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                MyStaticPayNlClient.Client.PerformRequest(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();
            }
            catch (PayNlException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        private void serviceCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                ClearDebug();
                PAYNLSDK.API.Service.GetCategories.Request fixture = new PAYNLSDK.API.Service.GetCategories.Request();
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                MyStaticPayNlClient.Client.PerformRequest(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();
            }
            catch (PayNlException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        private void approveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ApproveDecline form = new ApproveDecline();
            form.ShowDialog();

        }

        private void declineToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ApproveDecline form = new ApproveDecline();
            form.ShowDialog();


        }

        private void refundAddToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RefundAdd form = new RefundAdd();
            form.ShowDialog();

        }

        private void refundToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TransactionRefund form = new TransactionRefund();
            form.ShowDialog();

        }

        private void testDateTimeConversionToolStripMenuItem_Click(object sender, EventArgs e)
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


            foreach (string dateString in ymdtests)
            {
                try
                {
                    TestYMD testObj = JsonConvert.DeserializeObject<TestYMD>(dateString);
                    AddDebug(String.Format("Converted '{0}' to {1}.", dateString, testObj.DT.ToString()));
                }
                catch (Exception e0)
                {
                    AddDebug(String.Format("Error converting '{0}' using YMD.", dateString));
                    AddDebug(e0.Message);
                }
            }
            foreach (string dateString in dmytests)
            {
                try
                {
                    TestDMY testObj = JsonConvert.DeserializeObject<TestDMY>(dateString);
                    AddDebug(String.Format("Converted '{0}' to {1}.", dateString, testObj.DT.ToString()));
                }
                catch (Exception e1)
                {
                    AddDebug(String.Format("Error converting '{0}' using YMD.", dateString));
                    AddDebug(e1.Message);
                }
            }
            foreach (string dateString in ymdhistests)
            {
                try
                {
                    TestYMDHIS testObj = JsonConvert.DeserializeObject<TestYMDHIS>(dateString);
                    AddDebug(String.Format("Converted '{0}' to {1}.", dateString, testObj.DT.ToString()));
                }
                catch (Exception e2)
                {
                    AddDebug(String.Format("Error converting '{0}' using YMD.", dateString));
                    AddDebug(e2.Message);
                }
            }

        }

        private void refundtransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //APISettings.InitAPI();
            ClearDebug();
            PAYNLSDK.API.Refund.Transaction.Request fixture = RefundTransaction.GetFixtureNoProductLines();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            //string qs = fixture.ToQueryString();
            //AddDebug(qs);
            //NameValueCollection nvc = HttpUtility.ParseQueryString(qs);
            //string json = JsonConvert.SerializeObject(NvcToDictionary(nvc, true));
            AddDebug("-----");
            //AddDebug("PARAMS AS JSON");
            //AddDebug(json);
            //DumpNvc(nvc);
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void refundTrasactionProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //APISettings.InitAPI();
            ClearDebug();
            PAYNLSDK.API.Refund.Transaction.Request fixture = RefundTransaction.GetFixture();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            //string qs = fixture.ToQueryString();
            //AddDebug(qs);
            //NameValueCollection nvc = HttpUtility.ParseQueryString(qs);
            //string json = JsonConvert.SerializeObject(NvcToDictionary(nvc, true));
            //AddDebug("-----");
            ////AddDebug("PARAMS AS JSON");
            ////AddDebug(json);
            //DumpNvc(nvc);
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void transactionRefundInofromJsonFixtureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDebug();
            String json = TransactionRefundInfo.GetJsonFixture();
            PAYNLSDK.Objects.RefundInfo fixture = TransactionRefundInfo.GetRefundInfoFixture();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(json);
            AddDebug("-----");
            AddDebug(fixture.ToString());
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void refundInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefundInfo form = new RefundInfo();
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