using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace PAYNLFormsApp
{
    public partial class ApproveDecline : Form
    {
        private IServiceProvider ServiceProvider { get; }

        public ApproveDecline(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
        }

        private async void BtApprove_Click(object sender, EventArgs e)
        {
            var form = ServiceProvider.GetRequiredService<DebugForm>();
            await form.ApproveAsync(tbTransactionID.Text);
            form.ShowDialog();
        }

        private async void BtDecline_Click(object sender, EventArgs e)
        {
            var form = ServiceProvider.GetRequiredService<DebugForm>();
            await form.DeclineAsync(tbTransactionID.Text);
            form.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
