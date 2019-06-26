using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace PAYNLFormsApp
{
    public partial class TransactionRefund : Form
    {
        private IServiceProvider ServiceProvider { get; }

        public TransactionRefund(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
        }

        private async void btOK_Click(object sender, EventArgs e)
        {
            var form = ServiceProvider.GetRequiredService<DebugForm>();
            await form.TransactionRefundAsync(tbTransactionID.Text, tbAmount.Text, tbExchangeUrl.Text);
            form.ShowDialog();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
