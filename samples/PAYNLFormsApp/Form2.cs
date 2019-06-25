using System;
using System.Windows.Forms;
using PAYNLSDK.Services;

namespace PAYNLFormsApp
{
    public partial class Form2 : Form
    {
        public IClientService ClientService { get; }

        public Form2(IClientService clientService)
        {
            InitializeComponent();
            ClientService = clientService;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tbApitoken.Text = ClientService.Settings.ApiToken;
            tbServiceID.Text = ClientService.Settings.ServiceId;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ClientService.Settings.SetApiToken(tbApitoken.Text, tbServiceID.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

