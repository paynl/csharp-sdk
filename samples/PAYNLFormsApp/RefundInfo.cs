using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using PAYNLSDK.Services;

namespace PAYNLFormsApp
{
    public partial class RefundInfo : Form
    {
        public IClientService ClientService { get; }
        public ILogger Logger { get; }

        public RefundInfo(IClientService clientService, ILogger logger)
        {
            InitializeComponent();
            ClientService = clientService;
            Logger = logger;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var form = new DebugForm(ClientService, Logger);
            await form.TransactionRefundInfoAsync(tbRefundID.Text);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
