using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace PAYNLFormsApp
{
    public partial class RefundInfo : Form
    {
        private IServiceProvider ServiceProvider { get; }

        public RefundInfo(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var form = ServiceProvider.GetRequiredService<DebugForm>();
            await form.TransactionRefundInfoAsync(tbRefundID.Text);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
