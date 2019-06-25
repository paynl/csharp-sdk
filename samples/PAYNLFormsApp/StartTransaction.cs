﻿using PAYNLSDK.Enums;
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
    public partial class StartTransaction : Form
    {

        public static bool OK { get; protected set; }

        public StartTransaction()
        {
            InitializeComponent();
        }

        private void StartTransaction_Load(object sender, EventArgs e)
        {
            LastRequests.LastTransactionStart = Fixtures.TransactionStart.GetFixtureNoProductLines();

            // load
            tbAmount.Text = LastRequests.LastTransactionStart.Amount.ToString();
            tbIP.Text = LastRequests.LastTransactionStart.IPAddress;
            tbReturn.Text = LastRequests.LastTransactionStart.ReturnUrl;
            tbExchange.Text = LastRequests.LastTransactionStart.Transaction.OrderExchangeUrl;
            tbPaymentOption.Text = LastRequests.LastTransactionStart.PaymentOptionId.ToString();
            tbDesc.Text = LastRequests.LastTransactionStart.Transaction.Description;

            tbUserlang.Text = LastRequests.LastTransactionStart.Enduser.Language;
            tbInitials.Text = LastRequests.LastTransactionStart.Enduser.Initials;
            tbLastname.Text = LastRequests.LastTransactionStart.Enduser.Lastname;
            tbGender.Text = EnumUtil.ToEnumString<Gender>((Gender)LastRequests.LastTransactionStart.Enduser.Gender);
            //tbDOB.Text = ((DateTime)LastRequests.LastTransactionStart.Enduser.BirthDate).ToString("dd-MM-yyyy");
            dateTimePicker1.Value = ((DateTime)LastRequests.LastTransactionStart.Enduser.BirthDate);
            tbPhone.Text = LastRequests.LastTransactionStart.Enduser.PhoneNumber;
            tbIBAN.Text = LastRequests.LastTransactionStart.Enduser.IBAN;
            tbEmail.Text = LastRequests.LastTransactionStart.Enduser.EmailAddress;
        }

        void Set()
        {
            // load
            LastRequests.LastTransactionStart.Amount = Int32.Parse(tbAmount.Text);
            LastRequests.LastTransactionStart.IPAddress = tbIP.Text;
            LastRequests.LastTransactionStart.ReturnUrl = tbReturn.Text;
            LastRequests.LastTransactionStart.Transaction.OrderExchangeUrl = tbExchange.Text;
            LastRequests.LastTransactionStart.PaymentOptionId = Int32.Parse(tbPaymentOption.Text);
            LastRequests.LastTransactionStart.Transaction.Description = tbDesc.Text;

            LastRequests.LastTransactionStart.Enduser.Language = tbUserlang.Text;
            LastRequests.LastTransactionStart.Enduser.Initials = tbInitials.Text;
            LastRequests.LastTransactionStart.Enduser.Lastname = tbLastname.Text;
            LastRequests.LastTransactionStart.Enduser.Gender = EnumUtil.ToEnum<Gender>(tbGender.Text);
            LastRequests.LastTransactionStart.Enduser.BirthDate = dateTimePicker1.Value;
            LastRequests.LastTransactionStart.Enduser.PhoneNumber = tbPhone.Text;
            LastRequests.LastTransactionStart.Enduser.IBAN = tbIBAN.Text;
            LastRequests.LastTransactionStart.Enduser.EmailAddress = tbEmail.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                Set();
                OK = true;
            }
            catch {
            }
            Close();
        }
    }
}
