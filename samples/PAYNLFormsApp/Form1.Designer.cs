namespace PAYNLFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpPaymentmethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpTransactionGetServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txInfoFor619204633Xc4027eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xc4027ePAIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xc5b75dPAIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xd83303CANCELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transActionStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionStartproductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refundtransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refundTrasactionProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionRefundInofromJsonFixtureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testDateTimeConversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payNLAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startuseFixtureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startuseFixtureEditableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.declineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refundAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refundAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refundInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbMain = new System.Windows.Forms.TextBox();
            this.tbDebug = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.transactionAPIToolStripMenuItem,
            this.changeToolStripMenuItem,
            this.refundAPIToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validationToolStripMenuItem,
            this.dumpPaymentmethodsToolStripMenuItem,
            this.dumpTransactionGetServiceToolStripMenuItem,
            this.txInfoFor619204633Xc4027eToolStripMenuItem,
            this.fixturesToolStripMenuItem,
            this.serviceCategoriesToolStripMenuItem,
            this.testDateTimeConversionToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // validationToolStripMenuItem
            // 
            this.validationToolStripMenuItem.Name = "validationToolStripMenuItem";
            this.validationToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.validationToolStripMenuItem.Text = "Validation";
            this.validationToolStripMenuItem.Click += new System.EventHandler(this.ValidationToolStripMenuItem_Click);
            // 
            // dumpPaymentmethodsToolStripMenuItem
            // 
            this.dumpPaymentmethodsToolStripMenuItem.Name = "dumpPaymentmethodsToolStripMenuItem";
            this.dumpPaymentmethodsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.dumpPaymentmethodsToolStripMenuItem.Text = "Dump Paymentmethods";
            this.dumpPaymentmethodsToolStripMenuItem.Click += new System.EventHandler(this.DumpPaymentmethodsToolStripMenuItem_Click);
            // 
            // dumpTransactionGetServiceToolStripMenuItem
            // 
            this.dumpTransactionGetServiceToolStripMenuItem.Name = "dumpTransactionGetServiceToolStripMenuItem";
            this.dumpTransactionGetServiceToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.dumpTransactionGetServiceToolStripMenuItem.Text = "Dump Transaction::GetService";
            this.dumpTransactionGetServiceToolStripMenuItem.Click += new System.EventHandler(this.DumpTransactionGetServiceToolStripMenuItem_Click);
            // 
            // txInfoFor619204633Xc4027eToolStripMenuItem
            // 
            this.txInfoFor619204633Xc4027eToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xc4027ePAIDToolStripMenuItem,
            this.xc5b75dPAIDToolStripMenuItem,
            this.xd83303CANCELToolStripMenuItem});
            this.txInfoFor619204633Xc4027eToolStripMenuItem.Name = "txInfoFor619204633Xc4027eToolStripMenuItem";
            this.txInfoFor619204633Xc4027eToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.txInfoFor619204633Xc4027eToolStripMenuItem.Text = "Dump Transaction Info";
            // 
            // xc4027ePAIDToolStripMenuItem
            // 
            this.xc4027ePAIDToolStripMenuItem.Name = "xc4027ePAIDToolStripMenuItem";
            this.xc4027ePAIDToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.xc4027ePAIDToolStripMenuItem.Text = "619204633Xc4027e [PAID]";
            this.xc4027ePAIDToolStripMenuItem.Click += new System.EventHandler(this.Xc4027ePAIDToolStripMenuItem_Click);
            // 
            // xc5b75dPAIDToolStripMenuItem
            // 
            this.xc5b75dPAIDToolStripMenuItem.Name = "xc5b75dPAIDToolStripMenuItem";
            this.xc5b75dPAIDToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.xc5b75dPAIDToolStripMenuItem.Text = "611642851Xc5b75d [PAID]";
            this.xc5b75dPAIDToolStripMenuItem.Click += new System.EventHandler(this.Xc5b75dPAIDToolStripMenuItem_Click);
            // 
            // xd83303CANCELToolStripMenuItem
            // 
            this.xd83303CANCELToolStripMenuItem.Name = "xd83303CANCELToolStripMenuItem";
            this.xd83303CANCELToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.xd83303CANCELToolStripMenuItem.Text = "618847570Xd83303 [CANCEL]";
            this.xd83303CANCELToolStripMenuItem.Click += new System.EventHandler(this.Xd83303CANCELToolStripMenuItem_Click);
            // 
            // fixturesToolStripMenuItem
            // 
            this.fixturesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transActionStartToolStripMenuItem,
            this.transactionStartproductsToolStripMenuItem,
            this.refundtransactionToolStripMenuItem,
            this.refundTrasactionProductsToolStripMenuItem,
            this.transactionRefundInofromJsonFixtureToolStripMenuItem});
            this.fixturesToolStripMenuItem.Name = "fixturesToolStripMenuItem";
            this.fixturesToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.fixturesToolStripMenuItem.Text = "Fixtures";
            // 
            // transActionStartToolStripMenuItem
            // 
            this.transActionStartToolStripMenuItem.Name = "transActionStartToolStripMenuItem";
            this.transActionStartToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.transActionStartToolStripMenuItem.Text = "TransAction.Start";
            this.transActionStartToolStripMenuItem.Click += new System.EventHandler(this.TransActionStartToolStripMenuItem_Click);
            // 
            // transactionStartproductsToolStripMenuItem
            // 
            this.transactionStartproductsToolStripMenuItem.Name = "transactionStartproductsToolStripMenuItem";
            this.transactionStartproductsToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.transactionStartproductsToolStripMenuItem.Text = "Transaction.Start (-products)";
            this.transactionStartproductsToolStripMenuItem.Click += new System.EventHandler(this.TransactionStartproductsToolStripMenuItem_Click);
            // 
            // refundtransactionToolStripMenuItem
            // 
            this.refundtransactionToolStripMenuItem.Name = "refundtransactionToolStripMenuItem";
            this.refundtransactionToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.refundtransactionToolStripMenuItem.Text = "Refund.Transaction";
            this.refundtransactionToolStripMenuItem.Click += new System.EventHandler(this.RefundtransactionToolStripMenuItem_Click);
            // 
            // refundTrasactionProductsToolStripMenuItem
            // 
            this.refundTrasactionProductsToolStripMenuItem.Name = "refundTrasactionProductsToolStripMenuItem";
            this.refundTrasactionProductsToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.refundTrasactionProductsToolStripMenuItem.Text = "Refund.Trasaction (- products)";
            this.refundTrasactionProductsToolStripMenuItem.Click += new System.EventHandler(this.RefundTrasactionProductsToolStripMenuItem_Click);
            // 
            // transactionRefundInofromJsonFixtureToolStripMenuItem
            // 
            this.transactionRefundInofromJsonFixtureToolStripMenuItem.Name = "transactionRefundInofromJsonFixtureToolStripMenuItem";
            this.transactionRefundInofromJsonFixtureToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.transactionRefundInofromJsonFixtureToolStripMenuItem.Text = "Transaction.RefundIno (from json fixture)";
            this.transactionRefundInofromJsonFixtureToolStripMenuItem.Click += new System.EventHandler(this.TransactionRefundInofromJsonFixtureToolStripMenuItem_Click);
            // 
            // serviceCategoriesToolStripMenuItem
            // 
            this.serviceCategoriesToolStripMenuItem.Name = "serviceCategoriesToolStripMenuItem";
            this.serviceCategoriesToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.serviceCategoriesToolStripMenuItem.Text = "ServiceCategories";
            this.serviceCategoriesToolStripMenuItem.Click += new System.EventHandler(this.ServiceCategoriesToolStripMenuItem_Click);
            // 
            // testDateTimeConversionToolStripMenuItem
            // 
            this.testDateTimeConversionToolStripMenuItem.Name = "testDateTimeConversionToolStripMenuItem";
            this.testDateTimeConversionToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.testDateTimeConversionToolStripMenuItem.Text = "Test date time conversion";
            this.testDateTimeConversionToolStripMenuItem.Click += new System.EventHandler(this.TestDateTimeConversionToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.payNLAPIToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // payNLAPIToolStripMenuItem
            // 
            this.payNLAPIToolStripMenuItem.Name = "payNLAPIToolStripMenuItem";
            this.payNLAPIToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.payNLAPIToolStripMenuItem.Text = "PayNL API";
            this.payNLAPIToolStripMenuItem.Click += new System.EventHandler(this.PayNLAPIToolStripMenuItem_Click);
            // 
            // transactionAPIToolStripMenuItem
            // 
            this.transactionAPIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startuseFixtureToolStripMenuItem,
            this.startuseFixtureEditableToolStripMenuItem,
            this.approveToolStripMenuItem,
            this.declineToolStripMenuItem,
            this.refundToolStripMenuItem});
            this.transactionAPIToolStripMenuItem.Name = "transactionAPIToolStripMenuItem";
            this.transactionAPIToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.transactionAPIToolStripMenuItem.Text = "Transaction API";
            // 
            // startuseFixtureToolStripMenuItem
            // 
            this.startuseFixtureToolStripMenuItem.Name = "startuseFixtureToolStripMenuItem";
            this.startuseFixtureToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.startuseFixtureToolStripMenuItem.Text = "Start (use fixture; no modify)";
            this.startuseFixtureToolStripMenuItem.Click += new System.EventHandler(this.StartuseFixtureToolStripMenuItem_Click);
            // 
            // startuseFixtureEditableToolStripMenuItem
            // 
            this.startuseFixtureEditableToolStripMenuItem.Name = "startuseFixtureEditableToolStripMenuItem";
            this.startuseFixtureEditableToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.startuseFixtureEditableToolStripMenuItem.Text = "Start (use fixture, editable)";
            this.startuseFixtureEditableToolStripMenuItem.Click += new System.EventHandler(this.StartuseFixtureEditableToolStripMenuItem_Click);
            // 
            // approveToolStripMenuItem
            // 
            this.approveToolStripMenuItem.Name = "approveToolStripMenuItem";
            this.approveToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.approveToolStripMenuItem.Text = "Approve";
            this.approveToolStripMenuItem.Click += new System.EventHandler(this.ApproveToolStripMenuItem_Click);
            // 
            // declineToolStripMenuItem
            // 
            this.declineToolStripMenuItem.Name = "declineToolStripMenuItem";
            this.declineToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.declineToolStripMenuItem.Text = "Decline";
            this.declineToolStripMenuItem.Click += new System.EventHandler(this.DeclineToolStripMenuItem_Click);
            // 
            // refundToolStripMenuItem
            // 
            this.refundToolStripMenuItem.Name = "refundToolStripMenuItem";
            this.refundToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.refundToolStripMenuItem.Text = "Refund";
            this.refundToolStripMenuItem.Click += new System.EventHandler(this.RefundToolStripMenuItem_Click);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refundAddToolStripMenuItem});
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.changeToolStripMenuItem.Text = "Change";
            // 
            // refundAddToolStripMenuItem
            // 
            this.refundAddToolStripMenuItem.Name = "refundAddToolStripMenuItem";
            this.refundAddToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refundAddToolStripMenuItem.Text = "Refund-Add";
            this.refundAddToolStripMenuItem.Click += new System.EventHandler(this.RefundAddToolStripMenuItem_Click);
            // 
            // refundAPIToolStripMenuItem
            // 
            this.refundAPIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refundInfoToolStripMenuItem});
            this.refundAPIToolStripMenuItem.Name = "refundAPIToolStripMenuItem";
            this.refundAPIToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.refundAPIToolStripMenuItem.Text = "Refund API";
            // 
            // refundInfoToolStripMenuItem
            // 
            this.refundInfoToolStripMenuItem.Name = "refundInfoToolStripMenuItem";
            this.refundInfoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refundInfoToolStripMenuItem.Text = "Refund.Info";
            this.refundInfoToolStripMenuItem.Click += new System.EventHandler(this.RefundInfoToolStripMenuItem_Click);
            // 
            // tbMain
            // 
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Multiline = true;
            this.tbMain.Name = "tbMain";
            this.tbMain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMain.Size = new System.Drawing.Size(378, 535);
            this.tbMain.TabIndex = 1;
            // 
            // tbDebug
            // 
            this.tbDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDebug.Location = new System.Drawing.Point(378, 0);
            this.tbDebug.Multiline = true;
            this.tbDebug.Name = "tbDebug";
            this.tbDebug.ReadOnly = true;
            this.tbDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDebug.Size = new System.Drawing.Size(354, 535);
            this.tbDebug.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.tbDebug);
            this.panel1.Controls.Add(this.tbMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 535);
            this.panel1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(378, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 535);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 559);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payNLAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpPaymentmethodsToolStripMenuItem;
        private System.Windows.Forms.TextBox tbMain;
        private System.Windows.Forms.TextBox tbDebug;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem dumpTransactionGetServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txInfoFor619204633Xc4027eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xc4027ePAIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xc5b75dPAIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xd83303CANCELToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transActionStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionStartproductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startuseFixtureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startuseFixtureEditableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem declineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refundAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testDateTimeConversionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refundtransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refundTrasactionProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionRefundInofromJsonFixtureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refundAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refundInfoToolStripMenuItem;
    }
}

