using PAYNLSDK.API;
using PAYNLSDK.Net;
using System;
using System.Windows.Forms;

namespace PAYNLFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Set test token/SL
            APISettings.ApiToken = "e41f83b246b706291ea9ad798ccfd9f0fee5e0ab";
            APISettings.ServiceID = "SL-3490-4320";
            Application.Run(new Form1());
        }
    }

    class APISettings
    {
        public static string ApiToken { get; set; }
        public static string ServiceID { get; set; }

        public static void InitAPI()
        {
            RequestBase.ApiToken = ApiToken;
            RequestBase.ServiceId = ServiceID;
        }

        private static IClient client;
        public static IClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new Client();
                }
                InitAPI();
                return client;
            }
        }
    }

    class LastRequests
    {
        public static PAYNLSDK.API.Transaction.Start.Request LastTransactionStart { get; set; }
        public static RequestBase LastRequest { get; set; }
    }
}
