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
    public partial class TransactionRefund : Form
    {
        public TransactionRefund()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            
            DebugForm form = new DebugForm();
            form.TransactionRefund(tbTransactionID.Text, tbAmount.Text, tbExchangeUrl.Text);
            form.ShowDialog();

      
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
