using System;
using System.Windows.Forms;
using PAYNLSDK.Services;

namespace PAYNLFormsApp
{
    public partial class ValidationForm : Form
    {
        private IUtilityService UtilityService { get; }

        public ValidationForm(IUtilityService utilityService)
        {
            InitializeComponent();
            UtilityService = utilityService;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tbOut.Text = "";
                var v = textBox1.Text;
                var i = checkBox1.Checked;
                AddLine(string.Format("Validating bankaccount number {0} ({1})", v, i ? "INTERNATIONAL" : "NATIONAL"));
                AddLine("");
                var rs = await UtilityService.ValidateBankAccountNumberAsync(v, i);
                AddLine(string.Format("RESULT = {0}", rs));
            }
            catch (Exception ex)
            {
                AddLine("~~~EXCEPTION~~~");
                AddLine(string.Format("{0}: {1}", ex.Source, ex.Message));
            }
        }

        private void AddLine(string value)
        {
            if (tbOut.Text.Length == 0)
                tbOut.Text = value;
            else
                tbOut.AppendText(Environment.NewLine + value);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                tbOut.Text = "";
                var v = textBox2.Text;
                var i = checkBox1.Checked;
                AddLine(string.Format("Validating IBAN {0}", v));
                AddLine("");
                var rs = await UtilityService.ValidateIBANAsync(v);
                AddLine(string.Format("RESULT = {0}", rs));
            }
            catch (Exception ex)
            {
                AddLine("~~~EXCEPTION~~~");
                AddLine(string.Format("{0}: {1}", ex.Source, ex.Message));
            }
        }

        private async void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbOut.Text = "";
                var v = textBox3.Text;
                var i = checkBox1.Checked;
                AddLine(string.Format("Validating SWIFT {0}", v));
                AddLine("");
                var rs = await UtilityService.ValidateSWIFTAsync(v);
                AddLine(string.Format("RESULT = {0}", rs));
            }
            catch (Exception ex)
            {
                AddLine("~~~EXCEPTION~~~");
                AddLine(string.Format("{0}: {1}", ex.Source, ex.Message));
            }
        }

        private async void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbOut.Text = "";
                var v = textBox4.Text;
                var i = checkBox1.Checked;
                AddLine(string.Format("Validating KVK {0}", v));
                AddLine("");
                var rs = await UtilityService.ValidateKVKAsync(v);
                AddLine(string.Format("RESULT = {0}", rs));
            }
            catch (Exception ex)
            {
                AddLine("~~~EXCEPTION~~~");
                AddLine(string.Format("{0}: {1}", ex.Source, ex.Message));
            }
        }

        private async void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbOut.Text = "";
                var v = textBox5.Text;
                var i = checkBox1.Checked;
                AddLine(string.Format("Validating SOFI {0}", v));
                AddLine("");
                var rs = await UtilityService.ValidateSOFIAsync(v);
                AddLine(string.Format("RESULT = {0}", rs));
            }
            catch (Exception ex)
            {
                AddLine("~~~EXCEPTION~~~");
                AddLine(string.Format("{0}: {1}", ex.Source, ex.Message));
            }
        }

        private async void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbOut.Text = "";
                var v = textBox6.Text;
                var i = checkBox1.Checked;
                AddLine(string.Format("Validating VAT {0}", v));
                AddLine("");
                var rs = await UtilityService.ValidateVATAsync(v);
                AddLine(string.Format("RESULT = {0}", rs));
            }
            catch (Exception ex)
            {
                AddLine("~~~EXCEPTION~~~");
                AddLine(string.Format("{0}: {1}", ex.Source, ex.Message));
            }
        }

        private async void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbOut.Text = "";
                var v = textBox7.Text;
                var i = checkBox1.Checked;
                AddLine(string.Format("Validating IP {0}", v));
                AddLine("");
                var rs = await UtilityService.ValidatePayIPAsync(v);
                AddLine(string.Format("RESULT = {0}", rs));
            }
            catch (Exception ex)
            {
                AddLine("~~~EXCEPTION~~~");
                AddLine(string.Format("{0}: {1}", ex.Source, ex.Message));
            }
        }
    }
}
