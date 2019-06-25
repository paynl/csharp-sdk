using System;
using System.Windows.Forms;

namespace PAYNLFormsApp
{
    public partial class ApproveDecline : Form
    {
        public ApproveDecline()
        {
            InitializeComponent();
        }

        private async void BtApprove_Click(object sender, EventArgs e)
        {
            var form = new DebugForm();
            await form.ApproveAsync(tbTransactionID.Text);
            form.ShowDialog();
        }

        private async void BtDecline_Click(object sender, EventArgs e)
        {
            var form = new DebugForm();
            await form.DeclineAsync(tbTransactionID.Text);
            form.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
