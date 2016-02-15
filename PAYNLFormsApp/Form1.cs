using Newtonsoft.Json;
using PAYNLFormsApp.Fixtures;
using PAYNLSDK;
using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            APISettings.InitAPI();
            ClearDebug();
            PAYNLSDK.API.PaymentMethod.GetAll.Request request = new PAYNLSDK.API.PaymentMethod.GetAll.Request();
            InitRequestDebug(request);
            APISettings.Client.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
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
            APISettings.InitAPI();
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

        private void dumpTransactionGetServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APISettings.InitAPI();
            ClearDebug();
            PAYNLSDK.API.Transaction.GetService.Request request = new PAYNLSDK.API.Transaction.GetService.Request();
            InitRequestDebug(request);
            APISettings.Client.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }

        private void dumpTransactionGetLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APISettings.InitAPI();
            ClearDebug();
            PAYNLSDK.API.Transaction.GetLastTransactions.Request request = new PAYNLSDK.API.Transaction.GetLastTransactions.Request();
            InitRequestDebug(request);
            APISettings.Client.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }

        private void txinfo(string id)
        {
            //619204633Xc4027e
            APISettings.InitAPI();
            ClearDebug();
            PAYNLSDK.API.Transaction.Info.Request request = new PAYNLSDK.API.Transaction.Info.Request();
            request.TransactionId = id;
            InitRequestDebug(request);
            APISettings.Client.PerformRequest(request);
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
            APISettings.InitAPI();
            ClearDebug();
            PAYNLSDK.API.Transaction.Start.Request fixture = TransactionStart.GetFixture();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            AddDebug(fixture.ToQueryString());
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void transactionStartproductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APISettings.InitAPI();
            ClearDebug();
            PAYNLSDK.API.Transaction.Start.Request fixture = TransactionStart.GetFixtureNoProductLines();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            string qs = fixture.ToQueryString();
            AddDebug(qs);
            NameValueCollection nvc = HttpUtility.ParseQueryString(qs);
            string json = JsonConvert.SerializeObject(NvcToDictionary(nvc, true));
            AddDebug("-----");
            //AddDebug("PARAMS AS JSON");
            //AddDebug(json);
            DumpNvc(nvc);
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
                APISettings.InitAPI();
                ClearDebug();
                PAYNLSDK.API.Transaction.Start.Request fixture = TransactionStart.GetFixtureNoProductLines();
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                APISettings.Client.PerformRequest(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();

                string url = fixture.Response.Transaction.PaymentURL;
                System.Diagnostics.Process.Start(url);
            }
            catch (ErrorException ee)
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
                APISettings.InitAPI();
                ClearDebug();
                PAYNLSDK.API.Transaction.Start.Request fixture = LastRequests.LastTransactionStart;
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                APISettings.Client.PerformRequest(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();

                string url = fixture.Response.Transaction.PaymentURL;
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

        private void paymentProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                APISettings.InitAPI();
                ClearDebug();
                PAYNLSDK.API.PaymentProfile.GetAll.Request fixture = new PAYNLSDK.API.PaymentProfile.GetAll.Request();
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                APISettings.Client.PerformRequest(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        private void serviceCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                APISettings.InitAPI();
                ClearDebug();
                PAYNLSDK.API.Service.GetCategories.Request fixture = new PAYNLSDK.API.Service.GetCategories.Request();
                InitRequestDebug(fixture);
                DumpNvc(fixture.GetParameters());

                APISettings.Client.PerformRequest(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }
    }
    /*
    class X
    {
        [JsonProperty("gender"), JsonConverter(typeof(PAYNLSDK.Converters.GenderConverter))]
        public PAYNLSDK.Enums.Gender Gender { get; set; }

    }
     */
}
