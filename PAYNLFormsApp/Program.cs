using PAYNLSDK.API;
using PAYNLSDK.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            APISettings.ApiToken = "06fe50eb098ad1f8becaa20231023adeae6325c4";
            APISettings.ServiceID = "SL-5796-8370";
            Application.Run(new Form1());
        }
    }

    class APISettings
    {
        public static string ApiToken { get; set; }
        public static string ServiceID { get; set; }
        public static string Core { get; set; }

        public static void InitAPI()
        {
            RequestBase.ApiToken = ApiToken;
            RequestBase.ServiceId = ServiceID;
            RequestBase.Core = Core;
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
