using System;
using System.Windows.Forms;

namespace PAYNLFormsApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tbApitoken.Text = PAYNLFormsApp.APISettings.ApiToken;
            tbServiceID.Text = PAYNLFormsApp.APISettings.ServiceID;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PAYNLFormsApp.APISettings.ApiToken = tbApitoken.Text;
            PAYNLFormsApp.APISettings.ServiceID = tbServiceID.Text;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

