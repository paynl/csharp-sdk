using System;
using System.Windows.Forms;
using Microsoft.Extensions.Options;
using PAYNLFormsApp.Objects;

namespace PAYNLFormsApp
{
    public partial class Form2 : Form
    {
        private AppSettings Settings { get; }

        public Form2(IOptions<AppSettings> settings)
        {
            InitializeComponent();
            Settings = settings.Value;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tbApitoken.Text = Settings.ApiToken;
            tbServiceID.Text = Settings.ServiceId;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Settings.ApiToken = tbApitoken.Text;
            Settings.ServiceId = tbServiceID.Text;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

