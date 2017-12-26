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
            MyStaticPayNlClient.ApiToken = "88a97a72281e64491347f873041f33f7d3514a55";
            MyStaticPayNlClient.ServiceId = "SL-5285-2850";
            Application.Run(new Form1());
        }
    }

    class MyStaticPayNlClient
    {
        public static string ApiToken { get; set; }
        public static string ServiceId { get; set; }
        
        private static IClient _client;
        public static IClient Client => _client ?? (_client = new Client(ApiToken, ServiceId));
    }
    
    static class LastRequests
    {
        public static PAYNLSDK.API.Transaction.Start.Request LastTransactionStart { get; set; }
        public static RequestBase LastRequest { get; set; }
    }
}
