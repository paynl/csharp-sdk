using System;
using System.Windows.Forms;

namespace PAYNLFormsApp
{
    public partial class TransactionRefund : Form
    {
        public TransactionRefund()
        {
            InitializeComponent();
        }

        private async void btOK_Click(object sender, EventArgs e)
        {
            var form = new DebugForm();
            await form.TransactionRefundAsync(tbTransactionID.Text, tbAmount.Text, tbExchangeUrl.Text);
            form.ShowDialog();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
