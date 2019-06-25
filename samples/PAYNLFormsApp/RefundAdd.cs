using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            DebugForm form = new DebugForm();
            await form.RefundAddAsync(tbBankAccountName.Text, tbBankAccountNumber.Text, tbAmount.Text);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
