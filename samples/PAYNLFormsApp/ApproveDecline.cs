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
    public partial class ApproveDecline : Form
    {
        public ApproveDecline()
        {
            InitializeComponent();
        }

        private async void btApprove_Click(object sender, EventArgs e)
        {

            DebugForm form = new DebugForm();
            await form.ApproveAsync(tbTransactionID.Text);
            form.ShowDialog();

        }

        private async void btDecline_Click(object sender, EventArgs e)
        {
            DebugForm form = new DebugForm();
            await form.DeclineAsync(tbTransactionID.Text);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            this.DialogResult = DialogResult.OK;
       
        }
    }
}
