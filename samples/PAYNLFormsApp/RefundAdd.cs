using System;
using System.Windows.Forms;

namespace PAYNLFormsApp
{
    public partial class RefundAdd : Form
    {
        public RefundAdd()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var form = new DebugForm();
            await form.RefundAddAsync(tbBankAccountName.Text, tbBankAccountNumber.Text, tbAmount.Text);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
