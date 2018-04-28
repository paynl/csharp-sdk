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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tbApitoken.Text = PAYNLFormsApp.MyStaticPayNlClient.ApiToken;
            tbServiceID.Text = PAYNLFormsApp.MyStaticPayNlClient.ServiceId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PAYNLFormsApp.MyStaticPayNlClient.ApiToken = tbApitoken.Text;
            PAYNLFormsApp.MyStaticPayNlClient.ServiceId = tbServiceID.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
               
            this.DialogResult = DialogResult.OK;
        }
    }
    }

