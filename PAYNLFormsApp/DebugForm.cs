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
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {

        }

        public void dumpPaymentmethods()
        {
            APISettings.InitAPI();
            ClearDebug();
            PAYNLSDK.API.PaymentMethod.GetAll.Request request = new PAYNLSDK.API.PaymentMethod.GetAll.Request();
            InitRequestDebug(request);
            APISettings.Client.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }

        public void dumpTransactionGetService()
        { 
        APISettings.InitAPI();
            ClearDebug();
        PAYNLSDK.API.Transaction.GetService.Request request = new PAYNLSDK.API.Transaction.GetService.Request();
            InitRequestDebug(request);
        APISettings.Client.PerformRequest(request);
            DebugRawResponse(request);
        tbMain.Text = request.Response.ToString();

         }

        public void dumpTransactionGetLast()
        {
            APISettings.InitAPI();
            ClearDebug();
            PAYNLSDK.API.Transaction.GetLastTransactions.Request request = new PAYNLSDK.API.Transaction.GetLastTransactions.Request();
            InitRequestDebug(request);
            APISettings.Client.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }


        public void Approve(string transactionID)
        {

            try
            {

                APISettings.InitAPI();
                ClearDebug();

                if (transactionID == "")
                {
                    AddDebug("foutieve invoer");
                    AddDebug("transactionID mag niet leeg zijn");
                }
                else
                {
                    PAYNLSDK.API.Transaction.Approve.Request request = new PAYNLSDK.API.Transaction.Approve.Request();
                    request.TransactionId = transactionID;

                    InitRequestDebug(request);

                    APISettings.Client.PerformRequest(request);
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

        public void Decline(string transactionID)
        {
            try
            {

                APISettings.InitAPI();
                ClearDebug();

                if (transactionID == "")
                {
                    AddDebug("foutieve invoer");
                    AddDebug("transactionID mag niet leeg zijn");
                }
                else
                {
                    PAYNLSDK.API.Transaction.Decline.Request request = new PAYNLSDK.API.Transaction.Decline.Request();
                    request.TransactionId = transactionID;

                    InitRequestDebug(request);

                    APISettings.Client.PerformRequest(request);
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

        public void TransactionRefund(string transactionID, string amount)
        {
            try
            {

                APISettings.InitAPI();
                ClearDebug();

                int numValue;
                bool parsed = Int32.TryParse(amount, out numValue);
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

                else
                {

                    PAYNLSDK.API.Transaction.Refund.Request request = new PAYNLSDK.API.Transaction.Refund.Request();
                    request.Amount = numValue;
                    request.TransactionId = transactionID;

                    InitRequestDebug(request);

                    APISettings.Client.PerformRequest(request);
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

        public void RefundAdd(string bankAccountName, string bankAccountNumber, string amount)
        {

            try
            {
                APISettings.InitAPI();
                ClearDebug();

                int numValue;
                bool parsed = Int32.TryParse(amount, out numValue);
                if (!parsed)
                {

                    AddDebug("foutieve invoer");
                    AddDebug("amount: numbers. 3,40 must be filled in as 350");

                }
                else
                {

                    PAYNLSDK.API.Refund.Add.Request request = new PAYNLSDK.API.Refund.Add.Request(numValue, bankAccountName, bankAccountNumber, "");
                    InitRequestDebug(request);

                    APISettings.Client.PerformRequest(request);
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
    }
}
