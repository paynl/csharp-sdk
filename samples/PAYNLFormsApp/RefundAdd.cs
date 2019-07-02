using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace PAYNLFormsApp
{
    public partial class RefundAdd : Form
    {
        private IServiceProvider ServiceProvider { get; }

        public RefundAdd(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var form = ServiceProvider.GetRequiredService<DebugForm>();
            await form.RefundAddAsync(tbBankAccountName.Text, tbBankAccountNumber.Text, tbAmount.Text);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
