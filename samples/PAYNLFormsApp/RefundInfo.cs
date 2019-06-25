using System;
using System.Windows.Forms;

namespace PAYNLFormsApp
{
    public partial class RefundInfo : Form
    {
        public RefundInfo()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var form = new DebugForm();
            await form.TransactionRefundInfoAsync(tbRefundID.Text);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
