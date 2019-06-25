using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PAYNLSDK.API.Validate;

namespace PAYNLFormsApp
{
    public partial class ValidationForm : Form
    {
        protected Util validator;

        public ValidationForm()
        {
            InitializeComponent();
            validator = new Util(APISettings.Client);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tbOut.Text = "";
                string v = textBox1.Text;
                bool i = checkBox1.Checked;
                AddLine(string.Format("Validating bankaccount number {0} ({1})", v, i ? "INTERNATIONAL" : "NATIONAL"));
                AddLine("");
                bool rs = await validator.ValidateBankAccountNumberAsync(v, i);
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
                tbOut.AppendText(System.Environment.NewLine + value);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                tbOut.Text = "";
                string v = textBox2.Text;
                bool i = checkBox1.Checked;
                AddLine(string.Format("Validating IBAN {0}", v));
                AddLine("");
                bool rs = await validator.ValidateIBANAsync(v);
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
                string v = textBox3.Text;
                bool i = checkBox1.Checked;
                AddLine(string.Format("Validating SWIFT {0}", v));
                AddLine("");
                bool rs = await validator.ValidateSWIFTAsync(v);
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
                string v = textBox4.Text;
                bool i = checkBox1.Checked;
                AddLine(string.Format("Validating KVK {0}", v));
                AddLine("");
                bool rs = await validator.ValidateKVKAsync(v);
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
                string v = textBox5.Text;
                bool i = checkBox1.Checked;
                AddLine(string.Format("Validating SOFI {0}", v));
                AddLine("");
                bool rs = await validator.ValidateSOFIAsync(v);
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
                string v = textBox6.Text;
                bool i = checkBox1.Checked;
                AddLine(string.Format("Validating VAT {0}", v));
                AddLine("");
                bool rs = await validator.ValidateVATAsync(v);
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
                string v = textBox7.Text;
                bool i = checkBox1.Checked;
                AddLine(string.Format("Validating IP {0}", v));
                AddLine("");
                bool rs = await validator.ValidatePayIPAsync(v);
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
