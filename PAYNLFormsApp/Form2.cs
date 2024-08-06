using System;
using System.Collections.Generic;
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
            var cores = new Dictionary<string, string>();
            cores.Add(PAYNLSDK.API.RequestBase.Core1, PAYNLSDK.API.RequestBase.Core1Label);
            cores.Add(PAYNLSDK.API.RequestBase.Core2, PAYNLSDK.API.RequestBase.Core2Label);
            cores.Add(PAYNLSDK.API.RequestBase.Core3, PAYNLSDK.API.RequestBase.Core3Label);
            cores.Add(PAYNLSDK.API.RequestBase.Core4, PAYNLSDK.API.RequestBase.Core4Label);
            comboBox1.DataSource = new BindingSource(cores, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.Text = APISettings.Core;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            APISettings.ApiToken = tbApitoken.Text;
            APISettings.ServiceID = tbServiceID.Text;
            APISettings.Core = comboBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

