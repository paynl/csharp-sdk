using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using PAYNLSDK.Services;

namespace PAYNLFormsApp
{
    public partial class ApproveDecline : Form
    {
        public IClientService ClientService { get; }
        public ILogger Logger { get; }

        public ApproveDecline(IClientService clientService, ILogger logger)
        {
            InitializeComponent();
            ClientService = clientService;
            Logger = logger;
        }

        private async void BtApprove_Click(object sender, EventArgs e)
        {
            var form = new DebugForm(ClientService, Logger);
            await form.ApproveAsync(tbTransactionID.Text);
            form.ShowDialog();
        }

        private async void BtDecline_Click(object sender, EventArgs e)
        {
            var form = new DebugForm(ClientService, Logger);
            await form.DeclineAsync(tbTransactionID.Text);
            form.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
