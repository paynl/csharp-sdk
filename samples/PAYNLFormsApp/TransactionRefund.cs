using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using PAYNLSDK.Services;

namespace PAYNLFormsApp
{
    public partial class TransactionRefund : Form
    {
        public IClientService ClientService { get; }
        public ILogger Logger { get; }

        public TransactionRefund(IClientService clientService, ILogger logger)
        {
            InitializeComponent();
            ClientService = clientService;
            Logger = logger;
        }

        private async void btOK_Click(object sender, EventArgs e)
        {
            var form = new DebugForm(ClientService, Logger);
            await form.TransactionRefundAsync(tbTransactionID.Text, tbAmount.Text, tbExchangeUrl.Text);
            form.ShowDialog();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
