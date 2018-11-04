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
using PayNlException = PAYNLSDK.Exceptions.PayNlException;

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
            ClearDebug();
            PAYNLSDK.API.PaymentMethod.GetAll.Request request = new PAYNLSDK.API.PaymentMethod.GetAll.Request();
            InitRequestDebug(request);
            MyStaticPayNlClient.Client.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }

        public void dumpTransactionGetService()
        {
            ClearDebug();
            PAYNLSDK.API.Transaction.GetService.Request request = new PAYNLSDK.API.Transaction.GetService.Request();
            InitRequestDebug(request);
            MyStaticPayNlClient.Client.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();

        }

        public void DumpTransactionGetLast()
        {
            ClearDebug();
            PAYNLSDK.API.Transaction.GetLastTransactions.Request request = new PAYNLSDK.API.Transaction.GetLastTransactions.Request();
            InitRequestDebug(request);
            MyStaticPayNlClient.Client.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }


        public void Approve(string transactionID)
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
                    PAYNLSDK.API.Transaction.Approve.Request request = new PAYNLSDK.API.Transaction.Approve.Request();
                    request.TransactionId = transactionID;

                    InitRequestDebug(request);

                    MyStaticPayNlClient.Client.PerformRequest(request);
                    DebugRawResponse(request);
                    tbMain.Text = request.Response.Message.ToString();
                }

            }
            catch (PayNlException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }

        }

        public void Decline(string transactionID)
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
                    PAYNLSDK.API.Transaction.Decline.Request request = new PAYNLSDK.API.Transaction.Decline.Request();
                    request.TransactionId = transactionID;

                    InitRequestDebug(request);

                    MyStaticPayNlClient.Client.PerformRequest(request);
                    DebugRawResponse(request);


                    tbMain.Text = request.Response.Message.ToString();

                }

            }
            catch (PayNlException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }

        }

        public void TransactionRefund(string transactionID, string amount)
        {
            try
            {


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

                    MyStaticPayNlClient.Client.PerformRequest(request);
                    DebugRawResponse(request);

                    tbMain.Text = request.Response.RefundId;
                }


            }
            catch (PayNlException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }

        }

        public void RefundAdd(string bankAccountName, string bankAccountNumber, string amount)
        {

            try
            {

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

                    MyStaticPayNlClient.Client.PerformRequest(request);
                    DebugRawResponse(request);


                    tbMain.Text = request.Response.RefundId;
                }


            }
            catch (PayNlException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        public void TransactionRefundInfo(string refundID)
        {

            try
            {
                // APISettings.InitAPI();
                ClearDebug();

                PAYNLSDK.API.Refund.Info.Request request = new PAYNLSDK.API.Refund.Info.Request(refundID);
                InitRequestDebug(request);

                MyStaticPayNlClient.Client.PerformRequest(request);
                DebugRawResponse(request);


                tbMain.Text = request.Response.ToString();


            }
            catch (PayNlException ee)
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

            AddDebug(string.Format("Calling API {0} / {1}", request.Controller, request.Method));
            AddDebug(string.Format("Requires TOKEN? {0}", request.RequiresApiToken));
            AddDebug(string.Format("Requires SERVICEID? {0}", request.RequiresServiceId));
            AddDebug("-----");
            AddDebug("Initializing...");
            AddDebug(string.Format("URL    : {0}", request.Url));
            //AddDebug(string.Format("PARAMS : {0}", ToQueryString(request)));
            AddDebug("-----");
        }
        private void DebugRawResponse(RequestBase request)
        {
            AddDebug("RAW Result from PAYNL");
            AddDebug(request.RawResponse);
        }
    }
}
