using PAYNLSDK.Enums;
using PAYNLSDK.Services;
using PAYNLSDK.Utilities;
using System;
using System.Windows.Forms;

namespace PAYNLFormsApp
{
    public partial class StartTransaction : Form
    {
        public IClientService ClientService { get; }

        public bool OK { get; protected set; }
        public LastRequests LastRequests { get; set; }

        public StartTransaction(IClientService clientService)
        {
            InitializeComponent();
            ClientService = clientService;
        }

        private void StartTransaction_Load(object sender, EventArgs e)
        {
            LastRequests = new LastRequests
            {
                LastTransactionStart = new Fixtures.TransactionStart(ClientService)
                    .GetFixtureNoProductLines()
            };

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
            tbGender.Text = EnumUtil.ToEnumString((Gender)LastRequests.LastTransactionStart.Enduser.Gender);
            //tbDOB.Text = ((DateTime)LastRequests.LastTransactionStart.Enduser.BirthDate).ToString("dd-MM-yyyy");
            dateTimePicker1.Value = (DateTime)LastRequests.LastTransactionStart.Enduser.BirthDate;
            tbPhone.Text = LastRequests.LastTransactionStart.Enduser.PhoneNumber;
            tbIBAN.Text = LastRequests.LastTransactionStart.Enduser.IBAN;
            tbEmail.Text = LastRequests.LastTransactionStart.Enduser.EmailAddress;
        }

        void Set()
        {
            // load
            LastRequests.LastTransactionStart.Amount = int.Parse(tbAmount.Text);
            LastRequests.LastTransactionStart.IPAddress = tbIP.Text;
            LastRequests.LastTransactionStart.ReturnUrl = tbReturn.Text;
            LastRequests.LastTransactionStart.Transaction.OrderExchangeUrl = tbExchange.Text;
            LastRequests.LastTransactionStart.PaymentOptionId = int.Parse(tbPaymentOption.Text);
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
